using System;

namespace dotnet_ticket.Dtos.User
{
    public class UpdateUserDto
    {
        public string Username { get; set; } // 
        public string Name { get; set; } // Daca se casatoreste
        public string Email { get; set; } // Daca isi pierde e-mail ul
        public string Address { get; set; } // Daca se muta
        public string Password { get; set; }
    }
}
