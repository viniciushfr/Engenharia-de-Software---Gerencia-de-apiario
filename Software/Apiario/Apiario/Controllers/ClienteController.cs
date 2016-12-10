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
            return View();
        }

        public ActionResult Cadastrar() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Cliente cliente) 
        {
            dbCliente.Clientes.Add(cliente);
            dbCliente.SaveChanges();
            return View();
        }

	}
}