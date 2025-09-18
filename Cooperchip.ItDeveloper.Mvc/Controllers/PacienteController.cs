using AutoMapper;
using Cooperchip.ItDeveloper.Domain.Entities;
using Cooperchip.ItDeveloper.Mvc.Models;
using Cooperchip.ItDeveloper.Mvc.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Cooperchip.ItDeveloper.Mvc.Controllers
{
    public class PacienteController : BaseController
    {
        private readonly PacienteService _pacienteService;
        private readonly IMapper _mapper;

        public PacienteController(PacienteService pacienteService, IMapper mapper)
        {
            _pacienteService = pacienteService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            return View(await _pacienteService.PacienteDetalhe(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetPacienteAsync(Guid id)
        {
            var paciente = await _pacienteService.BuscarPacientePorIdAsync(id);
            return View(paciente);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.EstadoPaciente = new SelectList(await _pacienteService.ListarEstadoPaciente(), "Id", "Descricao");
            return await Task.FromResult(View());
        }

        [HttpPost]
        public async Task<IActionResult> Create(PacienteViewModel model)
        {
            if(ModelState.IsValid)
            {

                var paciente = _mapper.Map<Paciente>(model);
                
                try
                {
                    await _pacienteService.SalvarPacienteAsync(paciente);
                    TempData["Sucesso"] = "Registro Cadastrado com Suceso!";
                    return Redirect(nameof(Index));
                }
                catch (Exception ex)
                {
                    return View(model);
                }
            }
            ViewBag.EstadoPaciente = new SelectList(await _pacienteService.ListarEstadoPaciente(), "Id", "Descricao");
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> ObterPacientesPorEstadoPaciente(Guid id)
        {
            var pacientes = await _pacienteService.BuscarPacientesPorEstadoAsync(id);
            return View(pacientes);
        }


        public async Task<IActionResult> Index()
        {
            var pacientes = await _pacienteService.BuscarPacientesAsync();
            List<PacienteViewModel> list = new();

            foreach ( var item in pacientes)
            {
                list.Add (_mapper.Map<PacienteViewModel>(item));
            }
            return View(list);
        }

        
        

    }
}
