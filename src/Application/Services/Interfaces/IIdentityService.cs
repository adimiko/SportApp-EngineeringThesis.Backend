using System;
using System.Threading.Tasks;
using Application.DTOs.Accounts;

namespace Application.Services.Interfaces
{
    public interface IIdentityService : IService
    {
        Task LoginAsync(string email, string password);
        Task RegisterAsync(Guid id, string email, string username, string password, string confirmPassword, string role);
    }
}