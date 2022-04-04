using Microsoft.EntityFrameworkCore; // for DbContext, DbContextOptions
using WestwindSystem.Entities; // for Category

namespace WestwindSystem.DAL
{
    internal class WestwindContext: DbContext
    {
        public WestwindContext()
        {

        }
        public WestwindContext(DbContextOptions<WestwindContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<BuildVersion> BuildVersions { get; set; } = null!;

        public DbSet<Region> Region { get; set; } = null!;

        public DbSet<Territory> Territories { get; set; } = null!;


    }
}
