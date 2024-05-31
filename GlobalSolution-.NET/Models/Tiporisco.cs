﻿using GlobalSolution_.NET.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalSolution_.NET.Models
{
    [Table("Tipo_risco")]
    public class Tiporisco
    {
        [Key]
        [Column("id_risco")]
        public int id_risco { get; set; }

        [Required(ErrorMessage = "Categoria é necessária.")]
        [EnumDataType(typeof(CategoriaRisco), ErrorMessage = "Categoria inválida.")]
        [Column("categoria")]
        public CategoriaRisco? categoria { get; set; }
    }
}