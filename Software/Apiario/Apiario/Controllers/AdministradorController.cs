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
        private ApiarioContext dbApiario = new ApiarioContext();
        private CaixaContext dbCaixa = new CaixaContext();
        private DadosApiarioContext dbDadosApiario = new DadosApiarioContext();
        private DadosCaixaContext dbDadosCaixa = new DadosCaixaContext();
        public ActionResult Index()
        {
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


        public ActionResult GerenciarApiario()
        {
            return View(dbApiario.Apiarios.ToList());
        }

        public ActionResult EditarApiario(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Apiario apiario = dbApiario.Apiarios.Find(id);
            if (apiario == null)
            {
                return HttpNotFound();
            }
            return View(apiario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarApiario([Bind(Include = "idApiario,idCliente,localizacao,quantasVezes,hora")] Models.Apiario apiario)
        {
            Models.Apiario aux = dbApiario.Apiarios.Find(apiario.idApiario);
            aux.localizacao = apiario.localizacao;
            aux.quantasVezes = apiario.quantasVezes;
            aux.hora = apiario.hora;

            if (ModelState.IsValid)
            {
                dbApiario.SaveChanges();
                return RedirectToAction("GerenciarApiario");
            }
            return View(apiario);
        }

        public ActionResult Cadastrar() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Administrador admin)
        {
            if (ModelState.IsValid)
            {
                admin.tipoUsuario = true;
                dbAdmin.Administrador.Add(admin);
                dbAdmin.SaveChanges();
                ViewData["Mensagem"] = "Cadastrado com sucesso!";
            }
            return View();
        }

        [HttpGet]
        public ActionResult DeletarCliente(int idCliente) 
        {

            dbClientes.Clientes.Remove(dbClientes.Clientes.Find(idCliente));
            dbClientes.SaveChanges();

            return RedirectToAction("GerenciarCliente");
        }

	}
}