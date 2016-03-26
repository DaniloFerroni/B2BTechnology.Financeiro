using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using B2BTecnology.Financeiro.DTO;

namespace B2BTecnology.Financeiro.Web.Controllers
{
    public class EquipamentosController : Controller
    {
        // GET: Equipamentos
        public ActionResult Index()
        {
            return View(new List<EquipamentosDTO>
            {
                new EquipamentosDTO
                {
                    IdEquipamento = 1,
                    Marca = "Marca1",
                    Modelo = "Modelo1",
                    NumeroSerie = "11111-1111111-1111"
                },
                new EquipamentosDTO
                {
                    IdEquipamento = 2,
                    Marca = "Marca2",
                    Modelo = "Modelo2",
                    NumeroSerie = "222222-222222-2222"
                },
                new EquipamentosDTO
                {
                    IdEquipamento = 3,
                    Marca = "Marca3",
                    Modelo = "Modelo3",
                    NumeroSerie = "333333-3333-333-33"
                },
                new EquipamentosDTO
                {
                    IdEquipamento = 4,
                    Marca = "Marca4",
                    Modelo = "Modelo4",
                    NumeroSerie = "444444-4444-4444"
                },
            });
        }
    }
}