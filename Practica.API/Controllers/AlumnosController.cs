using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Practica.API.Entities;
using Practica.API.Models;
using Practica.API.Services;


namespace Practica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnosController : ControllerBase
    {
        private readonly IAlumnoRepository _alumnoRepository;
        private readonly IMapper _mapper;
        public AlumnosController(IAlumnoRepository alumnoRepository, IMapper mapper)
        {
            _alumnoRepository = alumnoRepository;
            _mapper = mapper;
        }
        // GET: api/alumnos
        [HttpGet]
        public IEnumerable<Alumno> Get()
        {
            return _alumnoRepository.GetAllAlumnos;
        }
        // GET api/alumnos/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Alumno>> Get(int id)
        {
            if (await _alumnoRepository.AlumnoIdExitsAsync(id))
            {
                return Ok(_alumnoRepository.GetAlumnoById(id));
            }
            else
            {
                return NotFound("No existe ningún curso con el id proporcionado");
            }
        }
        // POST api/alumnos
        [HttpPost]
        public async Task<ActionResult<Alumno>> Post([FromBody] AlumnoDTO nuevoAlumnoDto)
        {
            if (!await _alumnoRepository.AlumnoExitsAsync(nuevoAlumnoDto.Nombre, nuevoAlumnoDto.Apellido1, nuevoAlumnoDto.Apellido2))
            {
                Alumno nuevoAlumno = _mapper.Map<Alumno>(nuevoAlumnoDto);
                return Ok(await _alumnoRepository.CreateAlumnoAsync(nuevoAlumno));
            }
            else
            {
                return BadRequest("El alumno ya existe");
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Alumno>> Delete(int id)
        {
            if (await _alumnoRepository.AlumnoIdExitsAsync(id))
            {
                return Ok(await _alumnoRepository.DeleteAlumnoAsync(id));
            }
            else
            {
                return NotFound("El alumno no existe");
            }
        }
        // GET api/alumnos/id
        [HttpPut("{id}")]
        public async Task<ActionResult<Alumno>> Put([FromBody] AlumnoDTO alumnoForUpdateDto, int id)
        {
            if (id != alumnoForUpdateDto.Id)
                return BadRequest("Discrepancia en el Id del alumno");
            if (await _alumnoRepository.AlumnoIdExitsAsync(id))
            {
                Alumno alumnoForUpdate = _mapper.Map<Alumno>(alumnoForUpdateDto);
                return Ok(await _alumnoRepository.UpdateAlumnoAsync(alumnoForUpdate, id));
            }
            else
            {
                return NotFound("El alumno no existe");
            }
        }
    }
}
