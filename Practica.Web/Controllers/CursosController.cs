using Kendo.Mvc.Extensions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Practica.API.Models;
using Practica.Web.ViewModel;

namespace Practica.Web.Controllers
{
    public class CursosController : Controller
    {
        private readonly HttpClient _httpClient;

        public CursosController()
        {
            _httpClient = new HttpClient();

        }
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("https://localhost:7280/api/Cursos");
            var json = await response.Content.ReadAsStringAsync();
            var listaCursos = JsonConvert.DeserializeObject<List<Curso>>(json);
            var viewModel = new CursosViewModel(); // llamamos al constructor para crear una nueva instancia de la clase CursosViewModel
            viewModel.SetCursos(listaCursos);
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(Curso cursoReferencia)
        {
            var response = await _httpClient.GetAsync("https://localhost:7280/api/Cursos");
            var json = await response.Content.ReadAsStringAsync();
            var listaCursos = JsonConvert.DeserializeObject<List<Curso>>(json);
            var viewModel = new CursosViewModel();

            int cursoId = cursoReferencia.CursoId;
            string nombre = cursoReferencia.Nombre;

            List<Curso> cursosFiltrados = listaCursos.Where(c => (c.CursoId == cursoId || cursoId == 0)
            && (string.IsNullOrEmpty(nombre) || c.Nombre.Contains(nombre))).ToList();
            viewModel.SetCursos(cursosFiltrados);

            return View(viewModel);
        }
        //public async Task<IActionResult> Orders_Read([DataSourceRequest] DataSourceRequest request)
        //{

        //    var serializerOptions = new JsonSerializerOptions()
        //    {
        //        // Esto elimina el camelCase
        //    };

        //    var response = await _httpClient.GetAsync("https://localhost:7280/api/Cursos");
        //    var json = await response.Content.ReadAsStringAsync();
        //    var listaCursos = JsonConvert.DeserializeObject<List<Curso>>(json);

        //    // Convertir la colección a un formato que pueda ser entendido por el grid de Kendo
        //    var result = listaCursos.ToDataSourceResult(request);

        //    // Devolver los datos en formato JSON
        //    return Json(result, serializerOptions);
        //}

    }

}

