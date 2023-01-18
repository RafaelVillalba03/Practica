using System.ComponentModel.DataAnnotations;

namespace Practica.API.Models
{
    public class Curso
    {
        [Required]
        public int CursoId { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
    }
}
