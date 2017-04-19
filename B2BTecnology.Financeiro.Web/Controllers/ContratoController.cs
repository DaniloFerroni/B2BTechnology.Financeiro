using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using B2BTecnology.Financeiro.DTO;
using B2BTecnology.Financeiro.Negocio;
using B2BTecnology.Financeiro.Web.Extencion;

namespace B2BTecnology.Financeiro.Web.Controllers
{
    [Authorize]
    public class ContratoController : Controller
    {
        private readonly ClienteService _clienteService = new ClienteService();
        private readonly ContratoService _contratoService = new ContratoService();

        // GET: Cliente
        public ActionResult Index()
        {
            var contrato = CarregarContrato(new ContratoDTO());
            CarregarViewBag(contrato);
            return View(contrato);
        }

        public ActionResult Salvar(ContratoDTO contrato)
        {
            try
            {
                TempData["Error"] = true;
                CarregarViewBag(contrato);

                var mensagem = ValidacaoCadastroCliente(contrato);
                if (!string.IsNullOrEmpty(mensagem))
                {
                    TempData["Error"] = false;
                    throw new Exception(mensagem);
                }

                contrato.Cliente.Documento = contrato.Cliente.Documento.DocumentoSemMascara();
                _contratoService.Salvar(contrato);

                TempData["success"] = "Dados Salvos com Sucesso!";

                return RedirectToAction("Detalhe", new { idContrato = contrato.IdContrato });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View("Index", contrato);
            }
            
        }

        private string ValidacaoCadastroCliente(ContratoDTO contrato)
        {
            var mensagem = new StringBuilder();
            var cliente = contrato.Cliente;

            if (string.IsNullOrEmpty(cliente.Documento))
                mensagem.AppendLine("- CPF/CNPJ é Obrigatório.");

            if (string.IsNullOrEmpty(cliente.Nome))
                mensagem.AppendLine("- Digite o Nome do Cliente.");

            //if (cliente.Contato == null || string.IsNullOrEmpty(cliente.Contato.Nome))
            //    mensagem.AppendLine("- Digite o Nome do Contato.");

            //if (cliente.Contato == null || string.IsNullOrEmpty(cliente.Contato.Nome))
            //    mensagem.AppendLine("- Digite o E-mail do Contato.");


            if (contrato.DiaVencimento <= 0)
                mensagem.AppendLine("- Dia do Vencimento é Obrigatório.");

            if (contrato.VendedorId == 0)
                mensagem.AppendLine("- Vendedor é obrigatório.");

            return mensagem.ToString();
        }

        public ActionResult Listar()
        {
            var contratos = _contratoService.Todos().OrderBy(c => c.Cliente.Nome).ToList();
            return View(contratos);
        }

        [Route("Contrato/Detalhe/{idContrato}")]
        public ActionResult Detalhe(int idContrato)
        {
            var contrato = _contratoService.Pesquisar(idContrato);
            CarregarViewBag(contrato);
            return View("Index", CarregarContrato(contrato));
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

        public PartialViewResult AdicionarContato(ClienteDTO cliente, ContatoDTO contato)
        {
            cliente.Contatos = cliente.Contatos ?? new List<ContatoDTO>();
            cliente.Contatos.Add(contato);

            return PartialView("Partials/_ListaContato", cliente.Contatos);
        }

        public PartialViewResult ExcluirContato(ClienteDTO cliente, int index)
        {
            cliente.Contatos.RemoveAt(index);

            return PartialView("Partials/_ListaContato", cliente.Contatos);
        }

        public JsonResult PesquisarClientesPorNome(string nome)
        {
            var clientes = _clienteService.Clientes(nome);

            return Json(clientes, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult GetCliente(int idCliente)
        {
            var cliente = _clienteService.Pesquisar(idCliente);

            return PartialView("Partials/_Cliente", cliente);
        }

        private ContratoDTO CarregarContrato(ContratoDTO contrato)
        {
            if (contrato.IdContrato != 0) return contrato;

            return new ContratoDTO
            {
                Cliente = new ClienteDTO
                            {
                                TipoPessoa = "J",
                                Endereco = new EnderecoDTO(),
                                Contratos = new List<ContratoDTO>(),
                                Contatos = new List<ContatoDTO>(),
                                Equipamento = new EquipamentosDTO()
                            },
                PlanoId = 1
            };
        }

        private void CarregarViewBag(ContratoDTO contrato)
        {
            var vendedorId = contrato == null ? 0 : contrato.VendedorId;

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