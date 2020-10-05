using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CastGroup.Interfaces;

namespace CastGroup.Entities
{
    [Table("curso")]
    public class Curso : IEntity
    {
        [Key]
        public Guid id { get; set; }

        [MaxLength(250)]
        [Required]
        public string Descricao { get; set; }

        [Required]
        public DateTime DataInicio { get; set; }

        [Required]
        public DateTime DataFim { get; set; }
        public int QuantidadeAluno { get; set; }

        [Required]
        public Guid CategoriaId { get; set; }

        public virtual Categoria Categoria { get; set; }

    }
}