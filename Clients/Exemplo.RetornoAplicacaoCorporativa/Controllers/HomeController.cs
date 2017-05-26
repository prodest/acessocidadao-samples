using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Exemplo.RetornoAplicacaoCorporativa.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Logado()
        {
            return View((User as ClaimsPrincipal).Claims);
        }
    }
}