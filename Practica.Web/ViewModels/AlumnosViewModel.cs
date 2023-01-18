using Practica.API.Models;

namespace Practica.Web.ViewModels
{
    // Este modelo actúa como un data transfer entre el controlador y la vista correspondiente
    // El constructor se inicializa cuando es llamado el método el cual convierte la clase List<Alumnos> a AlumnosViewModel
    public class AlumnosViewModel
    {
        public List<Alumno> Alumnos { get; set; }
        public List<Curso> Cursos { get; set; }

        public void SetAlumnos(List<Alumno> alumnos, List<Curso> cursos)
        {
            Alumnos = alumnos;
            Cursos = cursos;
        }

    }
}
