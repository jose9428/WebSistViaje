using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using SisWebViaje.Models;

namespace SisWebViaje.Controllers
{
    public class ChoferController : Controller
    {
        private SistViajeEntities db = new SistViajeEntities();


        public ActionResult Index()
        {
            return View(db.Chofer.ToList());
        }


        public ActionResult Listado()
        {
            return View(db.Chofer.ToList());
        }

        public ActionResult Create()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem(){Text = "Profesional",Value = "P"});
            list.Add(new SelectListItem(){Text = "Semi-Profesional",Value = "S"});

            ViewBag.ListaCategoria = list;

            return View();
        }

        [HttpGet]
        public ActionResult DetalleChofer(string id) 
        {
            var lista = from v in db.Viaje
                        join r in db.Ruta
                        on v.RUTCOD equals r.RUTCOD
                        where v.IDCOD == id
                        orderby v.VIAFCH
                        select new ControlViaje {
                            VIANRO = v.VIANRO  ,
                            RUTNOM = r.RUTNOM ,
                            VIAFCHA = v.VIAFCH.ToString(), 
                            COSVIA = v.COSVIA
                        } ;

            return Json(lista.ToList() , JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CHONOM,CHOFIN,CHOCAT,CHOSBA")] Chofer chofer, HttpPostedFileBase CHOIMG)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "Profesional", Value = "P" });
            list.Add(new SelectListItem() { Text = "Semi-Profesional", Value = "S" });

            ViewBag.ListaCategoria = list;

            if (CHOIMG != null)
            {
                if (CHOIMG.FileName.EndsWith("jpg") || CHOIMG.FileName.EndsWith("png")
                    || CHOIMG.FileName.EndsWith("jpeg"))
                {
                    string archivo = Path.GetFileName(CHOIMG.FileName);
                    archivo = archivo.Replace(" ", "");
                    string pic = Aleatoreo() + archivo;
                    string path = Path.Combine(Server.MapPath("~/Content/Imagen/"), pic);
                    CHOIMG.SaveAs(path);
                    chofer.CHOIMG = pic;
                }
                else
                {
                    ModelState.AddModelError("CHOIMG", "El sistema solo acepta imagenes JPG , JPEG y PNG");
                }
            }
            else
            {
                ModelState.AddModelError("CHOIMG", "Por favor seleccione una imagen");
            }


            if (ModelState.IsValid)
            {
                int res =  db.sp_adicionar_chofer(chofer.CHONOM , chofer.CHOFIN , chofer.CHOCAT , chofer.CHOSBA , chofer.CHOIMG);
         
                if (res > 0)
                {
                    TempData["mensaje"] = "Se registro correctamente los datos del chofer " + chofer.CHONOM;
                }
                return RedirectToAction("Index");
            }

            return View(chofer);
        }

        public int Aleatoreo()
        {
            Random ran = new Random();
            return ran.Next(1, 100000);
        }

        public List<SelectListItem> Categoria() {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "Profesional", Value = "P" });
            list.Add(new SelectListItem() { Text = "Semi-Profesional", Value = "S" });
            return list;
        }

        public ActionResult Edit(string id)
        {

            ViewBag.ListaCategoria = Categoria();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chofer chofer = db.Chofer.Find(id);
            if (chofer == null)
            {
                return HttpNotFound();
            }
            return View(chofer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDCOD,CHONOM,CHOFIN,CHOCAT,CHOSBA")] Chofer chofer, HttpPostedFileBase CHOIMG)
        {
            Chofer obj = new Chofer();
            if (CHOIMG != null)
            {
                if (CHOIMG.FileName.EndsWith("jpg") || CHOIMG.FileName.EndsWith("png")
                    || CHOIMG.FileName.EndsWith("jpeg"))
                {
                    string archivo = Path.GetFileName(CHOIMG.FileName);
                    archivo = archivo.Replace(" ", "");
                    string pic = Aleatoreo() + archivo;
                    string path = Path.Combine(Server.MapPath("~/Content/Imagen/"), pic);
                    CHOIMG.SaveAs(path);
                    chofer.CHOIMG = pic;
                }
                else
                {
                    ModelState.AddModelError("CHOIMG", "El sistema solo acepta imagenes JPG , JPEG y PNG");
                }
            }
            else
            {
                obj = db.Chofer.Find(chofer.IDCOD);
                chofer.CHOIMG = obj.CHOIMG;
            }


            if (ModelState.IsValid)
            {
                db.Entry(obj).State = EntityState.Detached;
                db.Entry(chofer).State = EntityState.Modified;
                 int res = db.SaveChanges();

                if (res>0) {
                    TempData["mensaje"] = "Los datos del chofer "+chofer.CHONOM+" se actualizaron correctamente.";
                }

                return RedirectToAction("Index");
            }
            return View(chofer);
        }


        [HttpPost]
        public ActionResult Eliminar(string id)
        {
            Chofer chofer = db.Chofer.Find(id);
            db.Chofer.Remove(chofer);
            int res = db.SaveChanges();

            if (res > 0)
            {
                TempData["mensaje"] = "Chofer " + chofer.CHONOM + " eliminado correctamente.";
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
