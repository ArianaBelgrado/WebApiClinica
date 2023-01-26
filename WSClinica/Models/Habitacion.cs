using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSClinica.Models
{
    [Table("Habitacion")]
    public class Habitacion
    {
        public int HabitacionId { get; set; }

        [Range(1, 100)]
        public int Numero { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Estado { get; set; }
        public int ClinicaId { get; set; }

        [ForeignKey("ClinicaId")]
        public Clinica Clinica { get; set; }
    }
}
