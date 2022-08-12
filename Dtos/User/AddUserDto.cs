using System;

namespace dotnet_ticket.Dtos.User
{
    public class AddUserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string UserType { get; set; }
    }
}
