using AutoMapper;
using Cooperchip.ItDeveloper.Domain.Entities;
using Cooperchip.ItDeveloper.Mvc.Models;
using Cooperchip.ItDeveloper.Mvc.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            Paciente paciente = await _pacienteService.BuscarPacientePorIdAsync(id);
            if(paciente is null)
            {
                return NotFound();
            }

            ViewBag.EstadoPaciente = new SelectList(await _pacienteService.ListarEstadoPaciente(), "Id", "Descricao");

            return View(_mapper.Map<PacienteViewModel>(paciente));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, PacienteViewModel model)
        {
            if (model.Id != id)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                try
                {
                    var paciente = _mapper.Map<Paciente>(model);
                    await _pacienteService.Editar(paciente);
                    TempData["Sucesso"] = "Regitro Cadastrado com Sucesso!"; 
                    RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_pacienteService.TemPaciente(model.Id))
                    {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                } catch (Exception ex) {
                    return BadRequest(ex.Message);
                }
            }
            ViewBag.EstadoPaciente = new SelectList(await _pacienteService.ListarEstadoPaciente(), "Id", "Descricao");
            return View(model);
                    

        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            Paciente paciente = await _pacienteService.BuscarPacientePorIdAsync(id);
            if (paciente is null)
            {
                return NotFound();
            }
            return View(_mapper.Map<PacienteViewModel>(paciente));
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            Paciente paciente = await _pacienteService.BuscarPacientePorIdAsync(id);
            if(paciente is null)
            {
                TempData["Error"] = "Erro ao tentar excluir registro";
                return NotFound();
            }

            await _pacienteService.Deletar(paciente);
            TempData["Sucesso"] = "Registro Deletado com Sucesso!";
            return Redirect(nameof(Index));
        }





    }
}
