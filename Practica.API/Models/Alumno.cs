using System.ComponentModel.DataAnnotations;

namespace Practica.API.Models
{
    public class Alumno
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(50)]
        public string Apellido1 { get; set; }
        [Required]
        [StringLength(50)]
        public string Apellido2 { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime FechaNacimiento { get; set; }
        [Required]
        // añadir que solo pueda tener los valores H,M y O
        public char Sexo { get; set; }
        [Required]
        [StringLength(50)]
        public string Direccion { get; set; }
        [Required]
        [StringLength(50)]
        public string Provincia { get; set; }
        [Required]
        [StringLength(50)]
        public string Localidad { get; set; }
        [Required]
        [Phone]
        [StringLength(9)]
        public string Telefono { get; set; }
        [Required]
        public int CursoId { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }
    }
}
