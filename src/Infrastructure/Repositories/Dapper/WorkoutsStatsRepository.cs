using System;
using System.Threading.Tasks;
using Dapper;
using Domain.Repositories;
using Domain.ValueObjects;
using Infrastructure.Dapper;
using Infrastructure.Settings;

namespace Infrastructure.Repositories.Dapper
{
    public class WorkoutsStatsRepository : DapperRepository, IWorkoutsStatsRepository
    {

        public WorkoutsStatsRepository(DatabaseSettings databaseSettings)
            :base(databaseSettings){ }

        public async Task<GlobalWorkoutsStats> GetGlobalWorkoutsStatsAsync(Guid accountId)
        {
            var sql = "Select "
            + "CAST(SUM(cs.Reps*cs.Weight) AS float) As Volume, "
            + "COUNT(DISTINCT cw.Id) AS NumberOfCompletedWorkouts, "
            + "SUM(cw.Duration) * COUNT(DISTINCT cw.Id) / COUNT(*) AS Duration "
            + "From CompletedWorkout cw "
            + "INNER JOIN CompletedExercise ce ON cw.Id = ce.CompletedWorkoutId "
            + "INNER JOIN CompletedSet cs ON ce.Id = cs.CompletedExerciseId "
            + "Where cw.AccountId = @AccountId";

            using(var conn = Connection)
            {
                return await conn.QuerySingleAsync<GlobalWorkoutsStats>(sql, new {AccountId = accountId});
            }
        }

        public async Task<WorkoutsStatsOverTime> GetWorkoutsStatsOverTimeAsync(Guid accountId, DateTime dateFrom, DateTime dateTo)
        {
            var sql = "Select "
            + "CAST(SUM(cs.Reps*cs.Weight) AS float) As Volume, "
            + "COUNT(DISTINCT cw.Id) AS NumberOfCompletedWorkouts, "
            + "SUM(cw.Duration) * COUNT(DISTINCT cw.Id) / COUNT(*) AS Duration, "
            + "@DateFrom AS DateFrom, "
            + "@DateTo AS DateTo "
            + "From CompletedWorkout cw "
            + "INNER JOIN CompletedExercise ce ON cw.Id = ce.CompletedWorkoutId "
            + "INNER JOIN CompletedSet cs ON ce.Id = cs.CompletedExerciseId "
            + $"Where cw.AccountId = @AccountId AND Date >= @DateFrom AND Date <= @DateTo";

            using(var conn = Connection)
            {
                return await conn.QuerySingleAsync<WorkoutsStatsOverTime>(sql,
                new 
                {
                    AccountId = accountId,
                    DateFrom = dateFrom,
                    DateTo = dateTo
                }
                );
            }
        }
    }
}