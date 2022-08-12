using System.Security.Claims;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using dotnet_ticket.Data;
using dotnet_ticket.Ticket.Services;
using dotnet_ticket.Dtos.Ticket;
using System.Linq;
using dotnet_ticket.Models;

namespace dotnet_ticket.Services.Ticket.TicketService
{
    public class TicketService : ITicketService
    {

        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TicketService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {

            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User
            .FindFirstValue(ClaimTypes.NameIdentifier));

        public async Task<ServiceResponse<List<GetTicketDto>>> AddTicket(AddTicketDto newTicket)
        {
            var serviceResponse = new ServiceResponse<List<GetTicketDto>>();
            var User = await _context.Users
            .Include(c => c.UserType)
            .FirstOrDefaultAsync(c => c.Id == GetUserId());
            if (User != null)
            {

                if (User.UserType.Name == "Admin")
                {
                    if (newTicket.Date < DateTime.Today)
                    {
                        serviceResponse.Success = false;
                        serviceResponse.Message = "The Due Date cannot be set in the past.";
                        return serviceResponse;
                    }
                    var priority = await _context.Priorities.FirstOrDefaultAsync(x => x.IdPriority == newTicket.IdPriority);
                    var status = await _context.Statuses.FirstOrDefaultAsync(x => x.IdStatus == newTicket.IdStatus);
                    Models.Ticket ticket = _mapper.Map<Models.Ticket>(newTicket);
                    ticket.Owner = User;
                    ticket.Worker = await _context.Users.FirstOrDefaultAsync(c => c.Id == newTicket.IdWorker);
                    ticket.Status = status;
                    ticket.Priority = priority;
                    _context.Tickets.Add(ticket);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.Tickets
                    .Include(c => c.Owner).ThenInclude(a => a.UserType)
                    .Include(c => c.Worker).ThenInclude(a => a.UserType)
                    .Include(c => c.Status)
                    .Include(c => c.Priority)
                    .Select(c => _mapper.Map<GetTicketDto>(c)).ToListAsync();
                }
                else
                {
                    serviceResponse.Message = "You are not an admin.";
                    serviceResponse.Success = false;
                }
            }
            return serviceResponse;
        }


        public async Task<ServiceResponse<List<GetTicketDto>>> DeleteTicket(int id)
        {

            var response = new ServiceResponse<List<GetTicketDto>>();
            try
            {
                Models.Ticket Ticket = await _context.Tickets
                .FirstOrDefaultAsync(c => c.Id == id);
                if (Ticket != null)
                {
                    var User = await _context.Users
                    .Include(c => c.UserType)
                    .FirstOrDefaultAsync(c => c.Id == GetUserId());
                    if (User != null)
                    {
                        if (User.UserType.Name == "Admin")
                        {
                            _context.Tickets.Remove(Ticket);
                            await _context.SaveChangesAsync();
                            response.Data = await _context.Tickets
                            .Select(c => _mapper.Map<GetTicketDto>(c)).ToListAsync();

                        }
                        else
                        {
                            response.Success = false;
                            response.Message = "YOU ARE NOT WORTHY!";
                        }

                    }
                    
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetTicketDto>>> GetAllTickets()
        {

            var response = new ServiceResponse<List<GetTicketDto>>();
            var User = await _context.Users
            .Include(c => c.UserType)
            .FirstOrDefaultAsync(c => c.Id == GetUserId());
            if (User != null)
            {
                if (User.UserType.Name == "Admin")
                {
                    response.Data = await _context.Tickets
                    .Include(c => c.Owner).ThenInclude(a => a.UserType)
                    .Include(c => c.Worker).ThenInclude(a => a.UserType)
                    .Include(c => c.Status)
                    .Include(c => c.Priority)
                    .Select(c => _mapper.Map<GetTicketDto>(c)).ToListAsync();
                }
                else
                {
                    response.Data = await _context.Tickets
                    .Include(c => c.Owner).ThenInclude(a => a.UserType)
                    .Include(c => c.Worker).ThenInclude(a => a.UserType)
                    .Include(c => c.Status)
                    .Include(c => c.Priority)
                    .Where(c => c.WorkerId == GetUserId())
                    .Select(c => _mapper.Map<GetTicketDto>(c)).ToListAsync();
                }
            }
            return response;
        }

public async Task<ServiceResponse<List<GetTicketDto>>> GetTicketsByWorkerId(int workerId)
        {
            var serviceResponse = new ServiceResponse<List<GetTicketDto>>();
            var User = await _context.Users
            .Include(c => c.UserType)
            .FirstOrDefaultAsync(c => c.Id == GetUserId());
            if (User != null)
            {
                if (User.UserType.Name == "Admin")
                {
                    var dbTicket = await _context.Tickets
                    .Include(c => c.Owner).ThenInclude(b => b.UserType)
                    .Include(c => c.Worker).ThenInclude(b => b.UserType)
                    .Include(c => c.Status)
                    .Include(c => c.Priority)
                    .Where(c => c.WorkerId == workerId)
                    .Select(c => _mapper.Map<GetTicketDto>(c)).ToListAsync();
                    serviceResponse.Data = dbTicket;
                    return serviceResponse;
                }
                
                  else
                        {
                            serviceResponse.Success = false;
                            serviceResponse.Message = "YOU ARE NOT WORTHY!";
                        }
                
            }
            return serviceResponse;

        }
        public async Task<ServiceResponse<GetTicketDto>> GetTicketById(int id)
        {
            var serviceResponse = new ServiceResponse<GetTicketDto>();
            var User = await _context.Users
            .Include(c => c.UserType)
            .FirstOrDefaultAsync(c => c.Id == GetUserId());
            if (User != null)
            {
                if (User.UserType.Name == "Admin")
                {
                    var dbTicket = await _context.Tickets
                    .Include(c => c.Owner).ThenInclude(b => b.UserType)
                    .Include(c => c.Worker).ThenInclude(b => b.UserType)
                    .Include(c => c.Status)
                    .Include(c => c.Priority)
                    .FirstOrDefaultAsync(c => c.Id == id);
                    serviceResponse.Data = _mapper.Map<GetTicketDto>(dbTicket);
                    return serviceResponse;
                }
                else
                {
                    var dbTicket = await _context.Tickets
                    .Include(c => c.Owner).ThenInclude(b => b.UserType)
                    .Include(c => c.Worker).ThenInclude(b => b.UserType)
                    .Include(c => c.Status)
                    .Include(c => c.Priority)
                    .FirstOrDefaultAsync(c => c.Id == id && c.Worker.Id == User.Id);
                    serviceResponse.Data = _mapper.Map<GetTicketDto>(dbTicket);
                    return serviceResponse;
                }
            }
            return serviceResponse;

        }
        public async Task<ServiceResponse<List<GetTicketDto>>> GetTicketByStatus(int status)
        {
            var serviceResponse = new ServiceResponse<List<GetTicketDto>>();
            var User = await _context.Users
            .Include(c => c.UserType)
            .FirstOrDefaultAsync(c => c.Id == GetUserId());
            if (User != null)
            {
                if (User.UserType.Name == "Admin")
                {
                    var dbTicket = await _context.Tickets
                    .Include(c => c.Owner).ThenInclude(b => b.UserType)
                    .Include(c => c.Worker).ThenInclude(b => b.UserType)
                    .Include(c => c.Status)
                    .Include(c => c.Priority)
                    .Where(c => c.StatusId == status).Select(c => _mapper.Map<GetTicketDto>(c)).ToListAsync();
                    serviceResponse.Data = dbTicket;
                    return serviceResponse;
                }
        
            }
            return serviceResponse;

        }
        public async Task<ServiceResponse<List<GetTicketDto>>> GetTicketByPriority(int priority)
        {
            var serviceResponse = new ServiceResponse<List<GetTicketDto>>();
            var User = await _context.Users
            .Include(c => c.UserType)
            .FirstOrDefaultAsync(c => c.Id == GetUserId());
            if (User != null)
            {
                if (User.UserType.Name == "Admin")
                {
                    var dbTicket = await _context.Tickets
                    .Include(c => c.Owner).ThenInclude(b => b.UserType)
                    .Include(c => c.Worker).ThenInclude(b => b.UserType)
                    .Include(c => c.Status)
                    .Include(c => c.Priority)
                    .Where(c => c.PriorityId == priority).Select(c => _mapper.Map<GetTicketDto>(c)).ToListAsync();
                    serviceResponse.Data = dbTicket;
                    return serviceResponse;
                }
        
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetTicketDto>> UpdateTicket(UpdateTicketDto updatedTicket)
        {
            ServiceResponse<GetTicketDto> response = new ServiceResponse<GetTicketDto>();

            try
            {
                var Ticket = await _context.Tickets
                    .FirstOrDefaultAsync(c => c.Id == updatedTicket.Id);
                var User = await _context.Users
                .Include(c => c.UserType)
                .FirstOrDefaultAsync(c => c.Id == GetUserId());

                if (User != null)
                {
                     if (updatedTicket.Date < DateTime.Today)
                    {
                        response.Success = false;
                        response.Message = "The Due Date cannot be set in the past.";
                        return response;
                    }
                    
                    if (User.UserType.Name == "Admin")
                    {
                        var worker = await _context.Users.FirstOrDefaultAsync(c => c.Id == updatedTicket.IdWorker);
                        Ticket.Name = updatedTicket.Name;
                        var status = await _context.Statuses.FirstOrDefaultAsync(c => c.IdStatus == updatedTicket.IdStatus);
                        var priority = await _context.Priorities.FirstOrDefaultAsync(c => c.IdPriority == updatedTicket.IdPriority);
                        Ticket.Description = updatedTicket.Description;
                        Ticket.Worker = worker;
                        Ticket.Status = status;
                        Ticket.Priority = priority;
                        Ticket.Date = updatedTicket.Date;

                        await _context.SaveChangesAsync();

                        response.Data = _mapper.Map<GetTicketDto>(Ticket);
                    }
                    else
                    {
                        var status = await _context.Statuses.FirstOrDefaultAsync(c => c.IdStatus == updatedTicket.IdStatus);
                        Ticket.Status = status;
                        await _context.SaveChangesAsync();
                        response.Data = _mapper.Map<GetTicketDto>(Ticket);
                    }
                }
                else
                {
                    response.Success = false;
                    response.Message = "Ticket not found.";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        

        



    }
}