using System;

namespace dotnet_ticket.Dtos.User
{
    public class UserLoginDto
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}

