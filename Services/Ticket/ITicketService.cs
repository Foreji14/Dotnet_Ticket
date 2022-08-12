using System;

using dotnet_ticket.Dtos.Ticket;

namespace dotnet_ticket.Ticket.Services
{
    public interface ITicketService
    {
        Task<ServiceResponse<List<GetTicketDto>>> AddTicket(AddTicketDto newTicket);
        Task<ServiceResponse<GetTicketDto>> UpdateTicket(UpdateTicketDto updatedTicket);
        Task<ServiceResponse<List<GetTicketDto>>> DeleteTicket(int id_ticket);
        Task<ServiceResponse<GetTicketDto>> GetTicketById(int id_ticket);
        Task<ServiceResponse<List<GetTicketDto>>> GetTicketByStatus(int Status);
        Task<ServiceResponse<List<GetTicketDto>>> GetTicketByPriority(int Priority);
        Task<ServiceResponse<List<GetTicketDto>>> GetAllTickets();


    }
}
