using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using B2BTecnology.Financeiro.DTO;
using B2BTecnology.Financeiro.Negocio;

namespace B2BTecnology.Financeiro.Web.Controllers
{
    public class ComissaoController : Controller
    {
        private readonly Financas _financeiro = new ComissaoService();

        // GET: Comissao
        public ActionResult Index()
        {
            return View(new List<ComissaoDTO>());
        }
    }
}