using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Practica.API.Entities;
using Practica.API.Models;
using Practica.API.Services;

namespace Practica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursosController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICursoRepository _cursoRepository;
        public CursosController(ICursoRepository cursoRepositoy, IMapper mapper)
        {
            _cursoRepository = cursoRepositoy;
            _mapper = mapper;
        }
        // GET: api/cursos
        [HttpGet]
        public IEnumerable<Curso> Get()
        {
            return _cursoRepository.GetAllCursos;
        }
        // GET api/cursos/id
        [HttpGet("id/{id}")]
        public async Task<ActionResult<Curso>> Get(int id)
        {
            if (await _cursoRepository.CursoIdExitsAsync(id))
            {
                return Ok(_cursoRepository.GetCursoById(id));
            }
            else
            {
                return NotFound("No existe ningún curso con el id proporcionado");
            }
        }
        // GET api/cursos/name
        [HttpGet("name/{name}")]
        public async Task<ActionResult<Curso>> GetByName(string name)
        {
            if (await _cursoRepository.CursoExitsAsync(name))
            {
                return Ok(_cursoRepository.GetCursoByName(name));
            }
            else
            {
                return NotFound("No existe ningún curso con el nombre proporcionado");
            }
        }
        // POST api/cursos
        [HttpPost]
        public async Task<ActionResult<Curso>> Post([FromBody] CursoDTO nuevoCursoDTO)
        {
            if (!await _cursoRepository.CursoExitsAsync(nuevoCursoDTO.Nombre))
            {
                Curso nuevoCurso = _mapper.Map<Curso>(nuevoCursoDTO);
                return Ok(await _cursoRepository.CreateCursoAsync(nuevoCurso));
            }
            else
            {
                return BadRequest("El curso ya existe");
            }
        }
        // POST api/cursos
        [HttpDelete("{id}")]
        public async Task<ActionResult<Curso>> Delete(int id)
        {
            if (await _cursoRepository.CursoIdExitsAsync(id))
            {
                return Ok(await _cursoRepository.DeleteCursoAsync(id));
            }
            else
            {
                return NotFound("El curso no existe");
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Curso>> Put([FromBody] CursoDTO cursoForUpdateDto, int id)
        {
            if (id != cursoForUpdateDto.CursoId)
                return BadRequest("Discrepancia en el Id del curso");
            if (await _cursoRepository.CursoIdExitsAsync(id))
            {
                Curso cursoForUpdate = _mapper.Map<Curso>(cursoForUpdateDto);
                return Ok(await _cursoRepository.UpdateCursoAsync(cursoForUpdate, id));
            }
            else
            {
                return NotFound("El alumno no existe");
            }
        }
    }
}
