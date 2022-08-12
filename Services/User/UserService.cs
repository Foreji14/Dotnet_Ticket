using System.Security.Claims;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using dotnet_ticket.Data;
using dotnet_ticket.Ticket.Services;
using System.Linq;
using dotnet_ticket.Models;
using dotnet_ticket.Dtos.User;

namespace dotnet_ticket.Services.User
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<ServiceResponse<List<GetUserDto>>> GetAllUsers()
        {
            var response = new ServiceResponse<List<GetUserDto>>();
            var user = await _context.Users
            .Include(c => c.UserType)
            .FirstOrDefaultAsync(x => x.Id == GetUserId());
            if (user != null)
            {
                if (user.UserType.Name == "Admin")
                {
                    response.Data = await _context.Users
                        .Include(x => x.UserType)
                        .Select(x => _mapper.Map<GetUserDto>(x))
                        .ToListAsync();
                }
                else
                {
                    response.Message = "YOU ARE NOT WORTHY!";
                    response.Success = false;
                }
            }
            return response;
        }

        public async Task<ServiceResponse<GetUserDto>> UpdateUser(UpdateUserDto updatedUser)
        {
            var response = new ServiceResponse<GetUserDto>();
            var user = await _context.Users
            .Include(c => c.UserType)
            .FirstOrDefaultAsync(x => x.Id == GetUserId());
            if (user != null)
            {

                user.Address = updatedUser.Address;
                user.Email = updatedUser.Email;
                user.Name = updatedUser.Email;
                user.Username = updatedUser.Username;

                CreatePasswordHash(updatedUser.Password, out byte[] PasswordHash, out byte[] PasswordSalt);

                user.PasswordHash = PasswordHash;
                user.PasswordSalt = PasswordSalt;

                await _context.SaveChangesAsync();
                response.Data = _mapper.Map<GetUserDto>(user);

            }
            else
            {
                response.Message = "User not connected or does not exist!";
                response.Success = false;
            }
            return response;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User
            .FindFirstValue(ClaimTypes.NameIdentifier));
    }
}
