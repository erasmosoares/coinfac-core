using AutoMapper;
using CoinFac.Application.Interfaces;
using CoinFac.Domain.Identity;
using CoinFac.Service.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoinFac.Service.Controllers.Users
{
    //https://localhost:44372/swagger/index.html

    [Produces("application/json", "application/xml")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork UnitOfWork;
        private readonly IMapper Mapper;

        public UserController(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        /// <summary>
        /// Get users list
        /// </summary>
        /// <returns>An ActionResult of type IEnumerable of User</returns>
        /// http://localhost:44372/api/user
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            try
            {
                var usersInDb = await UnitOfWork.UserRepository.GetAllAsync();
                return Ok(Mapper.Map<IEnumerable<UserDto>>(usersInDb));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        /// <summary>
        /// Get an user by id
        /// </summary>
        /// <param name="userId">The id of the user you want to get</param>
        /// <returns>An ActionResult of type User</returns>
        /// http://localhost:44372/api/user/1
        [HttpGet("{userId}")]
        public async Task<ActionResult<User>> Get(int userId)
        {
            try
            {
                var userInDb = await UnitOfWork.UserRepository.GetAsync(userId);
                if (userInDb == null)
                {
                    return NotFound();
                }

                return Ok(Mapper.Map<User, UserDto>(userInDb));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        /// <summary>
        /// Validate if exists and create an user
        /// </summary>
        /// <param name="userDto">The user to create</param>
        /// <returns>An ActionResult of type User</returns>
        [HttpPost()]
        public async Task<ActionResult<User>> Post(UserDto userDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                User userInDb = await UnitOfWork.UserRepository.GetUserByEmailAsync(userDto.Email);
                if (userInDb != null && userInDb.EmailVerified == "True")
                {
                    return StatusCode(StatusCodes.Status302Found, "User already in Db");
                }
                else
                {
                    var user = Mapper.Map<User>(userDto);
                    await UnitOfWork.UserRepository.AddAsync(user);
                    await UnitOfWork.CompleteAsync();

                    userDto.Id = user.Id;
                    return Created($"/api/user/{user.Id}", userDto);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

        }

        /// <summary>
        /// Get an user by email
        /// </summary>
        /// <param name="userId">The email of the user you want to get</param>
        /// <returns>An ActionResult of type User</returns>
        /// http://localhost:44372/api/user/email/erasmosaraujo@gmail.com
        [HttpGet("email/{email}")]
        public async Task<ActionResult<User>> Get(string email)
        {
            try
            {
                var userInDb = await UnitOfWork.UserRepository.GetUserByEmailAsync(email);
                if (userInDb == null)
                {
                    return NotFound();
                }

                return Ok(Mapper.Map<User, UserDto>(userInDb));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }
    }
}