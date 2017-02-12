using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using B2BTecnology.Financeiro.DTO;
using B2BTecnology.Financeiro.Negocio;

namespace B2BTecnology.Financeiro.Web.Controllers
{
    [Authorize]
    public class EquipamentosController : Controller
    {
        private readonly EquipamentosService _equipamentosService = new EquipamentosService();

        // GET: Equipamentos
        public ActionResult Index()
        {
            var equipamentos = _equipamentosService.Todos();

            return View(equipamentos);
        }

        [HttpPost]
        public ActionResult Salvar(List<EquipamentosDTO> equipamentos)
        {
            try
            {
                _equipamentosService.Salvar(equipamentos);

                TempData["success"] = "Salvo com sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                var message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                if (ex.InnerException != null && ex.InnerException.InnerException != null && ex.InnerException.InnerException.Message.Contains("A instrução DELETE conflitou com a restrição do REFERENCE"))
                    message = "Este equipamento não pode ser excluído pois esta alocado em algum cliente.";

                TempData["ErrorMessage"] = message;
                return RedirectToAction("Index");
            }

        }
    }
}