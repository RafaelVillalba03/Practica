using Microsoft.EntityFrameworkCore;
using Practica.API.Models;

namespace Practica.API.Services
{
    public class CursoRepository : ICursoRepository
    {
        private readonly AppDbContext _appDbContext;
        public CursoRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Curso> GetAllCursos
        {
            get
            {
                return _appDbContext.Cursos;
            }
        }
        public Curso? GetCursoById(int cursoId)
        {
            return _appDbContext.Cursos.FirstOrDefault(c => c.CursoId == cursoId);
        }
        public Curso? GetCursoByName(string cursoName)
        {
            return _appDbContext.Cursos.FirstOrDefault(c => c.Nombre == cursoName);
        }
        public async Task<Curso> CreateCursoAsync(Curso curso)
        {
            try
            {
                _appDbContext.Add<Curso>(curso);
                await _appDbContext.SaveChangesAsync();
                return curso;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> CursoExitsAsync(string nombreCurso)
        {
            return await _appDbContext.Cursos.AnyAsync(c => c.Nombre == nombreCurso);
        }
        public async Task<bool> CursoIdExitsAsync(int cursoId)
        {
            return await _appDbContext.Cursos.AnyAsync(c => c.CursoId == cursoId);
        }
        public async Task<Curso> DeleteCursoAsync(int cursoId)
        {
            try
            {
                var cursoParaEliminar = await _appDbContext.Cursos.FirstOrDefaultAsync(c => c.CursoId == cursoId);
                _appDbContext.Remove<Curso>(cursoParaEliminar);
                await _appDbContext.SaveChangesAsync();
                return cursoParaEliminar;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Curso> UpdateCursoAsync(Curso curso, int id)
        {
            try
            {
                _appDbContext.Update<Curso>(curso);
                await _appDbContext.SaveChangesAsync();
                return curso;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
