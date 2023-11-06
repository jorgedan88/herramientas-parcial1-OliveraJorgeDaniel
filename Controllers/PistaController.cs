using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyect_RaceTrack.Data;
using Proyect_RaceTrack.Models;
using Proyect_RaceTrack.ViewModels.PistaViewModels;
using Proyect_RaceTrack.Services;
using Proyect_RaceTrack.ViewModels;

namespace Proyect_RaceTrack.Controllers
{
    public class PistaController : Controller
    {
        private IPistaService _pistaService;
        private ICocheraService _cocheraService;
        public PistaController(IPistaService pistaService, ICocheraService cocheraService)
        {
            _pistaService = pistaService;
            _cocheraService = cocheraService;
        }
        // GET: Pista
        public IActionResult Index(string nameFilterPista, [Bind("PistaId,PistaNombre,PistaCodigo,PistaMaterial,PistaIluminacion,PistaAprovisionamiento")] PistaIndexViewModel pistaView)
        {
            var model = new PistaIndexViewModel();
            model.pistas = _pistaService.GetAll(nameFilterPista);

            return View(model);
        }

        // GET: Pista/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pista = _pistaService.GetById(id.Value);
            // .FirstOrDefaultAsync(m => m.AeronaveId == id);
            if (pista == null)
            {
                return NotFound();
            }

            var viewModel = new PistaDetailViewModel();
            viewModel.PistaId = pista.PistaId;
            viewModel.PistaNombre = pista.PistaNombre;
            viewModel.PistaCodigo = pista.PistaCodigo;
            viewModel.PistaMaterial = pista.PistaMaterial;
            viewModel.PistaIluminacion = pista.PistaIluminacion;
            viewModel.PistaAprovisionamiento = pista.PistaAprovisionamiento;
            //viewModel.Hangars = await _context.Hangar.ToListAsync(); lo sugirio el IDE considerar

            return View(viewModel);
        }

        // GET: Pista/Create
        public IActionResult Create()
        {
            ViewData["Cocheras"] = new SelectList(_cocheraService.GetAll(), "CocheraId", "CocheraNombre", "nameFilterCoch");
            return View();
        }
    }
}

