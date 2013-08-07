using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bja.Entidades
{
    public class MedicoMetaData
    {
        [Display(Name = "Fecha de Registro")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
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

    public class ReclamoMetaData
    {
        [Display(Name = "Fecha")]
        [DataType(DataType.DateTime)]
        public DateTime FechaReclamo { get; set; }

        [Display(Name = "Tipo de reclamo")]
        [Required]
        public long IdTipoReclamo { get; set; }

        [Display(Name = "Nombre")]
        [StringLength(50)]
        [Required]
        public String NombreBeneficiario { get; set; }

        [Display(Name = "Detalle del reclamo")]
        [StringLength(250)]
        [Required]
        public String DetalleReclamo { get; set; }
    }

    public class EncargadoMetaData
    {
        [Display(Name = "Tipo Encargado")]
        [Required]
        public long IdTipoEncargado { get; set; }

        [Required]
        public String Nombres { get; set; }

        [Display(Name = "Primer Apellido")]
        public String PrimerApellido { get; set; }

        [Display(Name = "Segundo Apellido")]
        public String SegundoApellido { get; set; }

        [Display(Name = "Tercer Apellido")]
        public String TercerApellido { get; set; }

        [Display(Name = "Documento de Identidad")]
        [Required]
        public String DocumentoIdentidad { get; set; }

        [Display(Name = "Tipo Documento de Identidad")]
        [Required]
        public long IdTipoDocumentoIdentidad { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FechaNacimiento { get; set; }

        [StringLength(1)]
        [Required]
        public String Sexo { get; set; } //char(1)

        [Display(Name = "Estado Registro")]
        [Required]
        public long IdTipoEstadoRegistro { get; set; }
    }
}
