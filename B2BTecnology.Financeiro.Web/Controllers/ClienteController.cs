using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using B2BTecnology.Financeiro.DTO;
using B2BTecnology.Financeiro.Negocio;
using B2BTecnology.Financeiro.Web.Extencion;

namespace B2BTecnology.Financeiro.Web.Controllers
{
    [Authorize]
    public class ClienteController : Controller
    {
        private readonly ClienteService _clienteService = new ClienteService();

        // GET: Cliente
        public ActionResult Index()
        {
            var cliente = CarregarClientes(new ClienteDTO());
            cliente.TipoPessoa = "J";
            CarregarViewBag(cliente);
            return View(cliente);
        }

        public ActionResult Salvar(ClienteDTO cliente)
        {
            try
            {
                //TempData["Error"] = !ModelState.IsValid;
                TempData["Error"] = true;
                CarregarViewBag(cliente);
                //if (!ModelState.IsValid)
                var mensagem = ValidacaoCadastroCliente(cliente);
                if (!string.IsNullOrEmpty(mensagem))
                {
                    TempData["Error"] = false;
                    throw new Exception(mensagem);
                }

                cliente.Documento = cliente.Documento.DocumentoSemMascara();
                _clienteService.Salvar(cliente);

                TempData["success"] = "Dados Salvos com Sucesso!";

                return RedirectToAction("Detalhe", new { documento = cliente.Documento.DocumentoSemMascara() });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View("Index", cliente);
            }
        }

        private string ValidacaoCadastroCliente(ClienteDTO cliente)
        {
            var mensagem = new StringBuilder();

            if (string.IsNullOrEmpty(cliente.Documento))
                mensagem.AppendLine("- CPF/CNPJ é Obrigatório.");

            if (string.IsNullOrEmpty(cliente.Nome))
                mensagem.AppendLine("- Digite o Nome do Cliente.");

            if (cliente.Contato == null || string.IsNullOrEmpty(cliente.Contato.Nome))
                mensagem.AppendLine("- Digite o Nome do Contato.");

            if (cliente.Contato == null || string.IsNullOrEmpty(cliente.Contato.Nome))
                mensagem.AppendLine("- Digite o E-mail do Contato.");

            if (cliente.Contato == null || string.IsNullOrEmpty(cliente.Contato.Nome))
                mensagem.AppendLine("- Digite o E-mail do Contato.");

            if (cliente.Contratos == null || !cliente.Contratos.Any())
            {
                mensagem.AppendLine("- Dia do Vencimento é Obrigatório.");
                mensagem.AppendLine("- Vendedor é obrigatório.");
            }
            else
            {
                if (cliente.Contratos == null || cliente.Contratos.First().DiaVencimento <= 0)
                    mensagem.AppendLine("- Dia do Vencimento é Obrigatório.");

                if (cliente.Contratos == null || cliente.Contratos.First().VendedorId == 0)
                    mensagem.AppendLine("- Vendedor é obrigatório.");
            }

            return mensagem.ToString();
        }

        public ActionResult Listar()
        {
            var clientes = _clienteService.Todos().OrderBy(c => c.Nome).ToList();
            return View(clientes);
        }

        [Route("Cliente/Detalhe/{documento}")]
        public ActionResult Detalhe(string documento)
        {
            var cliente = _clienteService.Pesquisar(documento.DocumentoSemMascara());
            CarregarViewBag(cliente);
            return View("Index", CarregarClientes(cliente));
        }

        public void Excluir(int idCliente)
        {
            try
            {
                _clienteService.Excluir(idCliente);
                TempData["success"] = "Excluido com Sucesso!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }
        }

        public PartialViewResult AdicionarAssinatura(ClienteDTO cliente, ContratoAssinaturaDTO contratoAssinaturas)
        {
            var listAssinaturas = new List<ContratoAssinaturaDTO>();
            listAssinaturas.AddRange(cliente.Contratos == null ? new List<ContratoAssinaturaDTO>() : cliente.Contratos.First().ContratoAssinaturas);
            listAssinaturas.Add(contratoAssinaturas);
            
            return PartialView("Partials/_ListaAssinaturas", listAssinaturas);
        }

        public PartialViewResult ExcluirAssinatura(ClienteDTO cliente, int index)
        {
            var contratoAssinaturas = cliente.Contratos.First().ContratoAssinaturas;

            contratoAssinaturas.RemoveAt(index);

            return PartialView("Partials/_ListaAssinaturas", contratoAssinaturas);
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
            var vendedorId = contratos == null ? 0 : contratos.VendedorId;

            CarregarViewBagEquipamentos();
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

        private void CarregarViewBagEquipamentos()
        {
            var equipamentosService = new EquipamentosService();
            var equipamentos = equipamentosService.Todos();
            
            ViewBag.Equipamentos = SelectListItems(equipamentos.Select(e => new SelectListItem
            {
                Value = e.IdEquipamento.ToString(),
                Text = string.Format("{0}/{1}", e.Modelo, e.NumeroSerie)
            }).ToList());
        }

        private List<SelectListItem> SelectListItems(List<SelectListItem> selectListItems)
        {
            var selectListItem = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = "0",
                    Text = "Selecione"
                }
            };
            selectListItem.AddRange(selectListItems);

            return selectListItem;

        }

    }
}