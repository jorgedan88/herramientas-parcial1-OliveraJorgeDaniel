using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyect_RaceTrack.Data;
using Proyect_RaceTrack.Models;

namespace Proyect_RaceTrack.Controllers
{
    public class CalculadoraController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CalculadoraController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Calculadora
        public async Task<IActionResult> Index()
        {
              return _context.Calculadora != null ? 
                          View(await _context.Calculadora.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Calculadora'  is null.");
        }

        // GET: Calculadora/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Calculadora == null)
            {
                return NotFound();
            }

            var calculadora = await _context.Calculadora
                .FirstOrDefaultAsync(m => m.Id == id);
            if (calculadora == null)
            {
                return NotFound();
            }

            return View(calculadora);
        }

        // GET: Calculadora/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Calculadora/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Costo,Cantidad,Resultado")] Calculadora calculadora)
        {
            if (ModelState.IsValid)
            {
                _context.Add(calculadora);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(calculadora);
        }

        // GET: Calculadora/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Calculadora == null)
            {
                return NotFound();
            }

            var calculadora = await _context.Calculadora.FindAsync(id);
            if (calculadora == null)
            {
                return NotFound();
            }
            return View(calculadora);
        }

        // POST: Calculadora/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Costo,Cantidad,Resultado")] Calculadora calculadora)
        {
            if (id != calculadora.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calculadora);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalculadoraExists(calculadora.Id))
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
            return View(calculadora);
        }

        // GET: Calculadora/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Calculadora == null)
            {
                return NotFound();
            }

            var calculadora = await _context.Calculadora
                .FirstOrDefaultAsync(m => m.Id == id);
            if (calculadora == null)
            {
                return NotFound();
            }

            return View(calculadora);
        }

        // POST: Calculadora/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Calculadora == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Calculadora'  is null.");
            }
            var calculadora = await _context.Calculadora.FindAsync(id);
            if (calculadora != null)
            {
                _context.Calculadora.Remove(calculadora);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CalculadoraExists(int id)
        {
          return (_context.Calculadora?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
