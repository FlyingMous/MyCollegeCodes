using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Libero;
using WebLibero.ViewModels.Clientes;
using AutoMapper;
using Libero.Interfaces;
using Libero.Repositorios;

namespace WebLibero.Controllers
{
    [Authorize]
    public class ClientesController : Controller
    {

        IRepoCliente repo = new RepoCliente();
        // GET: Clientes
        public ActionResult Index()
        {
            List<Cliente> cliente = repo.LerTodosCliente();
            List<MostrarClientes_vm> clienteVM = new List<MostrarClientes_vm>();

            foreach (var item in cliente)
            {
                MostrarClientes_vm c = Mapper.Map<Cliente, MostrarClientes_vm>(item);
                clienteVM.Add(c);

            }

            return View(clienteVM);
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = repo.LerCliente(id);
            MostrarClientes_vm c = Mapper.Map<Cliente, MostrarClientes_vm>(cliente);
 
            if (c == null)
            {
                return HttpNotFound();
            }
            return View(c);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CadastroCliente_vm cliente_vm)
        {
            if (ModelState.IsValid)
            {
                Cliente cliente = Mapper.Map<CadastroCliente_vm, Cliente>(cliente_vm);
                repo.CadastrarCliente(cliente);
                return RedirectToAction("Index");
            }

            return View(cliente_vm);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente c = repo.LerCliente(id);
            CadastroCliente_vm cvm = Mapper.Map<Cliente, CadastroCliente_vm>(c);

            if (c == null)
            {
                return HttpNotFound();
            }
            return View(cvm);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CadastroCliente_vm cvm)
        {
            Cliente cliente = Mapper.Map<CadastroCliente_vm, Cliente>(cvm);

            if (ModelState.IsValid)
            {

                repo.ModificarCliente(cliente);
                return RedirectToAction("Index");
            }
            return View(cvm);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = repo.LerCliente(id);
            MostrarClientes_vm cvm = Mapper.Map<Cliente, MostrarClientes_vm>(cliente);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cvm);
        }

         //POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repo.ExcluirCliente(id);

            return RedirectToAction("Index");
        }
    }
}
