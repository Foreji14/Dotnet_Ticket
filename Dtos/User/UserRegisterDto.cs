using System;

namespace dotnet_ticket.Dtos.User
{
    public class UserRegisterDto
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Name { get; set; }
        public string Email { get; set; }
        public string EmailConfirmation { get; set; }
        public string Address { get; set; }
        
    }

}
