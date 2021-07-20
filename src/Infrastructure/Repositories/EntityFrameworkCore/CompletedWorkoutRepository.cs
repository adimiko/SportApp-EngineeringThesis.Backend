using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.EntityFrameworkCore
{
    public class CompletedWorkoutRepository : ICompletedWorkoutRepository, IEntityFrameworkCoreRepository
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<CompletedWorkout> _entities;

        public CompletedWorkoutRepository(DatabaseContext context)
        {
            _context = context;
            _entities = context.Set<CompletedWorkout>();
        }
        public async Task<CompletedWorkout> GetAsync(Guid id)
            => await _entities.AsNoTracking().Include(x => x.Exercises).ThenInclude(x => x.Sets).SingleOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<CompletedWorkout>> BrowseAsync(Guid accountId, int page, int perPage)
            => await _entities.Where(x=> x.AccountId == accountId).Skip((page-1)*perPage).Take(perPage).OrderByDescending(x => x.Date).ToListAsync();
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