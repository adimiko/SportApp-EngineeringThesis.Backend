using Application.DTOs.Tokens;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper.Configurations
{
    public static class TokenConfiguration
    {
        public static void CreateMapForToken(this IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Token, TokenDto>();
        }
    }
}