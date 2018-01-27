using System;
using gs.api.infrastructure.settings;
using gs.api.storage.model.suppliers.goods;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace gs.api.storage.repositories.sqlServer
{
    public class Context : DbContext
    {
        private readonly IDbSettings DbSettings;

        public Context([NotNull] IDbSettings dbSettings)
        {
            DbSettings = dbSettings ?? throw new ArgumentNullException(nameof(dbSettings));
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbSettings.ConnectionString);
        }
        
        public DbSet<Good> Goods { get; set; }
    }
}