using System;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IAccountRepository : IRepository
    {
        Task<Account> GetAsync(Guid id);
        Task<Account> GetByEmailAsync(string email);
        Task<Account> GetByNameAsync(string name);
        Task<Account> GetAdminFirstOrDefaultAsync();
        Task AddAsync(Account account);
        Task UpdateAsync(Account account);
    }
}