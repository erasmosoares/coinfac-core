using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CoinFac.Application.Interfaces;
using System.Threading.Tasks;
using CoinFac.Service.Dtos;
using System;
using Microsoft.AspNetCore.Http;
using CoinFac.Domain.Accounts;
using System.Net.Http.Headers;
using System.Text;
using CoinFac.Service.Common;

namespace CoinFac.Service.Controllers.Accounts
{
    [Produces("application/json", "application/xml")]
    [Route("api/[controller]")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        private readonly IAuthorizationExtractor AuthExtractor;
        private readonly IUnitOfWork UnitOfWork;
        private readonly IMapper Mapper;

        public RecordsController(IUnitOfWork unitOfWork,
            IAuthorizationExtractor authorizationExtractor,
            IMapper mapper)
        {
            AuthExtractor = authorizationExtractor;
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }
       
        /// <summary>
        /// Post a list of records
        /// </summary>
        /// <param name="RecordsDto">The account to create</param>
        /// <returns>An ActionResult of type Account</returns>
        [HttpPost()] 
        public async Task<ActionResult<Record>> Post([FromBody] RecordDto recordDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                int userId = AuthExtractor.getUser(Request);

                //Get account Id by name
                Account account = await UnitOfWork.AccountRepository.GetAccountByNameAndUserId(recordDto.Account, userId);

                //Create a new record
                Record record = new Record();
                record.AccountId = account.Id;
                record.Notes = string.Empty;
                record.Value = recordDto.Amount;
                record.Date = DateTime.Now;

                //account.Records.Add(record);

                //Push
                await UnitOfWork.RecordRepository.AddAsync(record);
                await UnitOfWork.CompleteAsync();
                //var record = Mapper.Map<Account>(recordDto);

                return Ok("Record Created");
            }
            catch (Exception) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

        }

        /// <summary>
        /// Get an record by id
        /// </summary>
        /// <param name="recordId">The id of the record you want to get</param>
        /// <returns>An ActionResult of type Account</returns>
        /// http://localhost:44372/api/records/1
        [HttpGet("{recordId}")]
        public async Task<ActionResult<Record>> Get(int recordId)
        {
            try
            {
                var recordInDb = await UnitOfWork.RecordRepository.GetAsync(recordId);
                if (recordInDb == null)
                {
                    return NotFound();
                }

                return Ok(Mapper.Map<Record, RecordDto>(recordInDb));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

    }
}
