using System.Collections.Generic;
using System;
using dotnet_ticket.Dtos.User;

namespace dotnet_ticket.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(UserRegisterDto User);
        Task<ServiceResponse<string>> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}
