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
    public class ViajeController : Controller
    {
        private SistViajeEntities db = new SistViajeEntities();

        public ActionResult Index()
        {
            var viaje = db.Viaje.Include(v => v.Bus).Include(v => v.Chofer).Include(v => v.Ruta);
            return View(viaje.ToList());
        }

        public ActionResult ListadoViaje()
        {
            var viaje = from v in db.Viaje
                        join b in db.Bus on v.BUSNRO equals b.BUSNRO
                        join r in db.Ruta on v.RUTCOD equals r.RUTCOD
                        join c in db.Chofer on v.IDCOD equals c.IDCOD
                        select new ControlViaje
                        {
                            VIANRO = v.VIANRO,
                            VIAFCH = v.VIAFCH,
                            VIAHRS = v.VIAHRS,
                            COSVIA = v.COSVIA,
                            BUSPLA = b.BUSPLA,
                            CHONOM = c.CHONOM,
                            RUTNOM = r.RUTNOM
                        };

          //  var viaje = db.Viaje.Include(v => v.Bus).Include(v => v.Chofer).Include(v => v.Ruta);
            return View(viaje.ToList());
        }

        public ActionResult JASON(string id)
        {
            Viaje viaje = db.Viaje.Find(id);

            var lista = from r in db.Ruta
                        join v in db.Viaje
                        on r.RUTCOD equals v.RUTCOD
                        where v.VIANRO == id
                        select r.RUTCOD;

           // viaje.RUTCOD = lista.FirstOrDefault();
            return Json(viaje , JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            ViewBag.BUSNRO = new SelectList(db.Bus, "BUSNRO", "BUSPLA");
            ViewBag.IDCOD = new SelectList(db.Chofer, "IDCOD", "CHONOM");
            ViewBag.RUTCOD = new SelectList(db.Ruta, "RUTCOD", "RUTNOM");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VIANRO,BUSNRO,RUTCOD,IDCOD,VIAHRS,VIAFCH,COSVIA")] Viaje viaje)
        {
            DateTime FechaActual = DateTime.Now.Date;
            DateTime FechaViaje = Convert.ToDateTime(viaje.VIAFCH).Date;

              if (FechaViaje<FechaActual) {
                ModelState.AddModelError("VIAFCH" , "La fecha "+FechaViaje+" es pasada.");
            }

            if (ModelState.IsValid)
            {
                int res = db.sp_adicionar_viaje(viaje.BUSNRO , viaje.RUTCOD , viaje.IDCOD , viaje.VIAHRS , viaje.VIAFCH , viaje.COSVIA);

                if (res>0) 
                {
                    TempData["mensaje"] = "Datos del viaje registrados correctamente";
                }
                return RedirectToAction("Index");
            }

            ViewBag.BUSNRO = new SelectList(db.Bus, "BUSNRO", "BUSPLA", viaje.BUSNRO);
            ViewBag.IDCOD = new SelectList(db.Chofer, "IDCOD", "CHONOM", viaje.IDCOD);
            ViewBag.RUTCOD = new SelectList(db.Ruta, "RUTCOD", "RUTNOM", viaje.RUTCOD);
            return View(viaje);
        }

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viaje viaje = db.Viaje.Find(id);

            var lista = from r in db.Ruta
                        join v in db.Viaje
                        on r.RUTCOD equals v.RUTCOD
                        where v.VIANRO == id
                        select r.RUTCOD;

            if (viaje == null)
            {
                return HttpNotFound();
            }

           //  viaje.RUTCOD = lista.First();
            ViewBag.BUSNRO = new SelectList(db.Bus, "BUSNRO", "BUSPLA", viaje.BUSNRO);
            ViewBag.IDCOD = new SelectList(db.Chofer, "IDCOD", "CHONOM", viaje.IDCOD);
            ViewBag.RUTCOD = new SelectList(db.Ruta, "RUTCOD", "RUTNOM", viaje.RUTCOD);
            return View(viaje);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VIANRO,BUSNRO,RUTCOD,IDCOD,VIAHRS,VIAFCH,COSVIA")] Viaje viaje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(viaje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BUSNRO = new SelectList(db.Bus, "BUSNRO", "BUSPLA", viaje.BUSNRO);
            ViewBag.IDCOD = new SelectList(db.Chofer, "IDCOD", "CHONOM", viaje.IDCOD);
            ViewBag.RUTCOD = new SelectList(db.Ruta, "RUTCOD", "RUTNOM", viaje.RUTCOD);
            return View(viaje);
        }

        [HttpPost]
        public ActionResult ConfEliminar(string id)
        {
            Viaje viaje = db.Viaje.Find(id);
            db.Viaje.Remove(viaje);
            int res = db.SaveChanges();

            if (res > 0)
            {
                TempData["mensaje"] = "El Viaje con numero" +viaje.VIANRO  + " se elimino correctamente.";
            }

            return Json(new { resultado = res }, JsonRequestBehavior.AllowGet);
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
