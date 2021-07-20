using System;
using System.Threading.Tasks;
using Application.DTOs.Accounts;

namespace Application.Services.Interfaces
{
    public interface IAccountManagementService : IService
    {
        Task<AccountDto> GetAsync(Guid accountId);
        Task<AccountDto> GetByEmailAsync(string email);
        Task ChangePasswordAsync(Guid accountId, string oldPassword, string newPassword, string confirmNewPassword);
        Task DeleteAsync(Guid accountId);
    }
}