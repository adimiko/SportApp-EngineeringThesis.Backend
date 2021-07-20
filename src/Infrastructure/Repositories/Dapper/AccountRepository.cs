using Dapper;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Settings;
using Domain.Common;
using Infrastructure.Dapper;
using System;

namespace Infrastructure.Repositories.Dapper
{
    public class AccountRepository : DapperRepository, IAccountRepository
    {
        private class AccountForRepo : Account { public AccountForRepo() : base() {} }
        private const string TableName = "Account";
        public AccountRepository(DatabaseSettings databaseSettings)
            :base(databaseSettings){ }


        public async Task<Account> GetAsync(Guid id)
        {
            var sql = $"SELECT * FROM {TableName} WHERE Id = @Id";
            
            using(var conn = Connection)
            {
                return await conn.QueryFirstOrDefaultAsync<AccountForRepo>(sql, new {Id = id});
            }
        }

        public async Task<Account> GetByEmailAsync(string email)
        {
            var sql = $"SELECT * FROM {TableName} WHERE Email = @Email";
            
            using(var conn = Connection)
            {
                return await conn.QueryFirstOrDefaultAsync<AccountForRepo>(sql, new {Email = email});
            }
        }

        public async Task<Account> GetByNameAsync(string name)
        {
            var sql = $"SELECT * FROM {TableName} WHERE LOWER(Name) = @Name";
            
            using(var conn = Connection)
            { 
                return await conn.QueryFirstOrDefaultAsync<AccountForRepo>(sql, new {Name = name.ToLowerInvariant()});
            }
        }
        public async Task<Account> GetAdminFirstOrDefaultAsync()
        {
            var sql = $"SELECT * FROM {TableName} WHERE Role = @Role";

            using(var conn = Connection)
            {
                return await conn.QueryFirstOrDefaultAsync<AccountForRepo>(sql, new {Role = Roles.Admin});
            }
        }
        public async Task AddAsync(Account account)
        {
            var sql = $"INSERT INTO {TableName} (Id, Email, Name, Password, Salt, Role, IsDeleted, DeletedAt, CreatedAt, UpdatedAt) "
                    +  "VALUES (@Id, @Email, @Name, @Password, @Salt, @Role, @IsDeleted, @DeletedAt, @CreatedAt, @UpdatedAt)";

            using(var conn = Connection)
            {
                await conn.ExecuteAsync(sql,
                new {
                    Id = account.Id,
                    Email = account.Email,
                    Name = account.Name,
                    Password = account.Password,
                    Salt = account.Salt,
                    Role = account.Role,
                    IsDeleted = account.IsDeleted,
                    DeletedAt = account.DeletedAt,
                    CreatedAt = account.CreatedAt,
                    UpdatedAt = account.UpdatedAt
                });
            }
        }

        public async Task UpdateAsync(Account account)
        {
            var sql = $"UPDATE {TableName} "
                    + "SET Email = @Email, Name = @Name, Password = @Password, Salt = @Salt, IsDeleted = @IsDeleted, DeletedAt = @DeletedAt, UpdatedAt = @UpdatedAt "
                    + "WHERE Id = @Id";

            using(var conn = Connection)
            {
                await conn.ExecuteAsync(sql,
                new {
                    Id = account.Id,
                    Email = account.Email,
                    Name = account.Name,
                    Password = account.Password,
                    Salt = account.Salt,
                    IsDeleted = account.IsDeleted,
                    DeletedAt = account.DeletedAt,
                    UpdatedAt = account.UpdatedAt
                });
            }
        }
    }
}