using System;
using AutoMapper;
using System.Threading.Tasks;
using CoinFac.Domain.Accounts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using CoinFac.Application.Interfaces.Repositories;
using CoinFac.Application.Interfaces;

namespace CoinFac.Service.Controllers
{
    [Produces("application/json", "application/xml")]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IUnitOfWork UnitOfWork;

        private readonly IMapper Mapper;

        public AccountsController(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        /// <summary>
        /// Get account list
        /// </summary>
        /// <returns>An ActionResult of type IEnumerable of Accounts</returns>
        /// http://localhost:44372/api/accounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccounts()
        {
            try
            {
                var accountsFromRepo = await UnitOfWork.AccountRepository.GetAllAsync();
                return Ok(Mapper.Map<IEnumerable<Account>>(accountsFromRepo));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        /// <summary>
        /// Get an account by id
        /// </summary>
        /// <param name="accountId">The id of the account you want to get</param>
        /// <returns>An ActionResult of type Account</returns>
        /// http://localhost:44372/api/accounts/1
        [HttpGet("{accountId}")]
        public async Task<ActionResult<Account>> GetAccount(int accountId)
        {
            var authorFromRepo = await UnitOfWork.AccountRepository.GetAsync(accountId);
            if (authorFromRepo == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Account>(authorFromRepo));
        }

        ///// <summary>
        ///// Create an account
        ///// </summary>
        ///// <param name="bookForCreation">The book to create</param>
        ///// <returns>An ActionResult of type Account</returns>
        ///// <response code="422">Validation error</response>
        //[HttpPost()]
        //[Consumes("application/json", "application/vnd.marvin.bookforcreation+json")]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status422UnprocessableEntity,
        //    Type = typeof(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary))]
        //public async Task<ActionResult<Account>> CreateAccount(
        //    int accountId,
        //    [FromBody] AccountForCreation accountForCreation)
        //{
        //    if (!await AccountRepository.AccountExistsAsync(authorId))
        //    {
        //        return NotFound();
        //    }

        //    var accountToAdd = Mapper.Map<Account>(accountForCreation);
        //    await AccountRepository.AddAsync(accountToAdd);
        //    await AccountRepository.SaveChangesAsync();

        //    return CreatedAtRoute(
        //        "GetAccount",
        //        new { accountId },
        //        Mapper.Map<Account>(accountToAdd));
        //}
    }
}