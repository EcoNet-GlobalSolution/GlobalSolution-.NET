using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GlobalSolution_.NET.Models;
using GlobalSolution_.NET.Persistence;
using GlobalSolution_.NET.Repositories;

namespace GlobalSolution_.NET.Controllers
{
    public class CoordenadasController : Controller
    {
        private readonly ICoordenadasRepository _coordenadasRepository;

        public CoordenadasController(ICoordenadasRepository coordenadasRepository)
        {
            _coordenadasRepository = coordenadasRepository;
        }

        public IActionResult Index()
        {
            List<CoordenadasModel> coordenadas = _coordenadasRepository.BuscarTodos();
            return View(coordenadas);
        }

        public async Task<IActionResult> Details(int id_coordenadas)
        {
            if (id_coordenadas == null)
            {
                return NotFound();
            }

            CoordenadasModel coordenadas = _coordenadasRepository.ListarPorId(id_coordenadas);

            if (coordenadas == null)
            {
                return NotFound();
            }

            return View(coordenadas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CoordenadasModel coordenadas)
        {
            if (ModelState.IsValid)
            {
                _coordenadasRepository.Adicionar(coordenadas);
                int id_coordenadas = coordenadas.id_coordenadas;
                return RedirectToAction("Create", "Tiporisco", new { id_coordenadas });
            }
            return View(coordenadas);
        }

        public IActionResult Edit(int id_coordenadas)
        {
            CoordenadasModel coordenadas = _coordenadasRepository.ListarPorId(id_coordenadas);
            return View(coordenadas);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CoordenadasModel coordenadas)
        {
            _coordenadasRepository.Atualizar(coordenadas);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id_coordenadas)
        {
            _coordenadasRepository.Apagar(id_coordenadas);
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id_coordenadas)
        {
            CoordenadasModel coordenadas = _coordenadasRepository.ListarPorId(id_coordenadas);
            return View(coordenadas);
        }

        //private bool CoordenadasModelExists(int id)
        //{
        //    return _context.Coordenadas.Any(e => e.id_coordenadas == id);
        //}
    }
}
