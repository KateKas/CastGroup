using Microsoft.EntityFrameworkCore;
using CastGroup.Entities;

namespace CastGroup.Data
{
    public class CastGroupDbContext : DbContext
    {
        public CastGroupDbContext(DbContextOptions<CastGroupDbContext> options)
            : base(options)
        {
        }

        public DbSet<Curso> Curso { get; set; }
        public DbSet<Categoria> Categoria { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}