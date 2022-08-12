using System;

namespace dotnet_ticket.Dtos.User
{
    public class GetUserDto
    {
        public int Id { get; set; }
        public string Username { get; set; } 
        public string Name { get; set; } 
        public string Email { get; set; } 
        public string Address { get; set; } 
        public UserType UserType { get; set; } 
    }
}
