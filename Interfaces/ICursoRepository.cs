using System;
using CastGroup.Entities;

namespace CastGroup.Interfaces
{
    public interface ICursoRepository: IRepositoryBase<Curso>
    {
        bool VerificarData(DateTime dataInicio, DateTime dataFim);
    }
}