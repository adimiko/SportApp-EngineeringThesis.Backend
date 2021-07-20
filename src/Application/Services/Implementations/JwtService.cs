using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Tokens;
using Application.Exceptions;
using Application.Services.Interfaces;
using Application.Settings;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Extensions;
using Domain.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services.Implementations
{
    public class JwtService : IJwtService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly ITokenRepository _tokenRepository;
        private readonly IMapper _mapper;
        public JwtService(JwtSettings jwtSettings, ITokenRepository tokenRepository, IMapper mapper)
        {
            _jwtSettings = jwtSettings;
            _tokenRepository = tokenRepository;
            _mapper = mapper;
        }

        public async Task<TokenDto> GetToken(Guid id)
            => _mapper.Map<TokenDto>(await _tokenRepository.GetAsync(id));

        public async Task CreateOrUseValidToken(Guid id, Guid accountId, string role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.SecretKey));
            var expires = DateTime.UtcNow.Add(_jwtSettings.TokenLifeTime);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new []
                {
                    new Claim(JwtRegisteredClaimNames.Sub, accountId.ToString()),
                    new Claim(JwtRegisteredClaimNames.UniqueName, accountId.ToString()),
                    new Claim(ClaimTypes.Role, role),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Expires = expires,
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            };

            var jwtToken = tokenHandler.CreateToken(tokenDescriptor);


            var token = await _tokenRepository.GetByAccountIdAsync(accountId);

            if(token == null)
            {
                try
                {
                    var newToken = new Token(id, accountId, tokenHandler.WriteToken(jwtToken), expires);
                    await _tokenRepository.AddAsync(newToken);
                }
                catch(InvalidIdException e)
                {
                    throw new InternalException(e.Code, e.Message, e);
                }
                catch(InvalidJwtException e)
                {
                    throw new InternalException(e.Code, e.Message, e);
                }
                catch(InvalidTokenExpiresException e)
                {
                    throw new InternalException(e.Code, e.Message, e);
                }

            }
            else
            {
                if(token.Expires > DateTime.UtcNow)
                {
                    token.SetId(id);
                    await _tokenRepository.OverrideAsync(token);
                }
                else
                {
                    var newToken = new Token(id, accountId, tokenHandler.WriteToken(jwtToken), expires);
                    await _tokenRepository.OverrideAsync(newToken);
                }
            }
        }
    }
}