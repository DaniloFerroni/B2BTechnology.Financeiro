using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using B2BTecnology.Financeiro.DTO;

namespace B2BTecnology.Financeiro.Web.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            var cliente = new ClienteDTO
            {
                Documento = "1234567890",
                Endereco = new EnderecoDTO
                {
                    Rua = "testetstetestete"
                },
                Contrato = new ContratoDTO(),
                Contato = new ContatoDTO()
            };

            return View(cliente);
        }

        public ActionResult Salvar(ClienteDTO cliente)
        {
            TempData["Error"] = !ModelState.IsValid;
            if(!ModelState.IsValid)
                return View("Index", cliente);

            return RedirectToAction("Index");
        }

        public ActionResult Listar()
        {
            var lista = new List<ClienteDTO>
            {
                new ClienteDTO
                {
                    IdCliente = 1,
                    Nome = "Danilo",
                    Documento = "1234567890",
                    Contrato = new ContratoDTO
                    {
                        NomeVendedor = "Teste"
                    }
                }
            };
            return View(lista);
        }
    }
}