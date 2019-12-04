using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackEndFinal.CF.Controllers
{
    public class EjemploController : Controller
    {
        // GET: Ejemplo
        public ActionResult Index()
        {
            var clave = System.Web.Helpers.Crypto.Hash("dalecalve....");
            var clave1 = System.Web.Helpers.Crypto.HashPassword("dalecalve....");
            return View();
        }
    }
}