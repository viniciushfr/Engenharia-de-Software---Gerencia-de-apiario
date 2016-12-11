using Apiario.Context;
using Apiario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Apiario.Controllers
{
    public class ClienteController : Controller
    {

        private ClienteContext dbCliente = new ClienteContext();
        public ActionResult Index()
        {
            if (Session["clienteLogadoID"] == null || Session["adminLogadoID"] == null || Session["adminLogadoID"] != null)
            {
                return RedirectToAction("../Logar");
            }
            return View();
        }

        public ActionResult Cadastrar() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Cliente cliente) 
        {
            if(ModelState.IsValid)
            {
                dbCliente.Clientes.Add(cliente);
                dbCliente.SaveChanges();
                ViewData["Mensagem"] = "Cadastrado com sucesso!";
            }
            return View();
        }


        public ActionResult CadastrarApiario()
        {

            return View();
        }

	}
}