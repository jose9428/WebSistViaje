using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SisWebViaje.Models;

namespace SisWebViaje.Controllers
{
    public class HomeController : Controller
    {
        private SistViajeEntities db = new SistViajeEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CerrarSesion()
        {
            Session["usuario"] = null;
            return RedirectToAction("Index" , "Home");
        }

        [HttpPost]
        public ActionResult Index(string usuario , string clave) 
        {
            if (ModelState.IsValid)
            {
                var user = db.sp_logear(usuario , clave).ToList();

                if (user.ToList().Count() > 0)
                {
                    Usuarios u = new Usuarios();
                    u.Nombre = user.ElementAt(0).Nombre;
                    Session["usuario"] = u;

                    return RedirectToAction("Index", "Reporte");
                }
                else {
                    ModelState.AddModelError("" , "Usuario y/o clave incorrecto");
                    return View();
                } 
            }

            return View();
        }

    }
}