using System;
using gs.api.infrastructure.settings;
using gs.api.storage.model;
using gs.api.storage.model.resellers.dicts;
using gs.api.storage.model.resellers.dicts.spec;
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
        public DbSet<GoodCategory> GoodCategories { get; set; }
        public DbSet<Store> Stores { get; set; }
        
        public DbSet<Specification> Specifications { get; set; }
        public DbSet<BoolSpecification> BoolSpecifications { get; set; }
        public DbSet<ColorSpecification> ColorSpecifications { get; set; }
        public DbSet<NumberSpecification> NumberSpecifications { get; set; }
        public DbSet<StringSpecification> StringSpecifications { get; set; }
        
        public DbSet<BoolSpecificationValue> BoolSpecificationValues { get; set; }
        public DbSet<ColorSpecificationValue> ColorSpecificationValues { get; set; }
        public DbSet<NumberSpecificationValue> NumberSpecificationValues { get; set; }
        public DbSet<StringSpecificationValue> StringSpecificationValues { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connectionString: DbSettings.ConnectionString);
        }
    }
}