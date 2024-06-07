using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GlobalSolution_.NET.Models;
using GlobalSolution_.NET.Persistence;
using GlobalSolution_.NET.Repositories;

namespace GlobalSolution_.NET.Controllers
{
    public class EspecieController : Controller
    {
        private readonly IEspecieRepository _especieRepository;

        public EspecieController(IEspecieRepository especieRepository)
        {
            _especieRepository = especieRepository;
        }

        public IActionResult Index()
        {
            List<EspecieModel> especies = _especieRepository.BuscarTodos();
            return View(especies);
        }

        public async Task<IActionResult> Details(int id_especie)
        {
            if (id_especie == null)
            {
                return NotFound();
            }
                
                EspecieModel especie = _especieRepository.ListarPorId(id_especie);

            if (especie == null)
            {
                return NotFound();
            }

            return View(especie);
        }

        public IActionResult Create(int id_risco, int id_coordenadas)
        {
            var model = new EspecieModel
            {
                id_risco = id_risco,
            };
            ViewBag.id_coordenadas = id_coordenadas;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EspecieModel especies, int id_coordenadas)
        {
            if (ModelState.IsValid)
            {
                
                _especieRepository.Adicionar(especies);
                int id_especie = especies.id_especie;
                return RedirectToAction("Create", "Deteccao", new { id_especie, id_coordenadas });
            }
            return View(especies);
        }

        public IActionResult Edit(int id_especie)
        {
            EspecieModel especies = _especieRepository.ListarPorId(id_especie);
            return View(especies);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EspecieModel especies)
        {
            _especieRepository.Atualizar(especies);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id_especie)
        {
            _especieRepository.Apagar(id_especie);
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id_especie)
        {
            _especieRepository.Apagar(id_especie);
            return RedirectToAction(nameof(Index));
        }

        //private bool EspecieModelExists(int id)
        //{
        //    return _context.Especie.Any(e => e.id_especie == id);
        //}
    }
}
