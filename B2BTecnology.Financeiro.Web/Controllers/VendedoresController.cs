using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using B2BTecnology.Financeiro.DTO;

namespace B2BTecnology.Financeiro.Web.Controllers
{
    public class VendedoresController : Controller
    {
        // GET: Vendedores
        public ActionResult Index()
        {
            var vendedores = new VendedoresDTO
            {
                Contato = new ContatoDTO(),
                Endereco = new EnderecoDTO()
            };

            return View(vendedores);
        }
    }
}