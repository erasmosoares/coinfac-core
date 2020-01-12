using System;
using AutoMapper;
using System.Threading.Tasks;
using CoinFac.Domain.Accounts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using CoinFac.Application.Interfaces;
using CoinFac.Service.Models;

namespace CoinFac.Service.Controllers.Accounts
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
        public async Task<ActionResult<IEnumerable<Account>>> Get()
        {
            try
            {
                var accountsInDb = await UnitOfWork.AccountRepository.GetAllAsync();
                return Ok(Mapper.Map<IEnumerable<AccountDto>>(accountsInDb));
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
        public async Task<ActionResult<Account>> Get(int accountId)
        {
            try
            {
                var accountInDb = await UnitOfWork.AccountRepository.GetAsync(accountId);
                if (accountInDb == null)
                {
                    return NotFound();
                }

                return Ok(Mapper.Map<Account, AccountDto>(accountInDb));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        /// <summary>
        /// Create an account
        /// </summary>
        /// <param name="accountDto">The account to create</param>
        /// <returns>An ActionResult of type Account</returns>
        [HttpPost()]
        public async Task<ActionResult<Account>> Post(AccountDto accountDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var account = Mapper.Map<Account>(accountDto);
                await UnitOfWork.AccountRepository.AddAsync(account);
                await UnitOfWork.CompleteAsync();

                accountDto.Id = account.Id;
                return Created($"/api/accounts/{account.Id}", accountDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

        }
    }
}