using Cooperchip.ItDeveloper.Domain.Entities;
using Cooperchip.ItDeveloper.Mvc.Models;
using Cooperchip.ItDeveloper.Mvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cooperchip.ItDeveloper.Mvc.Controllers
{
    [Route("")]
    [Route("gestao-de-pacientes")]
    public class PacienteController : BaseController
    {
        private readonly PacienteService _pacienteService;

        public PacienteController(PacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        [Route("pacientes")]
        [Route("obter-pacientes")]
        //[HttpGet("")]
        public IActionResult Index()
        {
            var pacientes = new List<Paciente>()
            {
                new Paciente
                {
                Nome = "Guilherme",
                Cpf = "12154176917"
              
            }
            };
            return View(pacientes);
        }

        [HttpGet]
        [Route("detalhe-de-paciente")]
        public IActionResult DetalheDePaciente(string id)
        {
            var paciente = _pacienteService.ObterPacientePorId(id);
            return View(paciente);
        }

        [HttpPost]
        public IActionResult AdicionarPaciente()
        {
            return View();
        }

    }
}
