using System;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface ITokenRepository : IRepository
    {
        Task<Token> GetAsync(Guid id);
        Task<Token> GetByAccountIdAsync(Guid accountId);
        Task AddAsync(Token token);
        Task OverrideAsync(Token token);
    }
}