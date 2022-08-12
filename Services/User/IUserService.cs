using System;
using dotnet_ticket.Dtos.User;
namespace dotnet_ticket.Services.User
{
    public interface IUserService
    {

        Task<ServiceResponse<List<GetUserDto>>> GetAllUsers ();
        Task<ServiceResponse<GetUserDto>> UpdateUser (UpdateUserDto updatedUser );
    }
}
