using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Race_Track.Data;
using herramientas_parcial1_OliveraJorgeDaniel.Models;
using herramientas_parcial1_OliveraJorgeDaniel.ViewModels.PilotoViewModels;
using herramieltas_parcial_OliveraJorteDaniel.Services;

namespace herramientas_parcial1_OliveraJorgeDaniel.Controllers
{
    public class PilotoController : Controller
    {
        private readonly IPilotoService _pilotoService;
        private readonly IVehiculoService _vehiculoService;
        public PilotoController(IPilotoService pilotoService, IVehiculoService vehiculoService)
        {
            _pilotoService = pilotoService;
            _vehiculoService = vehiculoService;
        }

        // GET: Piloto
        public IActionResult Index(string nameFilterIns)
        {

            var model = new PilotoIndexViewModel();
            model.pilotos = _pilotoService.GetAll(nameFilterIns);

            return View(model);

        }

        // GET: Piloto/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var piloto = _pilotoService.GetById(id.Value);
            if (piloto == null)
            {
                return NotFound();
            }
            var viewModel = new PilotoDetailViewModel();
            viewModel.PilotoNombre = piloto.PilotoNombre;
            viewModel.PilotoApellido = piloto.PilotoApellido;
            viewModel.PilotoDni = piloto.PilotoDni;
            viewModel.PilotoNumeroLicencia = piloto.PilotoNumeroLicencia;
            viewModel.PilotoExpedicion = piloto.PilotoExpedicion;
            viewModel.PilotoPropietario = piloto.PilotoPropietario;
            viewModel.VehiculoId = piloto.VehiculoId;

            return View(viewModel);
        }

        // GET: Piloto/Create
        public IActionResult Create()
        {
            ViewData["VehiculoId"] = new SelectList(_vehiculoService.GetAll(), "VehiculoId", "VehiculoTipo", "nameFilter");
            return View();
        }

        // POST: Piloto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("PilotoId, PilotoNombre, PilotoApellido, PilotoDni, PilotoNumeroLicencia, PilotoExpedicion, PilotoPropietar, VehiculoId")] PilotoCreateViewModel pilotoView)
        {
            if (ModelState.IsValid)
            {
                var instructor = new Piloto
                {
                    PilotoNombre = pilotoView.PilotoNombre,
                    PilotoApellido = pilotoView.PilotoApellido,
                    PilotoDni = pilotoView.PilotoDni,
                    PilotoNumeroLicencia = pilotoView.PilotoNumeroLicencia,
                    PilotoExpedicion = pilotoView.PilotoExpedicion,
                    VehiculoId = pilotoView.VehiculoId

                };
                _pilotoService.Create(instructor);
                return RedirectToAction(nameof(Index));
            }
            return View(pilotoView);
        }

        // GET: Piloto/Edit/5      
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var piloto = _pilotoService.GetById(id.Value);
            if (piloto == null)
            {
                return NotFound();
            }

            var viewModel = new PilotoEditViewModel();
            viewModel.PilotoNombre = piloto.PilotoNombre;
            viewModel.PilotoApellido = piloto.PilotoApellido;
            viewModel.PilotoDni = piloto.PilotoDni;
            viewModel.PilotoNumeroLicencia = piloto.PilotoNumeroLicencia;
            viewModel.PilotoExpedicion = piloto.PilotoExpedicion;
            viewModel.PilotoPropietario = piloto.PilotoPropietario;
            viewModel.VehiculoId = piloto.VehiculoId;

            ViewData["VehiculoId"] = new SelectList(_vehiculoService.GetAll(), "VehiculoId", "VehiculoTipo", "nameFilter");
            return View(viewModel);
        }
        // POST: Piloto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("PilotoId, PilotoNombre, PilotoApellido, PilotoDni, PilotoNumeroLicencia, PilotoExpedicion, PilotoPropietar, VehiculoId")] Piloto pilotoView)
        {
            if (id != pilotoView.VehiculoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _pilotoService.Update(pilotoView);
                return RedirectToAction(nameof(Index));
            }
            return View(pilotoView);
        }

        // GET: Piloto/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var piloto = _pilotoService.GetById(id.Value);
            if (piloto == null)
            {
                return NotFound();
            }
            var viewModel = new PilotoDeleteViewModel();
            viewModel.PilotoNombre = piloto.PilotoNombre;
            viewModel.PilotoApellido = piloto.PilotoApellido;
            viewModel.PilotoDni = piloto.PilotoDni;
            viewModel.PilotoNumeroLicencia = piloto.PilotoNumeroLicencia;
            viewModel.PilotoExpedicion = piloto.PilotoExpedicion;
            viewModel.PilotoPropietario = piloto.PilotoPropietario;
            viewModel.VehiculoId = piloto.VehiculoId;

            return View(viewModel);
        }

        // POST: Instructor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {

            var aeronave = _pilotoService.GetById(id);
            if (aeronave != null)
            {
                _pilotoService.Delete(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool AeronaveExists(int id)
        {
            return _pilotoService.GetById(id) != null;
        }
    }
}
