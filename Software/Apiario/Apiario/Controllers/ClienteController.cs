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
        //
        // GET: /Cliente/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cadastro() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Cliente cliente) 
        {
            Console.Write(cliente);
            return View("Cadastro");
        }

	}
}