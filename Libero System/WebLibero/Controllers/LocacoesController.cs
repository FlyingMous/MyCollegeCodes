using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Libero;
using WebLibero.ViewModels.Locacoes;
using AutoMapper;
using Libero.Interfaces;
using Libero.Repositorios;
using Repositorios.Servico;
using Repositorios.Interfaces;

namespace WebLibero.Controllers
{
    [Authorize]
    public class LocacoesController : Controller
    {
        ILocarDevolver locdev = new LocarDevolver();

        // GET: Locacoes
        public ActionResult Index()
        {
            return RedirectToAction("Create");

        }

        //// GET: Locacoes/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Locacao locacao = db.Locacoes.Find(id);
        //    if (locacao == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(locacao);
        //}

        // GET: Locacoes/Create
        public ActionResult Create()
        {
            IRepoCliente repo_cliente = new RepoCliente();
            IRepoVeiculo repo_veic = new RepoVeiculo();

            Locacao_vm loc_vm = new Locacao_vm();
            loc_vm.Cliente = new SelectList(repo_cliente.LerTodosCliente(), "ClienteId", "Nome");
            loc_vm.Veiculo = new SelectList(repo_veic.LerTodosVeiculo(), "VeiculoId", "Placa");
            return View(loc_vm);
            
        }

        // POST: Locacoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Locacao_vm loc_vm)
        {
            if (ModelState.IsValid)
            {
                Locacao locacao = Mapper.Map<Locacao_vm, Locacao>(loc_vm);
                locdev.LocarVeiculo(locacao.Veiculo, locacao.Cliente);
                return RedirectToAction("/Home/Index");
            }

            return View(loc_vm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DevolverVeiculo(Locacao_vm loc)
        {
            if (ModelState.IsValid)
            {
                Locacao locacao = Mapper.Map<Locacao_vm, Locacao>(loc);
                locdev.DevolverVeiculo(locacao.Veiculo);
                return RedirectToAction("/Home/Index");
            }
            return View(loc);
        }

        // GET: Locacoes/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Locacao locacao = db.Locacoes.Find(id);
        //    if (locacao == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nome", locacao.ClienteId);
        //    ViewBag.VeiculoId = new SelectList(db.Veiculos, "VeiculoId", "Placa", locacao.VeiculoId);
        //    return View(locacao);
        //}

        //// POST: Locacoes/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "LocacaoId,ClienteId,VeiculoId,DataSaida,DataRetorno")] Locacao locacao)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(locacao).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nome", locacao.ClienteId);
        //    ViewBag.VeiculoId = new SelectList(db.Veiculos, "VeiculoId", "Placa", locacao.VeiculoId);
        //    return View(locacao);
        //}

        // GET: Locacoes/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Locacao locacao = db.Locacoes.Find(id);
        //    if (locacao == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(locacao);
        //}


        // POST: Locacoes/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Locacao locacao = db.Locacoes.Find(id);
        //    db.Locacoes.Remove(locacao);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
    }
}
