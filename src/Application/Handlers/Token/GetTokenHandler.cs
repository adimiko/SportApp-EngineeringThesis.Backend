using System.Threading.Tasks;
using Application.DTOs.Tokens;
using Application.Queries;
using Application.Queries.Tokens;
using Application.Services.Interfaces;

namespace Application.Handlers.Token
{
    public class GetTokenHandler : IQueryHandler<GetToken, TokenDto>
    {
        private readonly IJwtService _jwtService;
        public GetTokenHandler(IJwtService jwtService)
        {
            _jwtService = jwtService;
        }
        public async Task<TokenDto> HandleAsync(GetToken query)
        {
            return await _jwtService.GetToken(query.TokenId);
        }
    }
}