using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bja.Entidades
{
    class MetaData
    {
    }

    public class MedicoMetaData
    {
        [Display(Name = "Fecha de Registro")]
        [DataType(DataType.DateTime)]    
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime FechaRegistro { get; set; }

        [Required]
        [StringLength(50)]
        public String Nombres { get; set; }

        [Display(Name = "Primer Apellido")]
        [StringLength(50)]
        public String PrimerApellido { get; set; }

        [Display(Name = "Segundo Apellido")]
        [StringLength(50)]
        public String SegundoApellido { get; set; }

        [Display(Name = "Tercer Apellido")]
        [StringLength(50)]
        public String TercerApellido { get; set; }

        [Display(Name = "Documento de Identidad")]
        [Required]
        [StringLength(15)]
        public String DocumentoIdentidad { get; set; }

        [Display(Name = "Tipo de Documento de Identidad")]
        [Required]
        public long IdTipoDocumentoIdentidad { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FechaNacimiento { get; set; }

        [Display(Name = "Localidad de Nacimiento")]
        [Required]
        public String IdLocalidadNacimiento { get; set; }

        [Display(Name = "Matricula")]
        [Required]
        public String MatriculaColegioMedico { get; set; }

        [Display(Name = "Email")]
        [EmailAddress]
        public String CorreoElectronico { get; set; }
    }
}
