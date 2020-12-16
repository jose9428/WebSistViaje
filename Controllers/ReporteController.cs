using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SisWebViaje.Models;

namespace SisWebViaje.Controllers
{
    public class ReporteController : Controller
    {
        SistViajeEntities db = new SistViajeEntities();
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ReportePorRuta() {

            var lista = db.sp_reporte_total_ruta().ToList();

            return Json(lista , JsonRequestBehavior.AllowGet);
        }
        public ActionResult ReportePorChofer()
        {

            var lista = db.sp_reporte_cant_chofer().ToList();

            return Json(lista, JsonRequestBehavior.AllowGet);

        }

        public ActionResult ReportePorMes(int anio)
        {

            var lista = db.sp_reporte_total_mes(anio).ToList();

            return Json(lista, JsonRequestBehavior.AllowGet);

        }
    }
}