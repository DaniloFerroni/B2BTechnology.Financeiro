﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using B2BTecnology.Financeiro.DTO;
using B2BTecnology.Financeiro.Negocio;
using B2BTecnology.Financeiro.Web.Models;

namespace B2BTecnology.Financeiro.Web.Controllers
{
    public class PagamentoController : Controller
    {
        private static readonly Financas _financeiro = new PagamentosService();

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
            CarregarViewBag();
            return View(pagamento);
        }

        public PartialViewResult Detalhe(DateTime data, int clienteId)
        {
            var paramentosService = (PagamentosService) _financeiro;
            var pagamentoViewModel = new PagametoViewModel
            {
                Pagamento = paramentosService.Detalhe(clienteId),
                Pagamentos = paramentosService.PagamentosEfetuados(data,clienteId)
            };

            CarregarViewBag();
            return PartialView("Partials/Detalhe", pagamentoViewModel);
        }

        public ActionResult Salvar(PagametoViewModel pagametoViewModel)
        {
            try
            {
                var pagamentoService = (PagamentosService)_financeiro;
                pagametoViewModel.Pagamentos = pagamentoService.Salvar(pagametoViewModel.Pagamentos, pagametoViewModel.Mes, pagametoViewModel.ClienteId);

                CarregarViewBag();

                TempData["success"] = "Dados Salvos com Sucesso!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }
            
            return View("Index", pagametoViewModel);
        }

        public FileResult BaixarArquivo(DateTime data, int clienteId, string nome)
        {
            if (clienteId == 0) return null;
            var paramentosService = (PagamentosService) _financeiro;
            var pagamentos = paramentosService.PagamentosEfetuados(data, clienteId);
            byte[] filedata = _financeiro.GerarArquivo(pagamentos, nome, data, Enumeradores.TipoPdf.Pagamento);
            return File(filedata, System.Net.Mime.MediaTypeNames.Application.Octet, string.Format("{0}_{1}.pdf", nome, data.ToString("y")));
        }

        private void CarregarViewBag()
        {
            CarregarViewBagMeses();
            CarregarViewBagClientes();
        }

        private void CarregarViewBagClientes()
        {
            var clientes = ((PagamentosService)_financeiro).Clientes();

            var itens = clientes.Select(c => new SelectListItem
            {
                Value = c.IdCliente.ToString(),
                Text = c.Nome
            }).ToList();

            ViewBag.Clientes = SelectListItems(itens);
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
                mesSelecionado = mesSelecionado.AddDays(-(mesSelecionado.Day - 1));
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