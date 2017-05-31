using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aplicação.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (Session["nome"] == null)
            {
               return RedirectToAction("Autemticar", "usuario");
            }
            else
            {
                ViewBag.usuario = Session["nome"].ToString();
            }
            



            return View();
        }
    }
}