using Cooperchip.ItDeveloper.Data.Data.ORM;
using Cooperchip.ItDeveloper.Domain.Entities;
using Cooperchip.ItDeveloper.Mvc.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Cooperchip.ItDeveloper.Mvc.Services
{
    public class PacienteService
    {
        private readonly ITDeveloperDbContext _context;  

        public PacienteService(ITDeveloperDbContext context)
        {
            _context = context;
        }
        public async Task<List<Paciente>> BuscarPacienteAsync()
        {
            var viewmodel = await _context.Paciente.Include(x => x.EstadoPaciente).AsNoTracking().ToListAsync();
            return viewmodel;
        }
    }
}
