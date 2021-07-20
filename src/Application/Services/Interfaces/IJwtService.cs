using System;
using System.Threading.Tasks;
using Application.DTOs.Tokens;

namespace Application.Services.Interfaces
{
    public interface IJwtService : IService
    {
        Task<TokenDto> GetToken(Guid id);
        Task CreateOrUseValidToken(Guid id, Guid accountId, string role);
    }
}