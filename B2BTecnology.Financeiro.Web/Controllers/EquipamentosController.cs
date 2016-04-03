using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using B2BTecnology.Financeiro.DTO;
using B2BTecnology.Financeiro.Negocio;

namespace B2BTecnology.Financeiro.Web.Controllers
{
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
            _equipamentosService.Salvar(equipamentos);

            TempData["success"] = true;
            return RedirectToAction("Index");
        }
    }
}