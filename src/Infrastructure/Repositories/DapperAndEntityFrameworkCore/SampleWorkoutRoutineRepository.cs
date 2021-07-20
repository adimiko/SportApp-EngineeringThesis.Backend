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
    public class SampleWorkoutRoutineRepository : DapperRepository, ISampleWorkoutRoutineRepository, IDapperAndEntityFrameworkCoreRepository
    {
        private class SampleWorkoutRoutineForRepo : SampleWorkoutRoutine { public SampleWorkoutRoutineForRepo() : base() {} }
        private class ExerciseForRepo : Exercise { public ExerciseForRepo() : base() {} }
        private const string TableName = "SampleWorkoutRoutine";
        private readonly DatabaseContext _context;
        private readonly DbSet<SampleWorkoutRoutine> _entities;

        public SampleWorkoutRoutineRepository(DatabaseSettings databaseSettings, DatabaseContext context)
            :base(databaseSettings)
        {
            _context = context;
            _entities = context.Set<SampleWorkoutRoutine>();
        }

        public async  Task<SampleWorkoutRoutine> GetAsync(Guid id)
        {
            var sqlWorkoutRoutine = $"SELECT * FROM {TableName} WHERE Id = @Id";
            var sqlExercise = $"SELECT * FROM SampleExerciseRoutine WHERE SampleWorkoutRoutineId = @SampleWorkoutRoutineId ORDER BY [Order]";

            using(var conn = Connection)
            {
                var sampleWorkoutRoutine = await conn.QueryFirstOrDefaultAsync<SampleWorkoutRoutineForRepo>(sqlWorkoutRoutine, new {Id = id});

                if(sampleWorkoutRoutine == null) return null;

                var exercises = await conn.QueryAsync<ExerciseForRepo>(sqlExercise,
                new {
                    sampleWorkoutRoutineId = sampleWorkoutRoutine.Id
                });

                var protectedExercisesField = sampleWorkoutRoutine.GetType()
                .GetField("_exercises", BindingFlags.NonPublic | BindingFlags.Instance);

                protectedExercisesField.SetValue(sampleWorkoutRoutine, new HashSet<Exercise>(exercises));

                return sampleWorkoutRoutine;
            }
        }

        public async Task<SampleWorkoutRoutine> GetByNameAsync(string name)
        {
            var sqlWorkoutRoutine = $"SELECT * FROM {TableName} WHERE Name = @Name";
            var sqlExercise = $"SELECT * FROM SampleExerciseRoutine WHERE SampleWorkoutRoutineId = @SampleWorkoutRoutineId";

            using(var conn = Connection)
            {
                var sampleWorkoutRoutine = await conn.QueryFirstOrDefaultAsync<SampleWorkoutRoutineForRepo>(sqlWorkoutRoutine, new {Name = name});

                if(sampleWorkoutRoutine == null) return null;

                var exercises = await conn.QueryAsync<ExerciseForRepo>(sqlExercise,
                new {
                    SampleWorkoutRoutineId = sampleWorkoutRoutine.Id
                });


                var protectedExercisesField = sampleWorkoutRoutine.GetType()
                .GetField("_exercises", BindingFlags.NonPublic | BindingFlags.Instance);

                protectedExercisesField.SetValue(sampleWorkoutRoutine, new HashSet<Exercise>(exercises));

                return sampleWorkoutRoutine;
            }
        }

        public async Task<IEnumerable<SampleWorkoutRoutine>> BrowseWithoutArchiveAsync(int page, int perPage)
            => await BrowseAsync(page, perPage);

        public async Task<IEnumerable<SampleWorkoutRoutine>> BrowseArchiveAsync(int page, int perPage)
            => await BrowseAsync(page, perPage, true);

        public async Task AddAsync(SampleWorkoutRoutine sampleWorkoutRoutine)
        {
            await _entities.AddAsync(sampleWorkoutRoutine);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SampleWorkoutRoutine sampleWorkoutRoutine)
        {
            _entities.Update(sampleWorkoutRoutine);
            await _context.SaveChangesAsync();
        }

        private async Task<IEnumerable<SampleWorkoutRoutine>> BrowseAsync(int page, int perPage, bool browseArchive = false)
        {
            var sql = $@"SELECT * FROM {TableName} WHERE IsArchived = @IsArchived 
                         ORDER BY Name
                         OFFSET @PageSize * (@Page - 1) ROWS 
                         FETCH NEXT @PageSize ROWS ONLY";

            using(var conn = Connection)
            {
                return await conn.QueryAsync<SampleWorkoutRoutineForRepo>(sql,
                new 
                {
                    Page = page,
                    PageSize = perPage, 
                    IsArchived = browseArchive
                });
            }
        }
    }
}