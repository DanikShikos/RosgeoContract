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
    public class SotrudniksController : Controller
    {
        private RosGeoDevOpsEntities1 db = new RosGeoDevOpsEntities1();

        // GET: Sotrudniks
        public ActionResult Index()
        {
            return View(db.Sotrudniks.ToList());
        }

        // GET: Sotrudniks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sotrudnik sotrudnik = db.Sotrudniks.Find(id);
            if (sotrudnik == null)
            {
                return HttpNotFound();
            }
            return View(sotrudnik);
        }

        // GET: Sotrudniks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sotrudniks/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Sotrudnik,Fam,Im,Otch,Ser,Nom,Mail")] Sotrudnik sotrudnik)
        {
            if (ModelState.IsValid)
            {
                db.Sotrudniks.Add(sotrudnik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sotrudnik);
        }

        // GET: Sotrudniks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sotrudnik sotrudnik = db.Sotrudniks.Find(id);
            if (sotrudnik == null)
            {
                return HttpNotFound();
            }
            return View(sotrudnik);
        }

        // POST: Sotrudniks/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Sotrudnik,Fam,Im,Otch,Ser,Nom,Mail")] Sotrudnik sotrudnik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sotrudnik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sotrudnik);
        }

        // GET: Sotrudniks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sotrudnik sotrudnik = db.Sotrudniks.Find(id);
            if (sotrudnik == null)
            {
                return HttpNotFound();
            }
            return View(sotrudnik);
        }

        // POST: Sotrudniks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sotrudnik sotrudnik = db.Sotrudniks.Find(id);
            db.Sotrudniks.Remove(sotrudnik);
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
