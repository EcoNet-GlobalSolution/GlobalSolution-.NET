using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GlobalSolution_.NET.Models;
using GlobalSolution_.NET.Persistence;
using GlobalSolution_.NET.Enums;

namespace GlobalSolution_.NET.Controllers
{
    public class TiporiscoController : Controller
    {
        private readonly OracleDbContext _context;

        public TiporiscoController(OracleDbContext context)
        {
            _context = context;
        }

        // GET: Tiporisco
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tiporisco.ToListAsync());
        }

        // GET: Tiporisco/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiporiscoModel = await _context.Tiporisco
                .FirstOrDefaultAsync(m => m.id_risco == id);
            if (tiporiscoModel == null)
            {
                return NotFound();
            }

            return View(tiporiscoModel);
        }

        // GET: Tiporisco/Create
        public IActionResult Create(int id_coordenadas, int id_risco)
        {
            var model = new TiporiscoModel
            {
                id_risco = id_risco,
            };
            ViewBag.id_coordenadas = id_coordenadas;
            ViewBag.CategoriaRisco = Enum.GetValues(typeof(CategoriaRisco)).Cast<CategoriaRisco>().Select(e => new SelectListItem
            {
                Value = e.ToString(),
                Text = e.ToString()
            }).ToList();

            return View(model);
        }

        // POST: Tiporisco/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_risco,categoria")] TiporiscoModel tiporiscoModel, int id_coordenadas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tiporiscoModel);
                await _context.SaveChangesAsync();
                int id_risco = tiporiscoModel.id_risco;
                return RedirectToAction("Create", "Especie", new { id_risco, id_coordenadas = id_coordenadas });
            }
            return View(tiporiscoModel);
        }

        // GET: Tiporisco/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiporiscoModel = await _context.Tiporisco.FindAsync(id);
            if (tiporiscoModel == null)
            {
                return NotFound();
            }
            return View(tiporiscoModel);
        }

        // POST: Tiporisco/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_risco,categoria")] TiporiscoModel tiporiscoModel)
        {
            if (id != tiporiscoModel.id_risco)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiporiscoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiporiscoModelExists(tiporiscoModel.id_risco))
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
            return View(tiporiscoModel);
        }

        // GET: Tiporisco/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiporiscoModel = await _context.Tiporisco
                .FirstOrDefaultAsync(m => m.id_risco == id);
            if (tiporiscoModel == null)
            {
                return NotFound();
            }

            return View(tiporiscoModel);
        }

        // POST: Tiporisco/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tiporiscoModel = await _context.Tiporisco.FindAsync(id);
            if (tiporiscoModel != null)
            {
                _context.Tiporisco.Remove(tiporiscoModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiporiscoModelExists(int id)
        {
            return _context.Tiporisco.Any(e => e.id_risco == id);
        }
    }
}
