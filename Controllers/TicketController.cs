using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using dotnet_ticket.Dtos.Ticket;
using dotnet_ticket.Services;
using dotnet_ticket.Ticket.Services;

namespace dotnet_ticket.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        public TicketController(ITicketService _ticketService)
        {
            this._ticketService = _ticketService;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetTicketDto>>>> Get()
        {
            return Ok(await _ticketService.GetAllTickets());

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetTicketDto>>> GetSingle(int id)
        {
            return Ok(await _ticketService.GetTicketById(id));

        }
        [HttpGet("GetTicketByStatus/{status}")]
        public async Task<ActionResult<ServiceResponse<GetTicketDto>>> GetTicketByStatus(int status)
        {
            return Ok(await _ticketService.GetTicketByStatus(status));

        }
        [HttpGet("GetTicketByPriority/{priority}")]
        public async Task<ActionResult<ServiceResponse<GetTicketDto>>> GetTicketByPriority(int priority)
        {
            return Ok(await _ticketService.GetTicketByPriority(priority));

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetTicketDto>>>> Delete(int id)
        {
            var response = await _ticketService.DeleteTicket(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetTicketDto>>>> AddTicket(AddTicketDto newTicket)
        {

            return Ok(await _ticketService.AddTicket(newTicket));
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetTicketDto>>> UpdateTicket(UpdateTicketDto updatedTicket)
        {
            var response = await _ticketService.UpdateTicket(updatedTicket);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}