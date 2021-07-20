using System;
using System.Threading.Tasks;
using Dapper;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Dapper;
using Infrastructure.Settings;

namespace Infrastructure.Repositories.Dapper
{
    public class TokenRepository : DapperRepository , ITokenRepository
    {
        private class TokenForRepo : Token { public TokenForRepo() : base() {} }
        private const string TableName = "Token";
        public TokenRepository(DatabaseSettings databaseSettings)
            : base(databaseSettings) {}

        public async Task<Token> GetAsync(Guid id)
        {
            var sql = $"SELECT * FROM {TableName} WHERE Id = @Id";
            
            using(var conn = Connection)
            {
                return await conn.QueryFirstOrDefaultAsync<TokenForRepo>(sql, new {Id = id});
            }
        }

        public async Task<Token> GetByAccountIdAsync(Guid accountId)
        {
            var sql = $"SELECT * FROM {TableName} WHERE AccountId = @AccountId";
            
            using(var conn = Connection)
            {
                return await conn.QueryFirstOrDefaultAsync<TokenForRepo>(sql, new {AccountId = accountId});
            }
        }
        public async Task AddAsync(Token token)
        {
            var sql = $"INSERT INTO {TableName} (Id, AccountId, JWT, Expires) "
                    +  "VALUES (@Id, @AccountId, @JWT, @Expires)";

            using(var conn = Connection)
            {
                await conn.ExecuteAsync(sql,
                new {
                    Id = token.Id,
                    AccountId = token.AccountId,
                    JWT = token.JWT,
                    Expires = token.Expires
                });
            }
        }

        public async Task OverrideAsync(Token token)
        {
            var sql = $"UPDATE {TableName} "
                    +  "SET Id = @Id,  JWT = @JWT, Expires = @Expires "
                    +  "WHERE AccountId = @AccountId;";

            using(var conn = Connection)
            {
                await conn.ExecuteAsync(sql,
                new {
                    Id = token.Id,
                    AccountId = token.AccountId,
                    JWT = token.JWT,
                    Expires = token.Expires
                });
            }

        }
    }
}