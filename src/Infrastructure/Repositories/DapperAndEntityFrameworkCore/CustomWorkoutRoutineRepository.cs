using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Dapper;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Dapper;
using Infrastructure.EntityFrameworkCore;
using Infrastructure.Settings;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.DapperAndEntityFrameworkCore
{
    public class CustomWorkoutRoutineRepository : DapperRepository, ICustomWorkoutRoutineRepository, IDapperAndEntityFrameworkCoreRepository
    {

        private class CustomWorkoutRoutineForRepo : CustomWorkoutRoutine { public CustomWorkoutRoutineForRepo() : base() {} }
        private class ExerciseForRepo : Exercise { public ExerciseForRepo() : base() {} }
        private const string TableName = "CustomWorkoutRoutine";
        private readonly DatabaseContext _context;
        private readonly DbSet<CustomWorkoutRoutine> _entities;

        public CustomWorkoutRoutineRepository(DatabaseSettings databaseSettings, DatabaseContext context)
            :base(databaseSettings)
        {
            _context = context;
            _entities = context.Set<CustomWorkoutRoutine>();
        }

        public async Task<CustomWorkoutRoutine> GetAsync(Guid id)
        {
            var sqlCustomWorkoutRoutine = $"SELECT * FROM {TableName} WHERE Id = @Id";
            var sqlExercise = $"SELECT * FROM CustomExerciseRoutine WHERE CustomWorkoutRoutineId = @CustomWorkoutRoutineId ORDER BY [Order]";
            var sqlSet = $"SELECT * FROM CustomSetRoutine WHERE CustomExerciseRoutineId = @CustomExerciseRoutineId ORDER BY [Order]";
            using(var conn = Connection)
            {
                var customWorkoutRoutine = await conn.QueryFirstOrDefaultAsync<CustomWorkoutRoutineForRepo>(sqlCustomWorkoutRoutine, new {Id = id});

                if(customWorkoutRoutine == null) return null;

                var exercises = await conn.QueryAsync<ExerciseForRepo>(sqlExercise,
                new {
                    CustomWorkoutRoutineId = customWorkoutRoutine.Id
                });

                var protectedExercisesField = customWorkoutRoutine.GetType()
                .GetField("_exercises", BindingFlags.NonPublic | BindingFlags.Instance);

                protectedExercisesField.SetValue(customWorkoutRoutine, new HashSet<Exercise>(exercises));

                return customWorkoutRoutine;
            }
        }

        public async Task<CustomWorkoutRoutine> GetByNameAsync(string name)
        {
            var sqlCustomWorkoutRoutine = $"SELECT * FROM {TableName} WHERE Name = @Name";
            var sqlExercise = $"SELECT * FROM CustomExerciseRoutine WHERE CustomWorkoutRoutineId = @CustomWorkoutRoutineId ORDER BY [Order]";
            var sqlSet = $"SELECT * FROM CustomSetRoutine WHERE CustomExerciseRoutineId = @CustomExerciseRoutineId ORDER BY [Order]";
            using(var conn = Connection)
            {
                var customWorkoutRoutine = await conn.QueryFirstOrDefaultAsync<CustomWorkoutRoutineForRepo>(sqlCustomWorkoutRoutine, new {Name = name});

                if(customWorkoutRoutine == null) return null;

                var exercises = await conn.QueryAsync<ExerciseForRepo>(sqlExercise,
                new {
                    CustomWorkoutRoutineId = customWorkoutRoutine.Id
                });

                var protectedExercisesField = customWorkoutRoutine.GetType()
                .GetField("_exercises", BindingFlags.NonPublic | BindingFlags.Instance);

                protectedExercisesField.SetValue(customWorkoutRoutine, new HashSet<Exercise>(exercises));

                return customWorkoutRoutine;
            }
        }
        public async Task<IEnumerable<CustomWorkoutRoutine>> BrowseWithoutArchiveAsync(Guid accountId, int page, int perPage)
            => await BrowseAsync(accountId, page, perPage);

        public async Task<IEnumerable<CustomWorkoutRoutine>> BrowseArchiveAsync(Guid accountId, int page, int perPage)
            => await BrowseAsync(accountId, page, perPage, true);

        public async Task AddAsync(CustomWorkoutRoutine customWorkoutRoutine)
        {
            await _entities.AddAsync(customWorkoutRoutine);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CustomWorkoutRoutine customWorkoutRoutine)
        {
            _entities.Update(customWorkoutRoutine);
            await _context.SaveChangesAsync();
        }


        private async Task<IEnumerable<CustomWorkoutRoutine>> BrowseAsync(Guid accountId, int page, int perPage, bool browseArchive = false)
        {
            var sql = $@"SELECT * FROM {TableName} WHERE AccountId = @AccountId AND IsArchived = @IsArchived 
                         ORDER BY Name
                         OFFSET @PageSize * (@Page - 1) ROWS 
                         FETCH NEXT @PageSize ROWS ONLY";

            using(var conn = Connection)
            {
                return await conn.QueryAsync<CustomWorkoutRoutineForRepo>(sql,
                new 
                {
                    Page = page,
                    PageSize = perPage,
                    AccountId = accountId, 
                    IsArchived = browseArchive
                });
            }
        }
    }
}