using System;
using System.Collections.Generic;
using System.Linq;
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
    public class CompletedWorkoutRepository : DapperRepository, ICompletedWorkoutRepository, IDapperAndEntityFrameworkCoreRepository
    {
        private class CompletedWorkoutForRepo : CompletedWorkout { public CompletedWorkoutForRepo() : base() {} }
        private class ExerciseForRepo : CompletedExercise { public ExerciseForRepo() : base() {} }
        private class SetForRepo : CompletedSet { public SetForRepo() : base() {} }
        private const string TableName = "CompletedWorkout";
        private readonly DatabaseContext _context;
        private readonly DbSet<CompletedWorkout> _entities;

        public CompletedWorkoutRepository(DatabaseSettings databaseSettings, DatabaseContext context)
            :base(databaseSettings)
        {
            _context = context;
            _entities = context.Set<CompletedWorkout>();
        }

        public async Task<CompletedWorkout> GetAsync(Guid id)
        {
            var sqlCompletedWorkout = $"SELECT * FROM {TableName} WHERE Id = @Id";
            var sqlExercise = $"SELECT * FROM CompletedExercise WHERE CompletedWorkoutId = @CompletedWorkoutId ORDER BY [Order]";
            var sqlSet = $"SELECT * FROM CompletedSet WHERE CompletedExerciseId = @CompletedExerciseId ORDER BY [Order]";
            using(var conn = Connection)
            {
                var completedWorkout = await conn.QueryFirstOrDefaultAsync<CompletedWorkoutForRepo>(sqlCompletedWorkout, new {Id = id});

                if(completedWorkout == null) return null;

                var exercises = await conn.QueryAsync<ExerciseForRepo>(sqlExercise,
                new {
                    CompletedWorkoutId = completedWorkout.Id
                });

                foreach(var exercise in exercises)
                {
                    var sets = await conn.QueryAsync<SetForRepo>(sqlSet,
                    new {
                        CompletedExerciseId = exercise.Id
                    });

                    var protectedSetsField = exercise.GetType()
                    .GetField("_sets", BindingFlags.NonPublic | BindingFlags.Instance);

                    protectedSetsField.SetValue(exercise, new HashSet<CompletedSet>(sets));
                }

                var protectedExercisesField = completedWorkout.GetType()
                .GetField("_exercises", BindingFlags.NonPublic | BindingFlags.Instance);

                protectedExercisesField.SetValue(completedWorkout, new HashSet<CompletedExercise>(exercises));
                return completedWorkout;
            }
        }

        public async Task<IEnumerable<CompletedWorkout>> BrowseAsync(Guid accountId, int page, int perPage)
        {
            var sql = $@"SELECT * FROM {TableName} WHERE AccountId = @AccountId 
                         ORDER BY Date 
                         OFFSET @PageSize * (@Page - 1) ROWS 
                         FETCH NEXT @PageSize ROWS ONLY";

            using(var conn = Connection)
            {
                return await conn.QueryAsync<CompletedWorkoutForRepo>(sql,
                new 
                {
                    Page = page,
                    PageSize = perPage, 
                    AccountId = accountId
                });
            }
        }

        public async Task AddAsync(CompletedWorkout completedWorkout)
        {
            await _entities.AddAsync(completedWorkout);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CompletedWorkout completedWorkout)
        {
            _entities.Update(completedWorkout);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(CompletedWorkout completedWorkout)
        {
            _entities.Remove(completedWorkout);
            await _context.SaveChangesAsync();
        }
    }
}