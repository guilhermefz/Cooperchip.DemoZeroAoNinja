using Cooperchip.ItDeveloper.Mvc.Models;

namespace Cooperchip.ItDeveloper.Mvc.Services
{
    public class PacienteService
    {
       

        public PacienteTeste ObterPacientePorId(string id)
        {
            return new PacienteTeste()
            {
                Nome = "Juliano",
                Cpf = "53972058",
                Telefones = new List<Telefone>()
                {
                    new Telefone() {
                    Id = Guid.NewGuid(),
                    Numero = "5832937",
                    TipoDeTelefone = "Comercial"
                    }
                }
            };
        }
    }
}
