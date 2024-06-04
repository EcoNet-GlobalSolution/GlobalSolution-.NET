using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalSolution_.NET.Models
{
    [Table("Deteccao")]
    public class DeteccaoModel
    {
        [Key]
        [Column("id_deteccao")]
        public int id_deteccao { get; set; }

        [Required(ErrorMessage = "Data é obrigatória!")]
        [Column("data")]
        [DataType(DataType.DateTime, ErrorMessage = "Data inválida.")]
        [Display(Name = "Data de Detecção")]
        public DateTime data {  get; set; }

        [ForeignKey("Coordenadas")]
        [Column("id_coordenadas")]
        public int id_coordenadas { get; set; }
        public CoordenadasModel? Coordenadas { get; set; }

        [ForeignKey("Especie")]
        [Column("id_especie")]
        public int id_especie {  get; set; }
        public EspecieModel? Especie { get; set; }
    }
}
