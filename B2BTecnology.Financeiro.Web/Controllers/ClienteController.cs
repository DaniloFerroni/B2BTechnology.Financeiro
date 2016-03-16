using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using B2BTecnology.Financeiro.DataBase.Repository;
using B2BTecnology.Financeiro.Entidades;

namespace B2BTecnology.Financeiro.Web.Controllers
{
    public class ClienteController : Controller
    {
        //
        // GET: /Cliente/

        private readonly ClienteRepository _clienteRepository = new ClienteRepository();

        public ActionResult Index()
        {
            var um = _clienteRepository.GetCliente(2);
            var teste = _clienteRepository.GetAll();
            
            return View(new List<Cliente>());
        }

    }
}
