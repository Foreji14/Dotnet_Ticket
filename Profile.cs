using System;
using dotnet_ticket.Dtos.Ticket;
using dotnet_ticket.Dtos.User;

namespace dotnet_ticket
{
    public class Profile : AutoMapper.Profile
    {
        public Profile()
        {
            CreateMap<Models.Ticket, GetTicketDto>();
            CreateMap<Models.User, GetUserDto>();
            CreateMap<AddTicketDto, Models.Ticket>();
            CreateMap<AddUserDto, Models.User>();
        }
    }
}
