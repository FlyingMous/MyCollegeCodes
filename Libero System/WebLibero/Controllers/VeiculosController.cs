using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using WebLibero.ViewModels.Veiculos;
using Libero.Interfaces;
using Libero.Repositorios;
using Libero;

namespace WebLibero.Controllers
{
    [Authorize]
    public class VeiculosController : Controller
    {
        IRepoVeiculo repo = new RepoVeiculo();
        IRepoModelo repo_mod = new RepoModelo();

        // GET: Veiculos
        public ActionResult Index()
        {
            List<Veiculo> veic = repo.LerTodosVeiculo();
            List<Veiculo_vm> veicVM = new List<Veiculo_vm>();

            foreach (var item in veic)
            {
                Veiculo_vm c = Mapper.Map<Veiculo, Veiculo_vm>(item);
                veicVM.Add(c);

            }

            return View(veicVM);
        }

        // GET: Veiculos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veiculo cliente = repo.LerVeiculo(id);
            Veiculo_vm veiculo = Mapper.Map<Veiculo, Veiculo_vm>(cliente);

            if (veiculo == null)
            {
                return HttpNotFound();
            }
            return View(veiculo);
        }

        // GET: Veiculos/Create
        public ActionResult Create()
        {
            CadastroVeiculo_vm veic_vm = new CadastroVeiculo_vm();
            veic_vm.Modelos = new SelectList(repo_mod.LerTodosModelo(), "ModeloId", "Nome");

            return View(veic_vm);

        }

        // POST: Veiculos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VeiculoId,AnoFab,Placa,Quilometragem,Cor,TipoVeiculo,Chassi,ModeloId")] CadastroVeiculo_vm veic_vm)
        {
            if (ModelState.IsValid)
            {
                Veiculo v = Mapper.Map<CadastroVeiculo_vm, Veiculo>(veic_vm);
                repo.CadastrarVeiculo(v);
                return RedirectToAction("Index");
            }
            return View(veic_vm);
        }

        // GET: Veiculos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veiculo veiculo = repo.LerVeiculo(id);
            CadastroVeiculo_vm m = Mapper.Map<Veiculo, CadastroVeiculo_vm>(veiculo);
            if (veiculo == null)
            {
                return HttpNotFound();
            }
            //ViewBag.ModeloId = new SelectList(db.Modelos, "ModeloId", "Nome", veiculo.ModeloId);
            return View();
        }

        // POST: Veiculos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VeiculoId,AnoFab,ModeloId,Placa,Quilometragem,Cor,TipoVeiculo,Chassi")] Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                repo.ModificarVeiculo(veiculo);
                return RedirectToAction("Index");
            }
            //ViewBag.ModeloId = new SelectList(db.Modelos, "ModeloId", "Nome", veiculo.ModeloId);
            return View(veiculo);
        }

        // GET: Veiculos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veiculo veiculo = repo.LerVeiculo(id);
            if (veiculo == null)
            {
                return HttpNotFound();
            }
            return View(veiculo);
        }

        // POST: Veiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repo.ExcluirVeiculo(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
