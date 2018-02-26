using gs.api.storage.model;
using Microsoft.EntityFrameworkCore;

namespace gs.api.storage
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        
        public DbSet<Organization> Organizations { get; set; }
    }
}