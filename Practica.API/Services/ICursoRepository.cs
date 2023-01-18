using Practica.API.Models;

namespace Practica.API.Services
{
    public interface ICursoRepository
    {
        IEnumerable<Curso> GetAllCursos { get; }
        Curso? GetCursoById(int cursoId);
        Curso? GetCursoByName(string cursoName);
        Task<Curso> CreateCursoAsync(Curso curso);
        Task<bool> CursoExitsAsync(string nombreCurso);
        Task<bool> CursoIdExitsAsync(int cursoId);
        Task<Curso> DeleteCursoAsync(int cursoId);
        Task<Curso> UpdateCursoAsync(Curso curso, int cursoId);
    }
}
