using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exemplo.RetornoAplicacaoCorporativa.Controllers
{
    public class ContaController : Controller
    {
        [Authorize]
        public ActionResult Entrar()
        {
            return RedirectToAction("Logado", "Home");
        }

        [Authorize]
        public ActionResult Sair()
        {
            Request.GetOwinContext().Authentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}