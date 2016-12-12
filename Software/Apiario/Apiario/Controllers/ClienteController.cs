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
        private ApiarioContext dbApiario = new ApiarioContext();
        private CaixaContext dbCaixa = new CaixaContext();
        public ActionResult Index()
        {
            if (Session["clienteLogadoID"] == null && Session["adminLogadoID"] == null || Session["adminLogadoID"] != null)
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

        [HttpPost]
        public ActionResult CadastrarApiario(String localizacao, String quantasCaixas, String quantasVezes, String hora)
        {
            if (ModelState.IsValid)
            {
                Models.Apiario apiario = new Models.Apiario();
                apiario.localizacao = localizacao;
                apiario.quantasVezes = Int32.Parse(quantasVezes);
                apiario.hora = TimeSpan.Parse(hora);
                apiario.idCliente = Int32.Parse(Session["clienteLogadoID"].ToString());
                dbApiario.Apiarios.Add(apiario);
                dbApiario.SaveChanges();



                for (int i = 0; i < Int32.Parse(quantasCaixas); i++)
                {
                    Caixa caixa = new Caixa();
                    caixa.situacao = "Desativada";
                    caixa.idApiario = apiario.idApiario;
                    dbCaixa.Caixas.Add(caixa);
                    dbCaixa.SaveChanges();

                }

                ViewData["Mensagem"] = "Apiário cadastrado com sucesso!";
            }


                return View();
        }

	}
}