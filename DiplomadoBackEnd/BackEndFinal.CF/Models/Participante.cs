using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BackEndFinal.CF.Models
{
    public class Participante
    {
        [Key]
        public int IDParticipante { get; set; }
        [Required]
        [StringLength(11)]      
        public string Cedula { get; set; }
        [Required]
        [MaxLength(25)]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(30)]
        public string Apellidos { get; set; }
        [Required]      
        [Display(Name ="Fecha Nac.")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; } = DateTime.Now.AddYears(-18);
        public int Ciudad { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        [NotMapped]
        public string ConfirmarEmail { get; set; }
        //[DataType(DataType.Upload)]
        public string URLImage { get; set; }
        [NotMapped]
        public HttpPostedFileBase File { get; set; }
        public string Sexo { get; set; }
    }
}