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
    public class SampleWorkoutRoutineRepository : ISampleWorkoutRoutineRepository, IEntityFrameworkCoreRepository
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<SampleWorkoutRoutine> _entities;

        public SampleWorkoutRoutineRepository(DatabaseContext context)
        {
            _context = context;
            _entities = context.Set<SampleWorkoutRoutine>();
        }
        public async Task<SampleWorkoutRoutine> GetAsync(Guid id)
            => await _entities.AsNoTracking().Where(x => x.Id == id).Include(x => x.Exercises).SingleOrDefaultAsync();


        public async Task<SampleWorkoutRoutine> GetByNameAsync(string name)
            => await _entities.AsNoTracking().Where(x => x.Name == name).Include(x => x.Exercises).SingleOrDefaultAsync();

        public async Task<IEnumerable<SampleWorkoutRoutine>> BrowseWithoutArchiveAsync(int page, int perPage)
            => await _entities.Where(x=> x.IsArchived == false).Skip((page-1)*perPage).Take(perPage).ToListAsync();

        public async Task<IEnumerable<SampleWorkoutRoutine>> BrowseArchiveAsync(int page, int perPage)
            => await _entities.Where(x=> x.IsArchived == true).Skip((page-1)*perPage).Take(perPage).ToListAsync();
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


    }
}