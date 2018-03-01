using System;
using gs.api.infrastructure.settings;
using gs.api.storage.model;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace gs.api.storage
{
    public class Context : DbContext
    {
        private readonly IDbSettings DbSettings;
        public Context(DbContextOptions<Context> options, [NotNull] IDbSettings dbSettings) 
            : base(options)
        {
            DbSettings = dbSettings ?? throw new ArgumentNullException(nameof(dbSettings));
        }
        
        public DbSet<LtdOrganization> LtdOrganizations { get; set; }
        public DbSet<IeOrganization> IeOrganizations { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connectionString: DbSettings.ConnectionString);
        }
    }
}