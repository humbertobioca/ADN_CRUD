using ApnCore_Crud.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ApnCore_Crud.Controllers
{
    public class ParticipanteController : Controller
    {
        private readonly IParticipanteDAL funci;
        public ParticipanteController(IParticipanteDAL participante)
        {
            funci = participante;
        }

        public IActionResult Index()
        {
            List<Participante> listaParticipantes = new List<Participante>();
            listaParticipantes = funci.GetAllParticipantes().ToList();

            return View(listaParticipantes);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Participante participante = funci.GetParticipante(id);

            if (participante == null)
            {
                return NotFound();
            }
            return View(participante);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Participante participante)
        {
            if (ModelState.IsValid)
            {
                funci.AddParticipante(participante);
                return RedirectToAction("Index");
            }
            return View(participante);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Participante participante = funci.GetParticipante(id);

            if (participante == null)
            {
                return NotFound();
            }
            return View(participante);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind]Participante participante)
        {
            if (id != participante.PPCODPAT)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                funci.UpdateParticipante(participante);
                return RedirectToAction("Index");
            }
            return View(participante);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Participante participante = funci.GetParticipante(id);

            if (participante == null)
            {
                return NotFound();
            }
            return View(participante);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            funci.DeleteParticipante(id);
            return RedirectToAction("Index");
        }
    }
}