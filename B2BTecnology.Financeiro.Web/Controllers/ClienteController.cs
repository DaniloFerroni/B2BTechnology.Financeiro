using System.Collections.Generic;
using System.Web.Mvc;
using B2BTecnology.Financeiro.DTO;
using B2BTecnology.Financeiro.Negocio;

namespace B2BTecnology.Financeiro.Web.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ClienteService _clienteService = new ClienteService();

        // GET: Cliente
        public ActionResult Index()
        {
            return View(CarregarClientes(new ClienteDTO()));
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
            var clientes = _clienteService.Todos();
            return View(clientes);
        }

        [Route("Cliente/Detalhe/{documento}")]
        public ActionResult Detalhe(string documento)
        {
            var cliente = _clienteService.Pesquisar(documento);
            
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

    }
}