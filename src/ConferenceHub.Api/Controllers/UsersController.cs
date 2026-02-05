using ConferenceHub.Api.DTOs.Request;
using ConferenceHub.Api.DTOs.Response;
using ConferenceHub.Api.Mappings;
using ConferenceHub.Application.Services;
using ConferenceHub.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceHub.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;
        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return Ok(await _userService.GetAllUsers());
        }

        [HttpGet("{userId:guid}")]
        public async Task<IActionResult> GetUserById(
            [FromRoute] Guid userId)
        {
            return Ok(await _userService.GetUserByPublicId(userId));
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateUserRequest createUserRequest)
        {
            var user = createUserRequest.ToDomain();
            var id = await _userService.CreateUser(user);

            return Ok(id);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(
            [FromBody] UpdateUserRequest updateUserRequest)
        {
            await _userService.UpdateUser(updateUserRequest.ToDomain());
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveUser(
            [FromBody] Guid userId)
        {
            await _userService.DeleteUser(userId);

            return Ok();
        }
    }
}
