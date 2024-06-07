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
using GlobalSolution_.NET.Repositories;

namespace GlobalSolution_.NET.Controllers
{
    public class TiporiscoController : Controller
    {
        private readonly ITiporiscoRepository _tiporiscoRepository;

        public TiporiscoController(ITiporiscoRepository tiporiscoRepository)
        {
            _tiporiscoRepository = tiporiscoRepository;
        }

        public IActionResult Index()
        {
            List<TiporiscoModel> tiporiscos = _tiporiscoRepository.BuscarTodos();
            return View(tiporiscos);
        }

        public async Task<IActionResult> Details(int id_risco)
        {
            if (id_risco == null)
            {
                return NotFound();
            }

            TiporiscoModel tiporiscos = _tiporiscoRepository.ListarPorId(id_risco);

            if (tiporiscos == null)
            {
                return NotFound();
            }

            return View(tiporiscos);
        }

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TiporiscoModel tiporiscos, int id_coordenadas)
        {
            if (ModelState.IsValid)
            {
                _tiporiscoRepository.Adicionar(tiporiscos);
                int id_risco = tiporiscos.id_risco;
                return RedirectToAction("Create", "Especie", new { id_risco, id_coordenadas });
            }
            return View(tiporiscos);
        }

        public IActionResult Edit(int id_risco)
        {
            TiporiscoModel tiporiscos = _tiporiscoRepository.ListarPorId(id_risco);
            ViewBag.CategoriaRisco = Enum.GetValues(typeof(CategoriaRisco)).Cast<CategoriaRisco>().Select(e => new SelectListItem
            {
                Value = e.ToString(),
                Text = e.ToString()
            }).ToList();
            return View(tiporiscos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TiporiscoModel tiporiscos)
        {
            _tiporiscoRepository.Atualizar(tiporiscos);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id_risco)
        {
            _tiporiscoRepository.Apagar(id_risco);
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id_risco)
        {
            TiporiscoModel tiporiscos = _tiporiscoRepository.ListarPorId(id_risco);
            return RedirectToAction(nameof(Index));
        }

        //private bool TiporiscoModelExists(int id)
        //{
        //    return _context.Tiporisco.Any(e => e.id_risco == id);
        //}
    }
}