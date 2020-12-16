using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SisWebViaje.Models;

namespace SisWebViaje.Controllers
{
    public class PasajeroController : Controller
    {
        private SistViajeEntities db = new SistViajeEntities();

        public ActionResult Index()
        {
            ViewBag.codRuta = new SelectList(db.Ruta, "RUTCOD", "RUTNOM");
            return View();
        }

        public ActionResult Listar(string id) {

            var lista = from v in db.Viaje
                        where v.VIANRO == id
                        select new { fech = v.VIAFCH, cost = v.COSVIA };

            var fecha = lista.ToList().ElementAt(0).fech;
            var pago = lista.ToList().ElementAt(0).cost;

            ViewBag.FechaViaje = fecha.ToString() ;
            ViewBag.PagoViaje = pago;
            ViewBag.NroViaje = id;
            return View();
        }

        public ActionResult ListadoPasajeros(string id)
        {
            var fecha = from v in db.Viaje
                        where v.VIANRO == id
                        select new { v.VIAFCH };

            var lista = from p in db.Pasajeros
                        where p.VIANRO == id
                        select p;

            ViewBag.FechaViaje = fecha.ToList().ElementAt(0).VIAFCH.ToString();
            // ViewBag.FechaViaje = fecha.First().ToString();
            return View(lista.ToList());
        }

        public ActionResult ListadoViajes(string id)
        {
            var viaje = from v in db.Viaje
                        where v.RUTCOD == id
                        select v;

            return View(viaje.ToList());
        }

        public ActionResult AsientosDisp(string id) {

            List<Pasajeros> lista = new List<Pasajeros>();
            for (int i = 1; i <= 20; i++)
            {
                if (!Buscar(i, id))
                {
                    Pasajeros p = new Pasajeros();
                    p.NRO_ASI = i;
                    lista.Add(p);
                }
            }

            return Json(lista , JsonRequestBehavior.AllowGet);
        }

        public bool Buscar(int asiento , string idViaje)
        {
            var lista = from p in db.Pasajeros
                        where p.VIANRO == idViaje
                        select new { p.NRO_ASI};

            foreach (var dato in lista)
            {
                if (dato.NRO_ASI == asiento)
                {
                    return true;
                }
            }
            return false;
        }


        [HttpPost]
        public ActionResult Create([Bind(Include = "VIANRO,NOM_PAS,NRO_ASI,TIPO,PAGO")] Pasajeros pasajeros)
        {
             int resp = db.sp_adicionar_pasajeros(pasajeros.VIANRO , pasajeros.NOM_PAS ,pasajeros.NRO_ASI , pasajeros.TIPO , pasajeros.PAGO);
            return Json(new { res = resp} , JsonRequestBehavior.AllowGet);
        }

        public ActionResult Eliminar(string id)
        {
            Pasajeros pasajeros = db.Pasajeros.Find(id);
            db.Pasajeros.Remove(pasajeros);
            int resp = db.SaveChanges();
            return Json(new { resultado = resp} , JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
