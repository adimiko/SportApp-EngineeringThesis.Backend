using System;
using Application.DTOs.Tokens;

namespace Application.Queries.Tokens
{
    public class GetToken : IQuery<TokenDto>
    {
        public Guid TokenId {get; set;}
    }
}