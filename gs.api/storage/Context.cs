using System;
using gs.api.infrastructure.settings;
using gs.api.storage.model;
using gs.api.storage.model.resellers.goods;
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
        
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<User> Users { get; set; }
        
        public DbSet<Good> Goods { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connectionString: DbSettings.ConnectionString);
        }
    }
}