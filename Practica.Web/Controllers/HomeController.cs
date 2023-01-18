using Microsoft.AspNetCore.Mvc;
namespace Practica.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public bool MetodoEjemplo(int id)
        {
            if (id == 0)
            {
                return true;
            }
            else if (id == 1)
            {
                return false;
            }
            throw new Exception("Ha ocurrido un error");
        }
    }
}