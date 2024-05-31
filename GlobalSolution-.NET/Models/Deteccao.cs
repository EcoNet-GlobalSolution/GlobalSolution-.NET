using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalSolution_.NET.Models
{
    [Table("Deteccao")]
    public class Deteccao
    {
        [Key]
        [Column("id_deteccao")]
        public int id_deteccao { get; set; }

        [Required(ErrorMessage = "Data é obrigatória!")]
        [Column("data")]
        [DataType(DataType.DateTime, ErrorMessage = "Data inválida.")]
        [Display(Name = "Data de Detecção")]
        public DateTime data {  get; set; }
    }
}
