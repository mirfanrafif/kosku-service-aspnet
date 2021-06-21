using Kosku.Data.Entities;
using Kosku.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kosku.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            var users = _userRepository.getAll();
            return Ok(users);
        }

        [HttpPost("login")]
        public IActionResult login(UserRequest request)
        {
            var response = _userRepository.authenticate(request);

            if (response == null) return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }
    }
}
