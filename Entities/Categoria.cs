using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CastGroup.Interfaces;

namespace CastGroup.Entities
{
    [Table("categoria")]
    public class Categoria : IEntity
    {
        [Key]
        public Guid id { get; set; }
        
        [MaxLength(250)]
        public string Descricao { get; set; }
    }
}