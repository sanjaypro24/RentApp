using Microsoft.AspNetCore.Mvc;
using RentApp.Models.ViewModel;
using RentApp.Services.Interface;

namespace RentApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

    
         private readonly IUserServices _userService;
        public UserController(IUserServices userService)
        {
            _userService = userService;
        }
        [HttpGet("getAll")]

        public async Task<IActionResult> GetAll()
        {
            List<UserModel> users = await _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("getById/{{id}}")]

        public IActionResult GetById(Guid id)
        {

            UserModel users = _userService.GetById(id);
            return Ok(users);
        }
        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] UserModel userModel)
        {
            if (userModel == null)
            {
                return BadRequest("User data is required.");
            }
            UserModel createdUser = await _userService.CreateUser(userModel);
            return CreatedAtAction(nameof(GetById), new { id = createdUser.Id }, createdUser);
        }
        [HttpDelete("deleteById/{{id}}")]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            bool isDeleted = await _userService.DeleteById(id);
            if (!isDeleted)
            {
                return NotFound("User not found.");
            }
            return NoContent();
        }

    }
   
}
