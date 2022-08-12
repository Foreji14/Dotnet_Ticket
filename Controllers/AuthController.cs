using System;
using Microsoft.AspNetCore.Mvc;
using dotnet_ticket.Data;
using dotnet_ticket.Dtos;
using dotnet_ticket.Dtos.User;

namespace dotnet_ticket.Controllers
{
        [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;
        public AuthController(IAuthRepository authRepo)
        {
            _authRepo = authRepo;
        }
        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegisterDto request)
        {
            var response = await _authRepo.Register(request);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(request);
        }
        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(UserLoginDto request)
        {
            var response = await _authRepo.Login(request.Username, request.Password);

            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
