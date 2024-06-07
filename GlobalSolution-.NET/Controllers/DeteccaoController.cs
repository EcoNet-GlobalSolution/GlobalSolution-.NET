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
    public class DeteccaoController : Controller
    {
        private readonly IDeteccaoRepository _deteccaoRepository;

        public DeteccaoController(IDeteccaoRepository deteccaoRepository)
        {
            _deteccaoRepository = deteccaoRepository;
        }

        public IActionResult Index()
        {
            List<DeteccaoModel> deteccoes = _deteccaoRepository.BuscarTodos();
            return View(deteccoes);
        }

        public async Task<IActionResult> Details(int id_deteccao)
        {
            if (id_deteccao == null)
            {
                return NotFound();
            }

            DeteccaoModel deteccoes = _deteccaoRepository.ListarPorId(id_deteccao);

            if (deteccoes == null)
            {
                return NotFound();
            }

            return View(deteccoes);
        }

        public IActionResult Create(int id_especie, int id_coordenadas)
        {
            var model = new DeteccaoModel
            {
                id_especie = id_especie,
                id_coordenadas = id_coordenadas
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DeteccaoModel deteccao)
        {
            if (ModelState.IsValid)
            {
                _deteccaoRepository.Adicionar(deteccao);
                return RedirectToAction("Index", "Especie");
            }
            return View(deteccao);
        }

        public IActionResult Edit(int id_deteccao)
        {
            DeteccaoModel deteccoes = _deteccaoRepository.ListarPorId(id_deteccao);
            return View(deteccoes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DeteccaoModel deteccoes)
        {
            _deteccaoRepository.Atualizar(deteccoes);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id_deteccao)
        {
            _deteccaoRepository.Apagar(id_deteccao);
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id_deteccao)
        {
            _deteccaoRepository.Apagar(id_deteccao);
            return RedirectToAction(nameof(Index));
        }

        //private bool DeteccaoModelExists(int id)
        //{
        //    return _context.Deteccao.Any(e => e.id_deteccao == id);
        //}
    }
}
