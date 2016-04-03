using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlTypes;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using B2BTecnology.Financeiro.DTO;
using B2BTecnology.Financeiro.Negocio;
using B2BTecnology.Financeiro.Web.Extencion;

namespace B2BTecnology.Financeiro.Web.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ClienteService _clienteService = new ClienteService();

        // GET: Cliente
        public ActionResult Index()
        {
            var cliente = CarregarClientes(new ClienteDTO());
            CarregarViewBag(cliente);
            return View(cliente);
        }

        public ActionResult Salvar(ClienteDTO cliente)
        {
            try
            {
                TempData["Error"] = !ModelState.IsValid;
                CarregarViewBag(cliente);
                if (!ModelState.IsValid)
                    return View("Index", cliente);

                cliente.Documento = cliente.Documento.DocumentoSemMascara();
                _clienteService.Salvar(cliente);

                TempData["success"] = "Dados Salvos com Sucesso!";

                return RedirectToAction("Detalhe", new { documento = cliente.Documento });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View("Index", cliente);
            }
        }

        public ActionResult Listar()
        {
            var clientes = _clienteService.Todos();
            return View(clientes);
        }

        [Route("Cliente/Detalhe/{documento}")]
        public ActionResult Detalhe(string documento)
        {
            var cliente = _clienteService.Pesquisar(documento.DocumentoSemMascara());
            CarregarViewBag(cliente);
            return View("Index", CarregarClientes(cliente));
        }

        public JsonResult PesquisarClientesPorNome(string nome)
        {
            var clientes = _clienteService.Clientes(nome);

            return Json(clientes, JsonRequestBehavior.AllowGet);
        }

        private ClienteDTO CarregarClientes(ClienteDTO cliente)
        {
            if (cliente.IdCliente != 0) return cliente;

            return new ClienteDTO
            {
                Endereco = new EnderecoDTO(),
                Contratos = new List<ContratoDTO>(),
                Contato = new ContatoDTO(),
                Equipamento = new EquipamentosDTO()
            };
        }

        private void CarregarViewBag(ClienteDTO cliente)
        {
            var contratos = cliente.Contratos.FirstOrDefault();
            var equipamentoId = contratos == null ? 0 : contratos.EquipamentoId;
            var vendedorId = contratos == null ? 0 : contratos.VendedorId;

            CarregarViewBagEquipamentos(equipamentoId);
            CarregarViewBagVendedores(vendedorId);
        }

        private void CarregarViewBagVendedores(int vendedorId)
        {
            var vendedoresService = new VendedoresService();
            var vendedores = vendedoresService.GetAll();

            ViewBag.Vendedores = SelectListItems(vendedores.Select(v => new SelectListItem
            {
                Value = v.IdVendedor.ToString(),
                Text = v.Nome,
                Selected = vendedorId == v.IdVendedor
            }).ToList());
        }

        private void CarregarViewBagEquipamentos(int? equipamentoId)
        {
            var equipamentosService = new EquipamentosService();
            var equipamentos = equipamentosService.Todos();


            ViewBag.Equipamentos = SelectListItems(equipamentos.Select(e => new SelectListItem
            {
                Value = e.IdEquipamento.ToString(),
                Text = string.Format("{0}/{1}", e.Modelo, e.NumeroSerie),
                Selected = equipamentoId == e.IdEquipamento
            }).ToList());

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

    }
}