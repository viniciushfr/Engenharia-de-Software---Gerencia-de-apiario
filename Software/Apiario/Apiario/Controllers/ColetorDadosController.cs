using Apiario.Context;
using Apiario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Apiario.Controllers
{
    public class ColetorDadosController : Controller
    {
        //
        // GET: /ColetorDados/
        private DadosApiarioContext dbDadosApiario = new DadosApiarioContext();
        private DadosCaixaContext dbDadosCaixa = new DadosCaixaContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DadosApiario(int idApiario, DateTime data, float umidade, float temperatura)
        {
            DadosApiario dadosApiario = new DadosApiario();
            dadosApiario.idApiario = idApiario;
            dadosApiario.dataDadosApiario = data;
            dadosApiario.umidade = umidade;
            dadosApiario.temperatura = temperatura;

            dbDadosApiario.DadosApiario.Add(dadosApiario);
            dbDadosApiario.SaveChanges();

            ViewBag.erro = "true";
            return View();
        }
        public ActionResult DadosCaixa(int idCaixa, DateTime data, float peso, int fluxoAbelhas)
        {
            DadosCaixa dadosCaixa = new DadosCaixa();
            dadosCaixa.idCaixa = idCaixa;
            dadosCaixa.dataDadosCaixa = data;
            dadosCaixa.peso = peso;
            dadosCaixa.fluxoAbelhas = fluxoAbelhas;

            dbDadosCaixa.DadosCaixa.Add(dadosCaixa);
            dbDadosCaixa.SaveChanges();

            ViewBag.erro = "true";

           
            return View();
        }
	}
}