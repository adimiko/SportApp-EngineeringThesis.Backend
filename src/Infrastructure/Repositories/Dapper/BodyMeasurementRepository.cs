using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Dapper;
using Infrastructure.Settings;

namespace Infrastructure.Repositories.Dapper
{
    public class BodyMeasurementRepository : DapperRepository, IBodyMeasurementRepository
    {
        private class BodyMeasurementForRepo : BodyMeasurement { public BodyMeasurementForRepo() : base() {} }
        private const string TableName = "BodyMeasurement";
        public BodyMeasurementRepository(DatabaseSettings databaseSettings)
            :base(databaseSettings){}

        public async Task<BodyMeasurement> GetAsync(Guid id)
        {
            var sql = $"SELECT * FROM {TableName} WHERE Id = @Id";
            using(var conn = Connection)
            {
                return await conn.QueryFirstOrDefaultAsync<BodyMeasurementForRepo>(sql, new {Id = id});
            }
        }

        public async Task<IEnumerable<BodyMeasurement>> BrowseAsync(Guid accountId, int page, int perPage)
        {
            var sql = $"SELECT * FROM {TableName} WHERE AccountId = @AccountId "
                    +  "ORDER BY Date DESC "
                    +  "OFFSET @PageSize * (@Page - 1) ROWS "
                    +  "FETCH NEXT @PageSize ROWS ONLY";

            using(var conn = Connection)
            {
                return await conn.QueryAsync<BodyMeasurementForRepo>(sql,
                new {
                    Page = page,
                    PageSize = perPage, 
                    AccountId = accountId
                });
            }
        }
        public async Task AddAsync(BodyMeasurement bodyMeasurement)
        {
            var sql = $"INSERT INTO {TableName} (Id, AccountId, Date, Description, Weight, Height, Arm, Chest, Waist, Hip, Thigh, Calf, CreatedAt, UpdatedAt) "
                    +  "VALUES (@Id, @AccountId, @Date, @Description, @Weight, @Height, @Arm, @Chest, @Waist, @Hip, @Thigh, @Calf, @CreatedAt, @UpdatedAt)";

            using(var conn = Connection)
            {
                await conn.ExecuteAsync(sql,
                new {
                    Id = bodyMeasurement.Id,
                    AccountId = bodyMeasurement.AccountId,
                    Date = bodyMeasurement.Date,
                    Description = bodyMeasurement.Description,
                    Weight = bodyMeasurement.Weight,
                    Height = bodyMeasurement.Height,
                    Arm = bodyMeasurement.Arm,
                    Chest = bodyMeasurement.Chest,
                    Waist = bodyMeasurement.Waist,
                    Hip = bodyMeasurement.Hip,
                    Thigh = bodyMeasurement.Thigh,
                    Calf = bodyMeasurement.Calf,
                    CreatedAt = bodyMeasurement.CreatedAt,
                    UpdatedAt = bodyMeasurement.UpdatedAt
                });
            }
        }

        public async Task UpdateAsync(BodyMeasurement bodyMeasurement)
        {
            var sql = $"UPDATE {TableName} "
                    +  "SET Date = @Date, Description = @Description, Weight = @Weight, Height = @Height, Arm = @Arm, Chest = @Chest, Waist = @Waist, Hip = @Hip, Thigh = @Thigh, Calf = @Calf, UpdatedAt = @UpdatedAt "
                    +  "WHERE Id = @Id";

            using(var conn = Connection)
            {
                await conn.ExecuteAsync(sql,
                new {
                    Id = bodyMeasurement.Id,
                    Date = bodyMeasurement.Date,
                    Description = bodyMeasurement.Description,
                    Weight = bodyMeasurement.Weight,
                    Height = bodyMeasurement.Height,
                    Arm = bodyMeasurement.Arm,
                    Chest = bodyMeasurement.Chest,
                    Waist = bodyMeasurement.Waist,
                    Hip = bodyMeasurement.Hip,
                    Thigh = bodyMeasurement.Thigh,
                    Calf = bodyMeasurement.Calf,
                    UpdatedAt = bodyMeasurement.UpdatedAt
                });
            }
        }

        public async Task DeleteAsync(BodyMeasurement bodyMeasurement)
        {
            var sql = $"DELETE FROM {TableName} WHERE Id = @Id";

            using(var conn = Connection) await conn.ExecuteAsync(sql, new {Id = bodyMeasurement.Id});
        }
    }
}