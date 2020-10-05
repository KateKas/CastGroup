using System;
using CastGroup.Entities;

namespace CastGroup.Data.DTO
{
    public class CursoDTO
    {
        public Guid id { get; set; }

        public string Descricao { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }
        public int QuantidadeAluno { get; set; }

        public Guid CategoriaId { get; set; }
    }
}