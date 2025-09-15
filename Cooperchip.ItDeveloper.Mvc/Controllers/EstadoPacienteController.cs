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
            return View(model);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EstadoPaciente estadoPaciente)
        {
            if (ModelState.IsValid)
            {
                estadoPaciente.Id = Guid.NewGuid();
                _context.Add(estadoPaciente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(estadoPaciente);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _context.EstadoPaciente.FindAsync(id);

            if (model == null)
                return NotFound();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, EstadoPaciente estadoPaciente)
        {
            if (id != estadoPaciente.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadoPaciente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException e)
                {
                    if (!EstadoPacienteExist(estadoPaciente.Id))
                    {
                        return NotFound(e.Message);
                    }
                    else
                        throw new Exception(e.Message);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(estadoPaciente);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var estadoPaciente = await _context.EstadoPaciente.FirstOrDefaultAsync(m => m.Id == id);

            return estadoPaciente switch
            {
                null => NotFound(),
                _ => View(estadoPaciente)
            };
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var estadoPaciente = await _context.EstadoPaciente.FirstOrDefaultAsync(m => m.Id == id);
            try
            {
                _context.EstadoPaciente.Remove(estadoPaciente);
                await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return RedirectToAction(nameof(Index));
        }




        private bool EstadoPacienteExist(Guid id)
        {
            return _context.EstadoPaciente.Any(x => x.Id == id);
        }
    }
}
