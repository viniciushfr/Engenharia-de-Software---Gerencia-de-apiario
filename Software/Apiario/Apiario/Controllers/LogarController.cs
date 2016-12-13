using Apiario.Context;
using Apiario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Apiario.Controllers
{
    public class LogarController : Controller
    {

        private AdministradorContext db_admin = new AdministradorContext();
        private ClienteContext db_cliente = new ClienteContext();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(String nomeUsuario, String senha) 
        {
            Cliente cliente = Cliente.Instance;
            cliente = db_cliente.Clientes.Where(n => n.nomeUsuario.Equals(nomeUsuario) && n.senha.Equals(senha)).FirstOrDefault();
            if(cliente == null)
            {
                Administrador admin = Administrador.Instance;
                admin = db_admin.Administrador.Where(n => n.nomeUsuario.Equals(nomeUsuario) && n.senha.Equals(senha)).FirstOrDefault();
                if (admin == null)
                {
                    ViewData["Mensagem"] = "Nome Usuário ou Senha incorreta!";
                }
                else 
                {
                    Session["adminLogadoID"] = admin.idAdministrador.ToString();
                    Session["adminLogadoNome"] = admin.nome;
                    return RedirectToAction("../Administrador");
                }
            }
            else 
            {
                Session["clienteLogadoID"] = cliente.idCliente.ToString();
                Session["clienteLogadoNome"] = cliente.nome;
                return RedirectToAction("../Cliente");
            }

            return View();
        }

	}
}