
using CastGroup.Entities;
using CastGroup.Interfaces;

namespace CastGroup.Data.Repositories
{
    public class CategoriaRepository : RepositoryBase<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(CastGroupDbContext dbContext)
        : base(dbContext)
        {
            
        }
    }
}