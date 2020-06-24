using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CoinFac.Application.Interfaces;
using System.Threading.Tasks;
using CoinFac.Service.Dtos;
using System;
using Microsoft.AspNetCore.Http;
using CoinFac.Domain.Accounts;

namespace CoinFac.Service.Controllers.Accounts
{
    [Produces("application/json", "application/xml")]
    [Route("api/[controller]")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        private readonly IUnitOfWork UnitOfWork;
        private readonly IMapper Mapper;

        public RecordsController(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }
       
        /// <summary>
        /// Post a list of records
        /// </summary>
        /// <param name="RecordsDto">The account to create</param>
        /// <returns>An ActionResult of type Account</returns>
        [HttpPost()] 
        public async Task<ActionResult<Record>> Post([FromBody] RecordDto recordDto, int accountUserId)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                //Get account Id by name
                Account account = await UnitOfWork.AccountRepository.GetAccountByNameAndUserId(recordDto.Account, accountUserId);

                //Create a new record
                Record record = new Record();
                record.AccountId = account.Id;
                record.Notes = string.Empty;
                record.Value = recordDto.Amount;
                record.Date = DateTime.Now;
                
                //Push
                await UnitOfWork.RecordRepository.AddAsync(record);
                //var record = Mapper.Map<Account>(recordDto);

                return Created($"/api/records/{record.Id}", recordDto);
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
