using Practica.API.Models;

namespace Practica.API.Services
{
    public interface IAlumnoRepository
    {
        IEnumerable<Alumno> GetAllAlumnos { get; }  // Aquí el IEnumerable debería ser Alumno o AlumnoDTO?
        Alumno? GetAlumnoById(int alumnoId);
        Task<Alumno> CreateAlumnoAsync(Alumno alumno);
        Task<bool> AlumnoExitsAsync(string nombre, string apellido1, string apellido2);
        Task<bool> AlumnoIdExitsAsync(int id);

        Task<Alumno> DeleteAlumnoAsync(int id);
        Task<Alumno> UpdateAlumnoAsync(Alumno alumno, int id);

    }
}
