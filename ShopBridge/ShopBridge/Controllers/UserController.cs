using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopBridgeData.Entity;
using ShopBridgeServices;
using ShopBridgeServices.Interfaces;

namespace ShopBridge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        /// <summary>
        /// Description : To get all users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var response = await _userService.GetAllUsersAsync();

            switch (response)
            {
                case null:
                    return StatusCode(500);
                default:
                    return Ok(response.ToList());
            }
        }

        /// <summary>
        /// Description : To get a user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetUserById/{id}")]
        public async Task<IActionResult> GetUserById(long id)
        {
            var response = await _userService.GetUserByIdAsync(id);

            switch (response)
            {
                case null:
                    return StatusCode(500);
                default:
                    return Ok(response);
            }
        }

        /// <summary>
        /// Description : To create a new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("CreateUser")]
        public async Task<IActionResult> CreateUser(User user)
        {
            if (user == null || user.UserId != 0)
                return BadRequest();

            var users = await _userService.GetAllUsersAsync();
            if (users != null && users.ToList().Any(x => x.UserId != user.UserId && x.UserName.ToLowerInvariant() == user.UserName.ToLowerInvariant()))
            {
                return Conflict();
            }

            var response = await _userService.CreateUser(user);

            switch (response)
            {
                case false:
                    return StatusCode(500);
                default:
                    return Ok(response);
            }
        }

        /// <summary>
        /// Description : To update a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser(User user)
        {
            if (user == null || user.UserId <= 0)
                return BadRequest();

            var users = await _userService.GetAllUsersAsync();
            if (users != null && users.ToList().Any(x => x.UserId != user.UserId &&  x.UserName.ToLowerInvariant() == user.UserName.ToLowerInvariant()))
            {
                return Conflict();
            }

            if (users != null && !users.ToList().Any(x => x.UserId == user.UserId))
            {
                return NotFound();
            }

            var response = await _userService.UpdateUser(user);

            switch (response)
            {
                case false:
                    return StatusCode(500);
                default:
                    return Ok(response);
            }
        }

        /// <summary>
        /// Description : To delete a user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            if (id <= 0)
                return BadRequest();

            var users = await _userService.GetAllUsersAsync();
            if (users != null || !users.ToList().Any(x => x.UserId != id))
            {
                return BadRequest();
            }

            var response = await _userService.DeleteUser(users.ToList().FirstOrDefault(x => x.UserId == id));

            switch (response)
            {
                case false:
                    return StatusCode(500);
                default:
                    return Ok(response);
            }
        }
    }
}
