using System;
using Application.DTOs.Accounts;

namespace Application.Queries.Account
{
    public class GetAccount  : IQuery<AccountDto>
    {
        public Guid AccountId {get; set;}
    }
}