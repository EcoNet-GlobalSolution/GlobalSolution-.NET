using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalSolution_.NET.Models
{
    [Table("Especie")]
    public class Especie
    {
        [Key]
        [Column("id_especie")]
        public int id_especie {  get; set; }

        [Required(ErrorMessage = "Nome comum da espécie é necessário.")]
        [StringLength(100, ErrorMessage = "O nome comum não pode exceder 100 caracteres.")]
        [Display(Name = "Nome comum")]
        [Column("nome_comum")]
        public string? nome_comum { get; set; }

        [Required(ErrorMessage = "Espécie é necessário.")]
        [StringLength(100, ErrorMessage = "A espécie não pode exceder 100 caracteres.")]
        [Display(Name = "Espécie")]
        [Column("especie")]
        public string? especie { get; set; }
    }
}
