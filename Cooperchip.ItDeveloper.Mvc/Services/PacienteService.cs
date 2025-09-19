using AutoMapper;
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
        private readonly IMapper _mapper;

        public PacienteService(ITDeveloperDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task SalvarPacienteAsync(Paciente paciente)
        {
             _context.Set<Paciente>().Add(paciente);
            await _context.SaveChangesAsync();
        }



        public async Task<List<Paciente>> BuscarPacientesAsync()
        {
            var viewmodel = await _context.Paciente.Include(x => x.EstadoPaciente).AsNoTracking().ToListAsync();
            return viewmodel;
        }

        public async Task<Paciente> BuscarPacientePorIdAsync(Guid id)
        {
            var paciente = await _context.Paciente.Include(x => x.EstadoPaciente).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return await Task.FromResult(paciente);
        }

        public async Task<List<PacienteViewModel>> BuscarPacientesPorEstadoAsync(Guid estadoPacienteId)
        {
            var pacientes = await _context.Paciente.Include(x => x.EstadoPaciente).AsNoTracking().Where(x => x.EstadoPaciente.Id == estadoPacienteId)
            .OrderBy(OrderedParallelQuery => OrderedParallelQuery.Nome).ToListAsync();
            List<PacienteViewModel> listViewModel = new();

            foreach (var item in pacientes)
            {
                listViewModel.Add (_mapper.Map<PacienteViewModel>(item));
            }
            return listViewModel;
        }

        public async Task<PacienteViewModel> PacienteDetalhe(Guid id)
        {
            var paciente = await _context.Paciente.Include(x => x.EstadoPaciente).AsNoTracking().FirstOrDefaultAsync(x=> x.Id == id);
            var viewModel = _mapper.Map<PacienteViewModel>(paciente);

            return viewModel;
        }
        public bool TemPaciente(Guid pacienteId)
        {
            return _context.Paciente.Any(x => x.Id == pacienteId);
        }

        public async Task<List<EstadoPaciente>> ListarEstadoPaciente()
        {
            return await _context.EstadoPaciente.AsNoTracking().ToListAsync();
        }


        public async Task Editar(Paciente paciente)
        {
            _context.Entry(paciente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Deletar(Paciente paciente)
        {
            _context.Remove(paciente);
            await _context.SaveChangesAsync();
        }
    }
}
