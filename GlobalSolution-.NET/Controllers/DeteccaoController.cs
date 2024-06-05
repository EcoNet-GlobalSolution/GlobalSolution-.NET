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
    public class DeteccaoController : Controller
    {
        private readonly OracleDbContext _context;

        public DeteccaoController(OracleDbContext context)
        {
            _context = context;
        }

        // GET: Deteccao
        public async Task<IActionResult> Index()
        {
            var oracleDbContext = _context.Deteccao.Include(d => d.Coordenadas).Include(d => d.Especie);
            return View(await oracleDbContext.ToListAsync());
        }

        // GET: Deteccao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deteccaoModel = await _context.Deteccao
                .Include(d => d.Coordenadas)
                .Include(d => d.Especie)
                .FirstOrDefaultAsync(m => m.id_deteccao == id);
            if (deteccaoModel == null)
            {
                return NotFound();
            }

            return View(deteccaoModel);
        }

        // GET: Deteccao/Create
        public IActionResult Create(int id_especie, int id_coordenadas)
        {
            ViewBag.id_especie = id_especie;
            ViewBag.id_coordenadas = id_coordenadas;
            return View();
        }

        // POST: Deteccao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_deteccao,data,id_coordenadas,id_especie")] DeteccaoModel deteccaoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deteccaoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["id_coordenadas"] = new SelectList(_context.Coordenadas, "id_coordenadas", "id_coordenadas", deteccaoModel.id_coordenadas);
            ViewData["id_especie"] = new SelectList(_context.Especie, "id_especie", "especie", deteccaoModel.id_especie);
            return View(deteccaoModel);
        }

        // GET: Deteccao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deteccaoModel = await _context.Deteccao.FindAsync(id);
            if (deteccaoModel == null)
            {
                return NotFound();
            }
            ViewData["id_coordenadas"] = new SelectList(_context.Coordenadas, "id_coordenadas", "id_coordenadas", deteccaoModel.id_coordenadas);
            ViewData["id_especie"] = new SelectList(_context.Especie, "id_especie", "especie", deteccaoModel.id_especie);
            return View(deteccaoModel);
        }

        // POST: Deteccao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_deteccao,data,id_coordenadas,id_especie")] DeteccaoModel deteccaoModel)
        {
            if (id != deteccaoModel.id_deteccao)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deteccaoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeteccaoModelExists(deteccaoModel.id_deteccao))
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
            ViewData["id_coordenadas"] = new SelectList(_context.Coordenadas, "id_coordenadas", "id_coordenadas", deteccaoModel.id_coordenadas);
            ViewData["id_especie"] = new SelectList(_context.Especie, "id_especie", "especie", deteccaoModel.id_especie);
            return View(deteccaoModel);
        }

        // GET: Deteccao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deteccaoModel = await _context.Deteccao
                .Include(d => d.Coordenadas)
                .Include(d => d.Especie)
                .FirstOrDefaultAsync(m => m.id_deteccao == id);
            if (deteccaoModel == null)
            {
                return NotFound();
            }

            return View(deteccaoModel);
        }

        // POST: Deteccao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deteccaoModel = await _context.Deteccao.FindAsync(id);
            if (deteccaoModel != null)
            {
                _context.Deteccao.Remove(deteccaoModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeteccaoModelExists(int id)
        {
            return _context.Deteccao.Any(e => e.id_deteccao == id);
        }
    }
}
