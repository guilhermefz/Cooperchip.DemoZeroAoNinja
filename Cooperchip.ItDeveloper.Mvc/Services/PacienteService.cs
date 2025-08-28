using Cooperchip.ItDeveloper.Domain.Entities;
using Cooperchip.ItDeveloper.Mvc.Models;

namespace Cooperchip.ItDeveloper.Mvc.Services
{
    public class PacienteService
    {
       

        public Paciente ObterPacientePorId(string id)
        {
            return new Paciente()
            {
                Nome = "Juliano",
                Cpf = "53972058",
                
                
            };
        }
    }
}
