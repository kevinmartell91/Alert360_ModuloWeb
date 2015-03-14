using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace template.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Usuarios()//ok
        {
            return View();
        }
        public ActionResult Alertas()//ok ok
        {
            return View();
        }
        public ActionResult PanelPrincipal()//ok
        {
            return View();
        }
        public ActionResult UsuariosActivos()//ok
        {
            return View();
        }
        public ActionResult UsuariosInactivos()//ok
        {
            return View();
        }
        public ActionResult Receptores()//ok ok
        {
            return View();
        }
        public ActionResult ReceptoresPorUsuario()//ok
        {
            return View();
        }
        public ActionResult ReceptorMapaPublico(string codalerta)//ok
        {
            ViewBag.codalerta = codalerta;

            return View();
            //return Content("codigo alerta" + codalerta.ToString());
        }
        public ActionResult bagg()
        {
            return View();
        }
        public ActionResult graphics()
        {
            return View();
        }
    }
}
