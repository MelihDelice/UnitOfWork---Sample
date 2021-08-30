using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PocketBook.Core.IConfiguration;
using PocketBook.Data;
using PocketBook.Models;
//using PocketBook.Models;

namespace PocketBook.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UserController> _logger;
        public UserController(IUnitOfWork unitOfWork, ILogger<UserController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<IActionResult> CreateUser(User user)
        {
            if (ModelState.IsValid)
            {
                user.Id = Guid.NewGuid();
                await _unitOfWork.Users.AddAsync(user);
                await _unitOfWork.CompleteAsync();
                return CreatedAtAction("GetItem", new { user.Id }, user);
            }
            return new JsonResult("Something went wrong") { StatusCode = 500 };
        }
        [HttpGet]
        [Route("GetItem")]
        public async Task<IActionResult> GetItem(Guid id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(user);
            }

        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get()
        {
            var users = _unitOfWork.Users.AllAsync();
            return Ok(users);
        }

    }
}