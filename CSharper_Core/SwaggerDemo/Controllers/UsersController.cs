using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SwaggerDemo.Models;

namespace SwaggerDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string Get()
        {
            return "All users";
        }

        /// <summary>
        /// Get a specified user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<UserOut> Get(int id)
        {
            return new UserOut
            {
                Id = id
            };
        }

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="user">new user</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(User user)
        {
            return CreatedAtAction(nameof(Get), null);
        }

        /// <summary>
        /// Update the user info
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(string id)
        {
            return NoContent();
        }

        /// <summary>
        /// Delete a specified user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(string id)
        {
            return NoContent();
        }
    }
}