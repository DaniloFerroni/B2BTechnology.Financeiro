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
        private static readonly Financas _financeiro = new ComissaoService();

        // GET: Comissao
        public ActionResult Index()
        {
            CarregarViewBag();
            return View(new List<ComissaoDTO>());
        }

        public PartialViewResult Pesquisar(DateTime data, string vendedor, string canal)
        {
            

            return PartialView("Partials/_Comissoes", new List<ComissaoDTO>());
        }

        private void CarregarViewBag()
        {
            CarregarViewBagVendedores();
            CarregarViewBagCanais();
            CarregarViewBagMeses();
        }

        private void CarregarViewBagVendedores()
        {
            var gerentes = _financeiro.Gerentes();

            var itens = gerentes.Select(c => new SelectListItem
            {
                Value = c.IdVendedor.ToString(),
                Text = c.Nome
            }).ToList();

            ViewBag.Vendedor = SelectListItems(itens);
        }

        private void CarregarViewBagCanais()
        {
            var canais = _financeiro.Canais();

            var itens = canais.Select(c => new SelectListItem
            {
                Value = c.IdVendedor.ToString(),
                Text = c.Nome
            }).ToList();

            ViewBag.Canais = SelectListItems(itens);
        }

        private List<SelectListItem> SelectListItems(List<SelectListItem> selectListItems)
        {
            var selectListItem = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = null,
                    Text = "Selecione"
                }
            };
            selectListItem.AddRange(selectListItems);

            return selectListItem;

        }

        private void CarregarViewBagMeses()
        {
            var meses = new List<SelectListItem>();
            for (int i = -2; i <= 2; i++)
            {
                var mesSelecionado = DateTime.Now.AddMonths(i);
                meses.Add(
                    new SelectListItem
                    {
                        Value = mesSelecionado.ToString("yyyy-MM-dd"),
                        Text = mesSelecionado.ToString("y"),
                        Selected = mesSelecionado.ToString("dd/MM/yyyy") == DateTime.Now.ToString("dd/MM/yyyy")
                    });
            }

            ViewBag.Meses = meses;
        }

    }
}