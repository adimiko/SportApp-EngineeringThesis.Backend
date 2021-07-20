using System.Reflection;
using Domain.Entities;
using Infrastructure.Settings;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFrameworkCore
{
    public class DatabaseContext : DbContext
    {

        private readonly DatabaseSettings _databaseSettings;
        public DatabaseContext(DbContextOptions<DatabaseContext> options, DatabaseSettings databaseSettings) 
            : base(options) 
            => _databaseSettings = databaseSettings;
 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(_databaseSettings.ConnectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}