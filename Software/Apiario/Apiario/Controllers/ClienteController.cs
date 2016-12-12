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
        private DadosApiarioContext dbDadosApiario = new DadosApiarioContext();
        private DadosCaixaContext dbDadosCaixa = new DadosCaixaContext();
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

        public ActionResult Monitoramento(int idApiario) 
        {
            IEnumerable<Models.DadosApiario> dadosApiario = dbDadosApiario.DadosApiario.Where(x => x.idApiario == idApiario);
            ViewBag.idApiario = idApiario;

            return View(dadosApiario);
        }

        public ActionResult VisualizarCaixas(int idApiario)
        {
            ViewBag.idApiario = idApiario;
            IEnumerable<Models.Caixa> caixas = dbCaixa.Caixas.Where(x => x.idApiario == idApiario);

            return View(caixas);
        }

        public ActionResult MonitorarCaixas(int idCaixa)
        {
            Caixa caixa = dbCaixa.Caixas.Find(idCaixa);
            ViewBag.idApiario = caixa.idApiario;
            IEnumerable<Models.DadosCaixa> dadosCaixa = dbDadosCaixa.DadosCaixa.Where(x => x.idCaixa == idCaixa);

            return View(dadosCaixa);
        }

        public ActionResult VisualizarApiario()
        {
            int id = Int32.Parse(Session["clienteLogadoID"].ToString());
            IEnumerable<Models.Apiario> apiario = dbApiario.Apiarios.Where(x => x.idCliente ==id);

            return View(apiario.ToList());
        }

        public ActionResult RemoverApiario()
        {
            
            int id = Int32.Parse(Session["clienteLogadoID"].ToString());
            IEnumerable<Models.Apiario> apiario = dbApiario.Apiarios.Where(x => x.idCliente == id);

            return View(apiario.ToList());
        }

        [HttpGet]
        public ActionResult DeletarApiario(int idApiario)
        {
            dbApiario.Apiarios.Remove(dbApiario.Apiarios.Find(idApiario));
            dbApiario.SaveChanges();

            return RedirectToAction("RemoverApiario");
        }


	}
}