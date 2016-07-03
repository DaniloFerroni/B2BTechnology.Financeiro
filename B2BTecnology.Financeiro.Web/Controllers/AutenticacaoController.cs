using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using B2BTecnology.Financeiro.DTO;
using B2BTecnology.Financeiro.Negocio;

namespace B2BTecnology.Financeiro.Web.Controllers
{
    [AllowAnonymous]
    public class AutenticacaoController : Controller
    {
        // GET: Autenticacao
        // Alteração Feature 0001
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UsuarioDTO usuario)
        {
            if (string.IsNullOrEmpty(usuario.Login) || string.IsNullOrEmpty(usuario.Senha))
            {
                ModelState.AddModelError("", "Informe os dados do login");
                return View(new UsuarioDTO());
            }

            usuario.Senha = MD5Encrypt(usuario.Senha);

            if (!ModelState.IsValid) return View(new UsuarioDTO());

            var usuariosvc = UsuarioService.AcessoLogin(usuario.Login, usuario.Senha);

            if (usuariosvc.UsuarioId == 0)
            {
                ModelState.AddModelError("", "Usuário não localizado");
            }
            else
            {
                FormsAuthentication.SetAuthCookie(usuariosvc.Login, false);//usuario.LembrarUsuario);

                return RedirectToAction("Index", "Home");
            }

            return View(new UsuarioDTO());
        }

        public static string MD5Encrypt(string valueText)
        {
            MD5 md5 = MD5.Create();
            byte[] hashValue = md5.ComputeHash(Encoding.UTF8.GetBytes(valueText));
            string hash = BitConverter.ToString(hashValue).Replace("-", "").ToLower();

            return hash;
        }
    }
}