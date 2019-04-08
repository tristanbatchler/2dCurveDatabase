using CurveDatabase2d.Models;
using Microsoft.EntityFrameworkCore;

namespace CurveDatabase2d.Data
{
    public class CurveDatabase2dContext : DbContext
    {
        public CurveDatabase2dContext(DbContextOptions options) 
            : base(options)
        {
        }

        public DbSet<Entity> Entities { get; set; }
        public DbSet<Curve> Curves { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Curve>()
                .HasBaseType<Entity>();
        }

    }


}

