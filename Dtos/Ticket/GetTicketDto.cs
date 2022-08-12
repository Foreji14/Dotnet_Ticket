using System;
using dotnet_ticket.Dtos.User;

namespace dotnet_ticket.Dtos.Ticket
{
    public class GetTicketDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public GetUserDto Owner { get; set; }
        public GetUserDto Worker { get; set; }
        public Status Status { get; set; } 
        public Priority Priority { get; set; }

    }
}
