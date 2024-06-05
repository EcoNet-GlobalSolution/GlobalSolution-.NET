using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GlobalSolution_.NET.Models;
using GlobalSolution_.NET.Persistence;

namespace GlobalSolution_.NET.Controllers
{
    public class CoordenadasController : Controller
    {
        private readonly OracleDbContext _context;

        public CoordenadasController(OracleDbContext context)
        {
            _context = context;
        }

        // GET: Coordenadas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Coordenadas.ToListAsync());
        }

        // GET: Coordenadas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coordenadasModel = await _context.Coordenadas
                .FirstOrDefaultAsync(m => m.id_coordenadas == id);
            if (coordenadasModel == null)
            {
                return NotFound();
            }

            return View(coordenadasModel);
        }

        // GET: Coordenadas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Coordenadas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_coordenadas,longitude,latitude")] CoordenadasModel coordenadasModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coordenadasModel);
                await _context.SaveChangesAsync();
                int id_coordenadas = coordenadasModel.id_coordenadas;
                return RedirectToAction("Create", "Tiporisco", new { id_coordenadas });
            }
            return View(coordenadasModel);
        }

        // GET: Coordenadas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coordenadasModel = await _context.Coordenadas.FindAsync(id);
            if (coordenadasModel == null)
            {
                return NotFound();
            }
            return View(coordenadasModel);
        }

        // POST: Coordenadas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_coordenadas,longitude,latitude")] CoordenadasModel coordenadasModel)
        {
            if (id != coordenadasModel.id_coordenadas)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coordenadasModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoordenadasModelExists(coordenadasModel.id_coordenadas))
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
            return View(coordenadasModel);
        }

        // GET: Coordenadas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coordenadasModel = await _context.Coordenadas
                .FirstOrDefaultAsync(m => m.id_coordenadas == id);
            if (coordenadasModel == null)
            {
                return NotFound();
            }

            return View(coordenadasModel);
        }

        // POST: Coordenadas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coordenadasModel = await _context.Coordenadas.FindAsync(id);
            if (coordenadasModel != null)
            {
                _context.Coordenadas.Remove(coordenadasModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoordenadasModelExists(int id)
        {
            return _context.Coordenadas.Any(e => e.id_coordenadas == id);
        }
    }
}
