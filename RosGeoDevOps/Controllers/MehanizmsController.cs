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
    public class MehanizmsController : Controller
    {
        private RosGeoDevOpsEntities1 db = new RosGeoDevOpsEntities1();

        // GET: Mehanizms
        public ActionResult Index()
        {
            var mehanizms = db.Mehanizms.Include(m => m.Status);
            return View(mehanizms.ToList());
        }

        // GET: Mehanizms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mehanizm mehanizm = db.Mehanizms.Find(id);
            if (mehanizm == null)
            {
                return HttpNotFound();
            }
            return View(mehanizm);
        }

        // GET: Mehanizms/Create
        public ActionResult Create()
        {
            ViewBag.ID_Status = new SelectList(db.Status, "ID_Status", "Naim");
            return View();
        }

        // POST: Mehanizms/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Mehanizm,Naim,Opis,ID_Status")] Mehanizm mehanizm)
        {
            if (ModelState.IsValid)
            {
                db.Mehanizms.Add(mehanizm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Status = new SelectList(db.Status, "ID_Status", "Naim", mehanizm.ID_Status);
            return View(mehanizm);
        }

        // GET: Mehanizms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mehanizm mehanizm = db.Mehanizms.Find(id);
            if (mehanizm == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Status = new SelectList(db.Status, "ID_Status", "Naim", mehanizm.ID_Status);
            return View(mehanizm);
        }

        // POST: Mehanizms/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Mehanizm,Naim,Opis,ID_Status")] Mehanizm mehanizm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mehanizm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Status = new SelectList(db.Status, "ID_Status", "Naim", mehanizm.ID_Status);
            return View(mehanizm);
        }

        // GET: Mehanizms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mehanizm mehanizm = db.Mehanizms.Find(id);
            if (mehanizm == null)
            {
                return HttpNotFound();
            }
            return View(mehanizm);
        }

        // POST: Mehanizms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mehanizm mehanizm = db.Mehanizms.Find(id);
            db.Mehanizms.Remove(mehanizm);
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
