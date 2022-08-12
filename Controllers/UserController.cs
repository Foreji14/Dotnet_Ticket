using dotnet_ticket.Dtos.User;
using dotnet_ticket.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_ticket.Controllers
{

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<ServiceResponse<List<GetUserDto>>>> GetAllUsers()
        {
            return Ok(await _userService.GetAllUsers());
        }
        [HttpPut("UpdateUser")]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> UpdateUser(UpdateUserDto updatedUser)
        {
            return Ok(await _userService.UpdateUser(updatedUser));
        }
    }
}