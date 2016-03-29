using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using B2BTecnology.Financeiro.DTO;
using B2BTecnology.Financeiro.Web.Models;

namespace B2BTecnology.Financeiro.Web.Controllers
{
    public class PagamentoController : Controller
    {
        // GET: Pagamento
        public ActionResult Index()
        {
            var pagamento = new PagametoViewModel
            {
                Pagamento = new PagamentoDTO
                {
                    Contrato = new ContratoDTO()
                },
                Pagamentos = new List<PagamentoDTO>()
            };
            //return View(new PagamentoDTO());
            return View(pagamento);
        }
    }
}