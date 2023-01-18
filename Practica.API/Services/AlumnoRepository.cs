using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Practica.API.Models;

namespace Practica.API.Services
{
    public class AlumnoRepository : IAlumnoRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public AlumnoRepository(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public IEnumerable<Alumno> GetAllAlumnos
        {
            get
            {
                return _appDbContext.Alumnos;
            }
        }

        public Alumno? GetAlumnoById(int alumnoId)
        {
            return _appDbContext.Alumnos.FirstOrDefault(c => c.Id == alumnoId);
        }

        public async Task<Alumno> CreateAlumnoAsync(Alumno alumno)
        {
            try
            {
                _appDbContext.Add<Alumno>(alumno);
                await _appDbContext.SaveChangesAsync();
                return alumno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> AlumnoExitsAsync(string nombre, string apellido1, string apellido2)
        {
            bool alumnoMatch = await _appDbContext.Alumnos.AnyAsync(c =>
            (c.Nombre == nombre) && (c.Apellido1 == apellido1) && (c.Apellido2 == apellido2));
            return alumnoMatch;
        }
        public async Task<bool> AlumnoIdExitsAsync(int id)
        {
            bool alumnoMatch = await _appDbContext.Alumnos.AnyAsync(c => c.Id == id);
            return alumnoMatch;
        }

        public async Task<Alumno> DeleteAlumnoAsync(int id)
        {
            try
            {
                var alumnoParaEliminar = await _appDbContext.Alumnos.FirstOrDefaultAsync(c => c.Id == id);
                _appDbContext.Remove<Alumno>(alumnoParaEliminar);
                await _appDbContext.SaveChangesAsync();
                return alumnoParaEliminar;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Alumno> UpdateAlumnoAsync(Alumno alumno, int id)
        {
            try
            {
                _appDbContext.Update<Alumno>(alumno);
                await _appDbContext.SaveChangesAsync();
                return alumno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}