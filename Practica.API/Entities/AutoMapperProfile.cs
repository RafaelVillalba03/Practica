using AutoMapper;
using Practica.API.Models;

namespace Practica.API.Entities
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Alumno, AlumnoDTO>().ReverseMap();
            CreateMap<Curso, CursoDTO>().ReverseMap();
        }
    }
}
