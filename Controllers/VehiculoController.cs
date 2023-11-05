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
using herramientas_parcial1_OliveraJorgeDaniel.Services;

using Proyect_RaceTrack.Services;

using Proyect_RaceTrack.ViewModels.VehiculoViewModels;

namespace Proyect_RaceTrack.Controllers
{
    public class VehiculoController : Controller
    {
        private IVehiculoService _vehiculoService;
        public VehiculoController(IVehiculoService vehiculoService)
        {
            _vehiculoService = vehiculoService;

        }

        // GET: Vehiculo
        public IActionResult Index(string nameFilter)
        {
            var model = new VehiculoIndexViewModel();
            model.vehiculos = _vehiculoService.GetAll(nameFilter);

            return View(model);

        }

        // GET: Vehiculo/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculo = _vehiculoService.GetById(id.Value);
            // .FirstOrDefaultAsync(m => m.AeronaveId == id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            var viewModel = new VehiculoDetailViewModel();
            viewModel.VehiculoNombre = vehiculo.VehiculoNombre;
            viewModel.VehiculoApellido = vehiculo.VehiculoApellido;
            viewModel.VehiculoMatricula = vehiculo.VehiculoMatricula;
            viewModel.VehiculoTipo = vehiculo.VehiculoTipo;
            viewModel.VehiculoFabricacion = vehiculo.VehiculoFabricacion;
            return View(viewModel);
        }

        // GET: Vehiculo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vehiculo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("VehiculoNombre,VehiculoApellido,VehiculoMatricula,VehiculoFabricacion, VehiculoTipo")] VehiculoCreateViewModel vehiculoView)
        {
            if (ModelState.IsValid)
            {
                var vehiculo = new Vehiculo
                {
                    VehiculoNombre = vehiculoView.VehiculoNombre,
                    VehiculoApellido = vehiculoView.VehiculoApellido,
                    VehiculoMatricula = vehiculoView.VehiculoMatricula,
                    VehiculoFabricacion = vehiculoView.VehiculoFabricacion,
                    VehiculoTipo = vehiculoView.VehiculoTipo,
                };

                _vehiculoService.Create(vehiculo);
                return RedirectToAction(nameof(Index));
            }
            return View(vehiculoView);
        }

        // GET: Vehiculo/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculo = _vehiculoService.GetById(id.Value);
            if (vehiculo == null)
            {
                return NotFound();
            }
            return View(vehiculo);

            // POST: Vehiculo/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to.
            // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VehiculoId,VehiculoNombre,VehiculoApellido,VehiculoTipo,VehiculoMatricula,VehiculoFabricacion")] Vehiculo vehiculo)
        {
            if (id != vehiculo.VehiculoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehiculo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehiculoExists(vehiculo.VehiculoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vehiculo);
        }

        // GET: Vehiculo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vehiculo == null)
            {
                return NotFound();
            }

            var vehiculo = await _context.Vehiculo
                .FirstOrDefaultAsync(m => m.VehiculoId == id);
            if (vehiculo == null)
            {
                return NotFound();
            }
            var viewModel = new VehiculoDeleteViewModel();
            viewModel.VehiculoNombre = vehiculo.VehiculoNombre;
            viewModel.VehiculoApellido = vehiculo.VehiculoApellido;
            viewModel.VehiculoFabricacion = vehiculo.VehiculoFabricacion;
            viewModel.VehiculoMatricula = vehiculo.VehiculoMatricula;

            return View(viewModel);
        }

        // POST: Vehiculo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vehiculo == null)
            {
                return Problem("Entity set 'VehiculoContext.Vehiculo'  is null.");
            }
            var vehiculo = await _context.Vehiculo.FindAsync(id);
            if (vehiculo != null)
            {
                _context.Vehiculo.Remove(vehiculo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehiculoExists(int id)
        {
            return (_context.Vehiculo?.Any(e => e.VehiculoId == id)).GetValueOrDefault();
        }
    }
}
