using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyect_RaceTrack.Data;
using Proyect_RaceTrack.Models;
using Proyect_RaceTrack.ViewModels.CocheraViewModels;
using Proyect_RaceTrack.Services;
using Proyect_RaceTrack.ViewModels;
using Proyect_RaceTrack.ViewModels.PistaViewModels;

namespace Proyect_RaceTrack.Controllers
{
    public class CocheraController : Controller
    {
        private ICocheraService _cocheraService;

        public CocheraController(ICocheraService cocheraService)
        {
            _cocheraService = cocheraService;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyect_RaceTrack.Data;
using Proyect_RaceTrack.Models;
using Proyect_RaceTrack.ViewModels.CocheraViewModels;
using Proyect_RaceTrack.Services;
using Proyect_RaceTrack.ViewModels;
using Proyect_RaceTrack.ViewModels.PistaViewModels;

namespace Proyect_RaceTrack.Controllers
{
    public class CocheraController : Controller
    {
        private ICocheraService _cocheraService;
        private IPistaService _pistaService;

        public CocheraController(ICocheraService cocheraService, IPistaService pistaService)
        {
            _cocheraService = cocheraService;
            _pistaService = pistaService;
        }

        // GET: Cochera
        public IActionResult Index(string NameFilterCoc)
        {
            var model = new CocheraIndexViewModel();
            model.cocheras = _cocheraService.GetAll(NameFilterCoc);

            return View(model);

        }

        // GET: Cochera/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cochera = _cocheraService.GetById(id.Value);
            // .FirstOrDefaultAsync(m => m.AeronaveId == id);
            if (cochera == null)
            {
                return NotFound();
            }

            var viewModel = new CocheraDetailViewModel();
            viewModel.CocheraNombre = cochera.CocheraNombre;
            viewModel.CocheraNumero = cochera.CocheraNumero;
            viewModel.CocheraSector = cochera.CocheraSector;
            viewModel.CocheraAptoMantenimiento = cochera.CocheraAptoMantenimiento;
            viewModel.CocheraOficinas = cochera.CocheraOficinas;
            //viewModel.Pistas = hangar.Pistas;

            return View(viewModel);
        }

        // GET: Cochera/Create
        public IActionResult Create()
        {
            // ViewData["Pistas"] = new SelectList(_context.Pista.ToList(),"PistaId","PistaNombre");
            //ViewData["Pistas"] = new SelectList(_pistaService.GetAll(), "PistaId", "PistaNombre", "nameFilterPista");
            ViewData["Pistas"] = new SelectList(_pistaService.GetAll(), "PistaId", "PistaNombre", "nameFilterPista");
            return View();
        }