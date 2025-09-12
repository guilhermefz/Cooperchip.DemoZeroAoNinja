using Cooperchip.ItDeveloper.Data.Data.ORM;
using Cooperchip.ItDeveloper.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cooperchip.ItDeveloper.Mvc.Controllers
{
    public class EstadoPacienteController : Controller
    {
        private readonly ITDeveloperDbContext _context;

        public EstadoPacienteController(ITDeveloperDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _context.EstadoPaciente.ToListAsync();
            return View(model );
        }

        public async Task<IActionResult> Details(Guid id)
        {
            try
            {
                var estadoPaciente = await _context.EstadoPaciente.FirstAsync(x => x.Id == id);
                    return View(estadoPaciente);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao tentar exibir o registro" + ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost("AdicionarEstado")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EstadoPaciente estadoPaciente)
        {
            if(ModelState.IsValid)
            {
                estadoPaciente.Id = Guid.NewGuid();
                _context.Add(estadoPaciente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }
    }
}
