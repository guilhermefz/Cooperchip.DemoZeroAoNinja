using Cooperchip.ItDeveloper.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cooperchip.ItDeveloper.Mvc.Controllers
{
    [Route("")]
    [Route("gestao-de-pacientes")]
    public class PacienteController : BaseController
    {
        

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
                Cpf = "12154176917",
                Telefones = new List<Telefone>
                {
                    new Telefone
                    {
                        Id = Guid.NewGuid(),
                        Numero = "64872648",
                        TipoDeTelefone = "Residence"
                    }
                }
            }
            };
            return View(pacientes);
        }

        [Route("detalhe-de-paciente/{id}")]
        public IActionResult DetalheDePaciente(string id)
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
