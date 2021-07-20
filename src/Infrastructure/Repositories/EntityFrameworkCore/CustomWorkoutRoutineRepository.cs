using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.EntityFrameworkCore
{
    public class CustomWorkoutRoutineRepository : ICustomWorkoutRoutineRepository, IEntityFrameworkCoreRepository
    {
        
        private readonly DatabaseContext _context;
        private readonly DbSet<CustomWorkoutRoutine> _entities;

        public CustomWorkoutRoutineRepository(DatabaseContext context)
        {
            _context = context;
            _entities = context.Set<CustomWorkoutRoutine>();
        }

        public async Task<CustomWorkoutRoutine> GetAsync(Guid id)
            => await _entities.AsNoTracking().Include(x => x.Exercises).SingleOrDefaultAsync(x => x.Id == id);

        public async Task<CustomWorkoutRoutine> GetByNameAsync(string name)
            => await _entities.AsNoTracking().Include(x => x.Exercises).SingleOrDefaultAsync(x => x.Name == name);
             
        public async Task<IEnumerable<CustomWorkoutRoutine>> BrowseWithoutArchiveAsync(Guid accountId, int page, int perPage)
            => await _entities.Where(x=> x.IsArchived == false && x.AccountId == accountId).Skip((page-1)*perPage).Take(perPage).ToListAsync();
        public async Task<IEnumerable<CustomWorkoutRoutine>> BrowseArchiveAsync(Guid accountId, int page, int perPage)
            => await _entities.Where(x=> x.IsArchived == true && x.AccountId == accountId).Skip((page-1)*perPage).Take(perPage).ToListAsync();

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


    }
}