using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Libero;
using AutoMapper;
using WebLibero.ViewModels.Veiculos;
using Libero.Interfaces;
using Libero.Repositorios;

namespace WebLibero.Controllers
{
        [Authorize]
    public class FabricantesController : Controller
    {

        IRepoFabricante repo = new RepoFabricante();
        // GET: Fabricantes
        
        public ActionResult Index()
        {
            List<Fabricante> veic = repo.LerTodosFabricante();
            List<Fabricante_vm> veicVM = new List<Fabricante_vm>();

            foreach (var item in veic)
            {
                Fabricante_vm f = Mapper.Map<Fabricante, Fabricante_vm>(item);
                veicVM.Add(f);
                
            }

            return View(veicVM);
        }

        // GET: Fabricantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabricante fabricante = repo.LerFabricante(id);
            Fabricante_vm f = Mapper.Map<Fabricante, Fabricante_vm>(fabricante);

            if (f == null)
            {
                return HttpNotFound();
            }
            return View(f);
        }

        // GET: Fabricantes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fabricantes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fabricante_vm f)
        {
            if (ModelState.IsValid)
            {
                Fabricante fab = Mapper.Map<Fabricante_vm, Fabricante>(f);
                repo.CadastrarFabricante(fab);
                return RedirectToAction("Index");
            }

            return View(f);
        }

        // GET: Fabricantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabricante fabricante = repo.LerFabricante(id);
            Fabricante_vm f = Mapper.Map<Fabricante, Fabricante_vm>(fabricante);
            if (f == null)
            {
                return HttpNotFound();
            }
            return View(f);
        }

        //// POST: Fabricantes/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Fabricante_vm f)
        {
            Fabricante fabricante = Mapper.Map<Fabricante_vm, Fabricante>(f);
            if (ModelState.IsValid)
            {

                repo.ModificarFabricante(fabricante);

                return RedirectToAction("Index");
            }
            return View(fabricante);
        }

        // GET: Fabricantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabricante fabricante = repo.LerFabricante(id);
            Fabricante_vm f = Mapper.Map<Fabricante, Fabricante_vm>(fabricante);
            if (fabricante == null)
            {
                return HttpNotFound();
            }
            return View(f);
        }

        // POST: Fabricantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repo.ExcluirFabricante(id);

            return RedirectToAction("Index");
        }
    }
}
