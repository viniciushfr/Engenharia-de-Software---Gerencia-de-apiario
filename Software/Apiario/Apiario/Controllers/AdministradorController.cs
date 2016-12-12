using Apiario.Context;
using Apiario.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Apiario.Controllers
{
    public class AdministradorController : Controller
    {
        private ClienteContext dbClientes = new ClienteContext();
        private AdministradorContext dbAdmin = new AdministradorContext();
        public ActionResult Index()
        {
            if (Session["adminLogadoID"] == null && Session["clienteLogadoID"] == null || Session["clienteLogadoID"] != null)
            {
                return RedirectToAction("../Logar");
            }
            return View();
        }

        public ActionResult GerenciarCliente() 
        {

            return View(dbClientes.Clientes.ToList());
        }

        public ActionResult EditarCliente(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = dbClientes.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarCliente([Bind(Include = "idCliente,nomeUsuario,senha,email,cpf,tipoUsuario,telefone,nome,cidade,estado,idade")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                dbClientes.Entry(cliente).State = EntityState.Modified;
                dbClientes.SaveChanges();
                return RedirectToAction("GerenciarCliente");
            }
            return View(cliente);
        }


	}
}