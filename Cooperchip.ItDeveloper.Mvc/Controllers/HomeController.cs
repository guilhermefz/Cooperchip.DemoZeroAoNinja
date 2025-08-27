using System.Diagnostics;
using Cooperchip.ItDeveloper.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cooperchip.ItDeveloper.Mvc.Controllers
{
    [Route("")]
    [Route("pagina-inicial")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("")]
        [Route("dashboard")]
        [Route("quadro-analitico")]
        public IActionResult Dashboard()
        {
            return View();
        }

        [Route("privacidade")]
        public IActionResult Privacy()
        {
            return View();
        }

        [Route("erros")]
        [Route("controleErros")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
