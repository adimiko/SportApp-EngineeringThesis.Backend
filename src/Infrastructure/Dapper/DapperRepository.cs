using System.Data;
using Infrastructure.Settings;
using Microsoft.Data.SqlClient;

namespace Infrastructure.Dapper
{
    public abstract class DapperRepository : IDapperRepository
    {
        private readonly string _connectionString;
        protected IDbConnection Connection => new SqlConnection(_connectionString);
        public DapperRepository(DatabaseSettings databaseSettings)
            => _connectionString = databaseSettings.ConnectionString;
    }
}