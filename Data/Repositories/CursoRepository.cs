
using CastGroup.Entities;
using CastGroup.Interfaces;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CastGroup.Data.Repositories
{
    public class CursoRepository : RepositoryBase<Curso>, ICursoRepository
    {
        public CursoRepository(CastGroupDbContext dbContext)
        : base(dbContext)
        {
            
        } 

        public bool VerificarData(DateTime dataInicio, DateTime dataFim)
        {
            return  GetAll().Where(c=> (dataInicio <= c.DataInicio && dataFim >= c.DataInicio)
            || (dataInicio <= c.DataFim && dataFim >= c.DataInicio)).Count() > 0;
        } 
    }
}