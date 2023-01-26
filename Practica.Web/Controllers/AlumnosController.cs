using Kendo.Mvc.Extensions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Practica.API.Models;
using Practica.Web.Models;
using Practica.Web.ViewModels;


namespace Practica.Web.Controllers
{
    public class AlumnosController : Controller
    {
        private readonly HttpClient _httpClient;
        public AlumnosController()
        {
            _httpClient = new HttpClient();

        }
        public async Task<IActionResult> Index()
        {
            var response1 = await _httpClient.GetAsync("https://localhost:7280/api/Alumnos");
            var jsonAlumnos = await response1.Content.ReadAsStringAsync();
            var response2 = await _httpClient.GetAsync("https://localhost:7280/api/Cursos");
            var jsonCursos = await response2.Content.ReadAsStringAsync();

            var listaAlumnos = JsonConvert.DeserializeObject<List<Alumno>>(jsonAlumnos);
            var listaCursos = JsonConvert.DeserializeObject<List<Curso>>(jsonCursos);

            var viewModel = new AlumnosViewModel(); // llamamos al constructor para crear una nueva instancia de la clase CursosViewModel
            viewModel.SetAlumnos(listaAlumnos, listaCursos);
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(AlumnoFormulario alumnoReferencia)
        {
            var response1 = await _httpClient.GetAsync("https://localhost:7280/api/Alumnos");
            var jsonAlumnos = await response1.Content.ReadAsStringAsync();
            var response2 = await _httpClient.GetAsync("https://localhost:7280/api/Cursos");
            var jsonCursos = await response2.Content.ReadAsStringAsync();

            var listaAlumnos = JsonConvert.DeserializeObject<List<Alumno>>(jsonAlumnos);
            var listaCursos = JsonConvert.DeserializeObject<List<Curso>>(jsonCursos);
            var viewModel = new AlumnosViewModel();

            int alumnoId = alumnoReferencia.Id;
            string nombre = alumnoReferencia.Nombre;
            string apellido1 = alumnoReferencia.Apellido1;
            string apellido2 = alumnoReferencia.Apellido2;
            char sexo = alumnoReferencia.Sexo;
            string localidad = alumnoReferencia.Localidad;
            string provincia = alumnoReferencia.Provincia;
            string telefono = alumnoReferencia.Telefono;
            string email = alumnoReferencia.Email;
            DateTime fechaNacimiento = alumnoReferencia.FechaNacimiento;
            string direccion = alumnoReferencia.Direccion;

            string nombreCurso = alumnoReferencia.NombreCurso;
            Curso cursoMatch = listaCursos.FirstOrDefault(c => c.Nombre == nombreCurso);

            int cursoId;                // Este bloque de código salvaguarda el hecho de que
            if (cursoMatch == null)     // cursoId es un campo no nuleable, lo pone a 0 en caso de null
            {
                cursoId = 0;
            }
            else
            {
                cursoId = cursoMatch.CursoId;
            }
            List<Alumno> alumnosFiltrados = listaAlumnos.Where
            (c => (c.Id == alumnoId || alumnoId == 0)
            && (string.IsNullOrEmpty(nombre) || c.Nombre.Contains(nombre))
            && (string.IsNullOrEmpty(apellido1) || c.Apellido1.Contains(apellido1))
            && (string.IsNullOrEmpty(apellido2) || c.Apellido2.Contains(apellido2))
            && (c.Sexo == sexo || sexo == '-')
            && (string.IsNullOrEmpty(localidad) || c.Localidad.Contains(localidad))
            && (string.IsNullOrEmpty(provincia) || c.Provincia.Contains(provincia))
            && (string.IsNullOrEmpty(telefono) || c.Telefono.Contains(telefono))
            && (string.IsNullOrEmpty(email) || c.Email.Contains(email))
            && (c.FechaNacimiento == fechaNacimiento || fechaNacimiento == new DateTime(0001, 01, 01))
            && (string.IsNullOrEmpty(direccion) || c.Direccion.Contains(direccion))
            && (c.CursoId == cursoId || cursoId == 0)
            ).ToList();

            viewModel.SetAlumnos(alumnosFiltrados, listaCursos);

            return View(viewModel);
        }
        //public async Task<IActionResult> Orders_Read([DataSourceRequest] DataSourceRequest request)
        //{

        //    var serializerOptions = new System.Text.Json.JsonSerializerOptions()
        //    {
        //        // Esto elimina el camelCase
        //    };



        //    // Devolver los datos en formato JSON
        //    //return Json(result, serializerOptions);
        //}

    }
}
