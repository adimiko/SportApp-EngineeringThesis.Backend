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
    public class ExerciseInfoRepository : DapperRepository, IExerciseInfoRepository
    {
        private class ExerciseInfoForRepo : ExerciseInfo { public ExerciseInfoForRepo() : base() {} }
        private const string TableName = "ExerciseInfo";
        public ExerciseInfoRepository(DatabaseSettings databaseSettings)
            : base(databaseSettings) { }
        public async Task<ExerciseInfo> GetAsync(Guid id)
        {
            var sql = $"SELECT * FROM {TableName} WHERE Id = @Id";
            using(var conn = Connection)
            {
                return await conn.QueryFirstOrDefaultAsync<ExerciseInfoForRepo>(sql, new {Id = id});
            }
        }
        public async Task<ExerciseInfo> GetByNameAsync(string name)
        {
            var sql = $"SELECT * FROM {TableName} WHERE LOWER(Name) = @Name";
            using(var conn = Connection)
            {
                return await conn.QueryFirstOrDefaultAsync<ExerciseInfoForRepo>(sql, new {Name = name.ToLowerInvariant()});
            }
        }

        public async Task<IEnumerable<ExerciseInfo>> BrowseWithoutArchiveAsync(int page, int perPage)
        {
            var sql = $"SELECT * FROM {TableName} WHERE IsArchived = @IsArchived "
                    +  "ORDER BY Name "
                    +  "OFFSET @PageSize * (@Page - 1) ROWS "
                    +  "FETCH NEXT @PageSize ROWS ONLY";

            using(var conn = Connection)
            {

                return await conn.QueryAsync<ExerciseInfoForRepo>(sql,
                new {
                    Page = page,
                    PageSize = perPage, 
                    IsArchived = false
                });
            }
        }

        public async Task<IEnumerable<ExerciseInfo>> BrowseArchiveAsync(int page, int perPage)
        {
            var sql = $"SELECT * FROM {TableName} WHERE IsArchived = @IsArchived "
                    +  "ORDER BY Name "
                    +  "OFFSET @PageSize * (@Page - 1) ROWS "
                    +  "FETCH NEXT @PageSize ROWS ONLY";

            using(var conn = Connection)
            {
                return await conn.QueryAsync<ExerciseInfoForRepo>(sql,
                new {
                    Page = page,
                    PageSize = perPage, 
                    IsArchived = true
                });
            }
        }
        public async Task AddAsync(ExerciseInfo exerciseInfo)
        {
            var sql = $"INSERT INTO {TableName} (Id, Name, Description, IsArchived, ArchiveDate, CreatedAt, UpdatedAt) "
                    +  "VALUES (@Id, @Name, @Description, @IsArchived, @ArchiveDate, @CreatedAt, @UpdatedAt)";

            using(var conn = Connection)
            {
                await conn.ExecuteAsync(sql,
                new {
                    Id = exerciseInfo.Id,
                    Name = exerciseInfo.Name,
                    Description = exerciseInfo.Description,
                    IsArchived = exerciseInfo.IsArchived,
                    ArchiveDate = exerciseInfo.ArchiveDate,
                    CreatedAt = exerciseInfo.CreatedAt,
                    UpdatedAt = exerciseInfo.UpdatedAt
                });
            }
        }

        public async Task UpdateAsync(ExerciseInfo exerciseInfo)
        {
            var sql = $"UPDATE {TableName} "
                    +  "SET Name = @Name, Description = @Description, IsArchived = @IsArchived, ArchiveDate = @ArchiveDate, UpdatedAt = @UpdatedAt "
                    +  "WHERE Id = @Id";

            using(var conn = Connection)
            {
                await conn.ExecuteAsync(sql,
                new {
                    Id = exerciseInfo.Id,
                    Name = exerciseInfo.Name,
                    Description = exerciseInfo.Description,
                    IsArchived = exerciseInfo.IsArchived,
                    ArchiveDate = exerciseInfo.ArchiveDate,
                    UpdatedAt = exerciseInfo.UpdatedAt
                });
            }
        }
    }
}