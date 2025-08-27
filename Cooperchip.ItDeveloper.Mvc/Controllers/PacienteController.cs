using Microsoft.AspNetCore.Mvc;

namespace Cooperchip.ItDeveloper.Mvc.Controllers
{
    [Route("")]
    [Route("gestao-de-pacientes")]
    public class PacienteController : BaseController
    {
        [Route("pacientes")]
        //[HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdicionarPaciente()
        {
            return View();
        }

    }
}
