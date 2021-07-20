using System;

namespace Application.DTOs.Accounts
{
    public class AccountDto
    {
        public Guid Id {get; set;}
        public string Email {get; set;}
        public string Name {get; set;}
        public string Role {get; set;}
        public DateTime CreatedAt {get; set;}
        public DateTime UpdatedAt {get; set;}
    }
}