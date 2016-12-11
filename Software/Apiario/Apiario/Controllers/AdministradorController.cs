using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Apiario.Controllers
{
    public class AdministradorController : Controller
    {
       
        public ActionResult Index()
        {
            if (Session["adminLogadoID"] == null || Session["clienteLogadoID"] == null || Session["clienteLogadoID"] != null) 
            {
                return RedirectToAction("../Logar");
            }
            return View();
        }
	}
}