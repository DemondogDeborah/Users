using ErrorOr;
using LoginMongoAPI.Interfaces;
using LoginMongoAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace LoginMongoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserInterface _service;

        public UsersController(UserContext context, UserInterface service)
        {
            _service = service;
        }


        // GET: api/getUsers 
        [HttpGet("getUsers")]
        public async Task<IActionResult> GetAll()
        {
            List<User> userList = await _service.GetAll();

            if (userList == null || userList.Count == 0)
            {
                return NotFound();
            }

            return Ok(userList);
        }


        // GET: api/getUserById/:id
        [HttpGet("getUserById/{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            ErrorOr<User> getUserResult = await _service.GetUser(id);

            if (getUserResult.Value == null)
            {
                return BadRequest();
            }

            return Ok(getUserResult.Value);
        }


        // PUT: api/updateUser
        [HttpPut("updateUser")]
        public async Task<IActionResult> UpdateUser(User user)
        {

            try
            {
                ErrorOr<User> updateUserResult = await _service.UpdateUser(user.Id,
                                                                           user.Name,
                                                                           user.Email,
                                                                           user.Username,
                                                                           user.Password);
                return Ok(updateUserResult.Value);
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Error to update user: " + ex.Message);
            }
        }


        // POST: api/postUser
        [HttpPost("postUser")]
        public async Task<IActionResult> User(User user)
        {
            ErrorOr<User> createUserResult = await _service.CreateUser(user.Name,
                                                                       user.Email,
                                                                       user.Username,
                                                                       user.Password);

            return Ok(createUserResult.Value);
        }


        // DELETE: api/deleteUser/:id
        [HttpDelete("deleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {

            try
            {
                ErrorOr<string> deleteUserResult = await _service.DeleteUser(id);
                return Ok(deleteUserResult.Value);
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Error to delete user: " + ex.Message);
            }
        }
    }
}
