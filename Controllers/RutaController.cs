using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SisWebViaje.Models;

namespace SisWebViaje.Controllers
{
    public class RutaController : Controller
    {
        private SistViajeEntities db = new SistViajeEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Listado()
        {
            return View(db.Ruta.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RUTCOD,RUTNOM,PAGOOCHO")] Ruta ruta, HttpPostedFileBase RUTIMG)
        {
            if (RUTIMG != null)
            {
                if (RUTIMG.FileName.EndsWith("jpg") || RUTIMG.FileName.EndsWith("png")
                    || RUTIMG.FileName.EndsWith("jpeg"))
                {
                    string archivo = Path.GetFileName(RUTIMG.FileName);
                    archivo = archivo.Replace(" ", "");
                    string pic = Aleatoreo() + archivo;
                    string path = Path.Combine(Server.MapPath("~/Content/Imagen/"), pic);
                    RUTIMG.SaveAs(path);
                    ruta.RUTIMG = pic;
                }
                else
                {
                    ModelState.AddModelError("RUTIMG", "El sistema solo acepta imagenes JPG y PNG");
                }
            }
            else
            {
                ModelState.AddModelError("RUTIMG", "Por favor seleccione una imagen");
            }

            var existeCodRuta = from r in db.Ruta
                                where r.RUTCOD == ruta.RUTCOD
                                select r;
            if (existeCodRuta.Count() > 0)
            {
                ModelState.AddModelError("RUTCOD", "El codigo ya se encuentra registrado");
            }

            var existeRuta = from r in db.Ruta
                             where r.RUTNOM == ruta.RUTNOM
                             select r;
            if (existeRuta.Count() > 0)
            {
                ModelState.AddModelError("RUTNOM", "La ruta ya se encuentra registrada");
            }


            if (ModelState.IsValid)
            {
                TempData["mensaje"] = "Datos de la ruta " + ruta.RUTNOM + " registrados correctamente";
                db.Ruta.Add(ruta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ruta);
        }

        public int Aleatoreo()
        {
            Random ran = new Random();
            return ran.Next(1, 100000);
        }

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ruta ruta = db.Ruta.Find(id);
            if (ruta == null)
            {
                return HttpNotFound();
            }
            return View(ruta);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RUTCOD,RUTNOM,PAGOOCHO")] Ruta ruta, HttpPostedFileBase RUTIMG)
        {
            Ruta nuevo = new Ruta();
            if (RUTIMG != null)
            {
                if (RUTIMG.FileName.EndsWith("jpg") || RUTIMG.FileName.EndsWith("png") || RUTIMG.FileName.EndsWith("jpeg"))
                {
                    string archivo = Path.GetFileName(RUTIMG.FileName);
                    archivo = archivo.Replace(" ", "");
                    string pic = Aleatoreo() + archivo;
                    string path = Path.Combine(Server.MapPath("~/Content/Imagen/"), pic);
                    RUTIMG.SaveAs(path);
                    ruta.RUTIMG = pic;
                }
                else
                {
                    ModelState.AddModelError("RUTIMG", "El sistema solo acepta imagenes JPG y PNG");
                }
            }
            else
            {
                nuevo = db.Ruta.Find(ruta.RUTCOD);
                ruta.RUTIMG = nuevo.RUTIMG;
            }

            var existeRuta = from r in db.Ruta
                             where r.RUTNOM == ruta.RUTNOM && r.RUTCOD != ruta.RUTCOD
                             select r;
            if (existeRuta.Count() > 0)
            {
                ModelState.AddModelError("RUTNOM", "La ruta ya se encuentra registrada");
            }

            if (ModelState.IsValid)
            {
                TempData["mensaje"] = "Ruta " + ruta.RUTNOM + " modficada correctamente.";
                db.Entry(nuevo).State = EntityState.Detached;
                db.Entry(ruta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ruta);
        }

        // POST: Ruta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Ruta ruta = db.Ruta.Find(id);
            db.Ruta.Remove(ruta);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpPost]
        public ActionResult ConfEliminar(string id)
        {
            Ruta ruta = db.Ruta.Find(id);
            db.Ruta.Remove(ruta);
            int res = db.SaveChanges();

            if (res > 0)
            {
                TempData["mensaje"] = "Ruta " + ruta.RUTNOM + " eliminado correctamente.";
            }

            return Json(new { resultado = res }, JsonRequestBehavior.AllowGet);
        }
    }
}
