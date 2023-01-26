using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSClinica.Models
{
    [Table("Medico")]
    public class Medico
    {
        public int MedicoId { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Apellido { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Nombre { get; set; }

        public int Matricula { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaNacimiento { get; set; }

        public List<Paciente> Pacientes { get; set; }

        public int EspecialidadId { get; set; }
        [ForeignKey("EspecialidadId")]
        public Especialidad Especialidad { get; set; }
    }
}
