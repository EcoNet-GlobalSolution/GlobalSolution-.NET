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
    public class EspecieController : Controller
    {
        private readonly OracleDbContext _context;

        public EspecieController(OracleDbContext context)
        {
            _context = context;
        }

        // GET: Especie
        public async Task<IActionResult> Index()
        {
            return View(await _context.Especie.ToListAsync());
        }

        // GET: Especie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especieModel = await _context.Especie
                .FirstOrDefaultAsync(m => m.id_especie == id);
            if (especieModel == null)
            {
                return NotFound();
            }

            return View(especieModel);
        }

        // GET: Especie/Create
        public IActionResult Create(int id_risco, int id_coordenadas)
        {
            ViewBag.id_risco = id_risco;
            ViewBag.id_coordenadas = id_coordenadas;
            return View();
        }

        // POST: Especie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_especie,nome_comum,especie,id_risco")] EspecieModel especieModel, int id_coordenadas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(especieModel);
                await _context.SaveChangesAsync();
                int id_especie = especieModel.id_especie;
                return RedirectToAction("Create", "Deteccao", new { id_especie, id_coordenadas });
            }
            return View(especieModel);
        }

        // GET: Especie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especieModel = await _context.Especie.FindAsync(id);
            if (especieModel == null)
            {
                return NotFound();
            }
            return View(especieModel);
        }

        // POST: Especie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_especie,nome_comum,especie,id_risco")] EspecieModel especieModel)
        {
            if (id != especieModel.id_especie)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(especieModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EspecieModelExists(especieModel.id_especie))
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
            return View(especieModel);
        }

        // GET: Especie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especieModel = await _context.Especie
                .FirstOrDefaultAsync(m => m.id_especie == id);
            if (especieModel == null)
            {
                return NotFound();
            }

            return View(especieModel);
        }

        // POST: Especie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var especieModel = await _context.Especie.FindAsync(id);
            if (especieModel != null)
            {
                _context.Especie.Remove(especieModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EspecieModelExists(int id)
        {
            return _context.Especie.Any(e => e.id_especie == id);
        }
    }
}
