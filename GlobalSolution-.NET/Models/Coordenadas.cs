using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalSolution_.NET.Models
{
    [Table("Coordenadas")]
    public class Coordenadas
    {
        [Key]
        [Column("id_coordenadas")]
        public int id_coordenadas { get; set; }

        [Required(ErrorMessage = "Longitude é obrigatório.")]
        [Display(Name = "Longitude")]
        [Range(-180, 180, ErrorMessage = "A longitude deve estar entre -180 e 180 graus.")]
        [Column("longitude")]
        public int longitude { get; set; }

        [Required(ErrorMessage = "Latitude é obrigatória.")]
        [Display(Name = "Latitude")]
        [Range(-90, 90, ErrorMessage = "A latitude deve estar entre -90 e 90 graus.")]
        [Column("latitude")]
        public int latitude { get; set; }
    }
}
