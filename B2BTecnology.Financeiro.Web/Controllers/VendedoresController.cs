using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using B2BTecnology.Financeiro.DTO;
using B2BTecnology.Financeiro.Negocio;
using B2BTecnology.Financeiro.Web.Extencion;

namespace B2BTecnology.Financeiro.Web.Controllers
{
    [Authorize]
    public class VendedoresController : Controller
    {
        private readonly VendedoresService _vendedoresService = new VendedoresService();
        // GET: Vendedores
        public ActionResult Index()
        {
            var vendedores = new VendedoresDTO
            {
                Contato = new ContatoDTO(),
                Endereco = new EnderecoDTO()
            };
            CarregarViewBag(0);

            return View(vendedores);
        }

        public ActionResult Salvar(VendedoresDTO vendedoresDto)
        {
            try
            {
                TempData["Error"] = !ModelState.IsValid;
                CarregarViewBag(vendedoresDto.SuperiorId);
                if (!ModelState.IsValid)
                    return View("Index", vendedoresDto);

                vendedoresDto.Documento = vendedoresDto.Documento.DocumentoSemMascara();
                _vendedoresService.Salvar(vendedoresDto);

                TempData["success"] = "Dados Salvos com Sucesso!";

                return RedirectToAction("Detalhe", new { documento = vendedoresDto.Documento });
            }
            catch (Exception ex)
            {
                var message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;

                TempData["ErrorMessage"] = message;
                return View("Index", vendedoresDto);
            }

        }

        [Route("Vendedores/Detalhe/{documento}")]
        public ActionResult Detalhe(string documento)
        {
            var vendedorDto = _vendedoresService.GetVendedor(documento);
            CarregarViewBag(vendedorDto.SuperiorId);

            return View("Index", vendedorDto);
        }

        [Route("Vendedores/Listar")]
        public ActionResult Listar()
        {
            var vendedoresDto = _vendedoresService.GetAll().OrderBy(v => v.Nome);

            return View("Listar", vendedoresDto);
        }

        public void Excluir(int idVendedor)
        {
            try
            {
                _vendedoresService.Excluir(idVendedor);
                TempData["success"] = "Excluido com Sucesso!";
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Vendedor com contratos atívos não podem ser excluído";
            }

            //RedirectToAction("Listar");
        }

        public JsonResult PesquisarClientesPorNome(string nome)
        {
            var clientes = _vendedoresService.VendedoresPorNome(nome);

            return Json(clientes, JsonRequestBehavior.AllowGet);
        }

        public void CarregarViewBag(int gestor)
        {
            var selectListItem = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = "0",
                    Text = "Selecione"
                }
            };

            selectListItem.AddRange(
            _vendedoresService.GestoresDeVendas().Select(e => new SelectListItem
            {
                Value = e.IdVendedor.ToString(),
                Text = e.Nome,
                Selected = gestor == e.SuperiorId
            }).ToList());

            ViewBag.GestorVendas = selectListItem;

        }
    }
}