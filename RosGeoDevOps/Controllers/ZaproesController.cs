using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RosGeoDevOps;

namespace RosGeoDevOps.Controllers
{
    public class ZaproesController : Controller
    {
        private RosGeoDevOpsEntities1 db = new RosGeoDevOpsEntities1();

        // GET: Zaproes
        public ActionResult Index()
        {
            var zapros = db.Zaproes.Include(z => z.Sotrudnik).Include(z => z.Test).Include(z => z.Type_Zapros);
            return View(zapros.ToList());
        }

        // GET: Zaproes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zapro zapro = db.Zaproes.Find(id);
            if (zapro == null)
            {
                return HttpNotFound();
            }
            return View(zapro);
        }

        // GET: Zaproes/Create
        public ActionResult Create()
        {
            ViewBag.ID_Sotrudnik = new SelectList(db.Sotrudniks, "ID_Sotrudnik", "Fam");
            ViewBag.ID_Test = new SelectList(db.Tests, "ID_Test", "Nom");
            ViewBag.ID_TypeZapros = new SelectList(db.Type_Zapros, "ID_TypeZapros", "Naim");
            return View();
        }

        // POST: Zaproes/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Zapros,Nom,Naim,Opis,ID_Sotrudnik,ID_TypeZapros,DateZapr,ID_Test")] Zapro zapro)
        {
            if (ModelState.IsValid)
            {
                db.Zaproes.Add(zapro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Sotrudnik = new SelectList(db.Sotrudniks, "ID_Sotrudnik", "Fam", zapro.ID_Sotrudnik);
            ViewBag.ID_Test = new SelectList(db.Tests, "ID_Test", "Nom", zapro.ID_Test);
            ViewBag.ID_TypeZapros = new SelectList(db.Type_Zapros, "ID_TypeZapros", "Naim", zapro.ID_TypeZapros);
            return View(zapro);
        }

        // GET: Zaproes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zapro zapro = db.Zaproes.Find(id);
            if (zapro == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Sotrudnik = new SelectList(db.Sotrudniks, "ID_Sotrudnik", "Fam", zapro.ID_Sotrudnik);
            ViewBag.ID_Test = new SelectList(db.Tests, "ID_Test", "Nom", zapro.ID_Test);
            ViewBag.ID_TypeZapros = new SelectList(db.Type_Zapros, "ID_TypeZapros", "Naim", zapro.ID_TypeZapros);
            return View(zapro);
        }

        // POST: Zaproes/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Zapros,Nom,Naim,Opis,ID_Sotrudnik,ID_TypeZapros,DateZapr,ID_Test")] Zapro zapro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zapro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Sotrudnik = new SelectList(db.Sotrudniks, "ID_Sotrudnik", "Fam", zapro.ID_Sotrudnik);
            ViewBag.ID_Test = new SelectList(db.Tests, "ID_Test", "Nom", zapro.ID_Test);
            ViewBag.ID_TypeZapros = new SelectList(db.Type_Zapros, "ID_TypeZapros", "Naim", zapro.ID_TypeZapros);
            return View(zapro);
        }

        // GET: Zaproes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zapro zapro = db.Zaproes.Find(id);
            if (zapro == null)
            {
                return HttpNotFound();
            }
            return View(zapro);
        }

        // POST: Zaproes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zapro zapro = db.Zaproes.Find(id);
            db.Zaproes.Remove(zapro);
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
    }
}
