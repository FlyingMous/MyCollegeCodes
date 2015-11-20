using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Libero;
using WebLibero.ViewModels.Veiculos;
using AutoMapper;
using Libero.Repositorios;
using Libero.Interfaces;

namespace WebLibero.Controllers
{
    [Authorize]
    public class ModelosController : Controller
    {
        IRepoModelo repo = new RepoModelo();
        IRepoFabricante repo_fab = new RepoFabricante();

        // GET: Modelos
        public ActionResult Index()
        {

            List<Modelo> mod = repo.LerTodosModelo();
            List<Modelo_vm> modVM = new List<Modelo_vm>();

            foreach (var item in mod)
            {
                Modelo_vm m = Mapper.Map<Modelo, Modelo_vm>(item);
                modVM.Add(m);

            }

            return View(modVM);
        }

        // GET: Modelos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modelo modelo = repo.LerModelo(id);
            Modelo_vm m = Mapper.Map<Modelo, Modelo_vm>(modelo);
            if (m == null)
            {
                return HttpNotFound();
            }
            return View(m);
        }

        // GET: Modelos/Create
        public ActionResult Create()
        {
            Modelo_vm modelo_vm = new Modelo_vm();
            modelo_vm.Fabricantes = new SelectList(repo_fab.LerTodosFabricante(), "FabricanteId", "Nome");
            return View(modelo_vm);
        }

        // POST: Modelos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ModeloId,Nome,FabricanteId")]Modelo_vm modelo_vm)
        {
            if (ModelState.IsValid)
            {//fazer a mesma coisa que eu fiz no create do cliente
                
                Modelo m = Mapper.Map<Modelo_vm, Modelo>(modelo_vm);
               
                repo.CadastrarModelo(m);
                return RedirectToAction("Index");
                
            }

            return View(modelo_vm);


        }
 
        // GET: Modelos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modelo modelo = repo.LerModelo(id);
            Modelo_vm m = Mapper.Map<Modelo, Modelo_vm>(modelo);

            
            if (modelo == null)
            {
                return HttpNotFound();
            }

                        
            return View(m);
        }

        // POST: Modelos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Modelo modelo)
        {
            if (ModelState.IsValid)
            {
                repo.ModificarModelo(modelo);
                return RedirectToAction("Index");
            }

            return View(modelo);
        }

        // GET: Modelos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modelo modelo = repo.LerModelo(id);
            Modelo_vm mod = Mapper.Map<Modelo, Modelo_vm>(modelo);
            if (mod == null)
            {
                return HttpNotFound();
            }
            return View(mod);
        }

        // POST: Modelos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            repo.ExcluirModelo(id);
            return RedirectToAction("Index");
        }
        
    }
}
