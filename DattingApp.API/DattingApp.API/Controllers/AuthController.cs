using DattingApp.API.Data;
using DattingApp.API.Dtos;
using DattingApp.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DattingApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repos;

        public AuthController(IAuthRepository repos)
        {
            _repos = repos;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegister)
        {
            // validate request 

            userForRegister.Username = userForRegister.Username.ToLower();

            if (await _repos.UserExists(userForRegister.Username))
                return BadRequest("Username already exists");

            var userToCreate = new User
            {
                Username = userForRegister.Username
            };

            var createdUser = await _repos.Register(userToCreate, userForRegister.Password);

            return StatusCode(201);
        }

    }

}
