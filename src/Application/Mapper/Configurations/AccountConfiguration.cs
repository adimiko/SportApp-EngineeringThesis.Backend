using Application.DTOs.Accounts;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper.Configurations
{
    public static class AccountConfiguration
    {
        public static void CreateMapForAccount(this IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Account, AccountDto>();
        }
    }
}