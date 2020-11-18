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
    public class ResheniesController : Controller
    {
        private RosGeoDevOpsEntities1 db = new RosGeoDevOpsEntities1();

        // GET: Reshenies
        public ActionResult Index()
        {
            var reshenies = db.Reshenies.Include(r => r.Sotrudnik).Include(r => r.Zapro);
            return View(reshenies.ToList());
        }

        // GET: Reshenies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reshenie reshenie = db.Reshenies.Find(id);
            if (reshenie == null)
            {
                return HttpNotFound();
            }
            return View(reshenie);
        }

        // GET: Reshenies/Create
        public ActionResult Create()
        {
            ViewBag.ID_Sotrudnik = new SelectList(db.Sotrudniks, "ID_Sotrudnik", "Fam");
            ViewBag.ID_Zapros = new SelectList(db.Zaproes, "ID_Zapros", "Nom");
            return View();
        }

        // POST: Reshenies/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Reshenie,Nom,Opis,ID_Zapros,ID_Sotrudnik")] Reshenie reshenie)
        {
            if (ModelState.IsValid)
            {
                db.Reshenies.Add(reshenie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Sotrudnik = new SelectList(db.Sotrudniks, "ID_Sotrudnik", "Fam", reshenie.ID_Sotrudnik);
            ViewBag.ID_Zapros = new SelectList(db.Zaproes, "ID_Zapros", "Nom", reshenie.ID_Zapros);
            return View(reshenie);
        }

        // GET: Reshenies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reshenie reshenie = db.Reshenies.Find(id);
            if (reshenie == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Sotrudnik = new SelectList(db.Sotrudniks, "ID_Sotrudnik", "Fam", reshenie.ID_Sotrudnik);
            ViewBag.ID_Zapros = new SelectList(db.Zaproes, "ID_Zapros", "Nom", reshenie.ID_Zapros);
            return View(reshenie);
        }

        // POST: Reshenies/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Reshenie,Nom,Opis,ID_Zapros,ID_Sotrudnik")] Reshenie reshenie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reshenie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Sotrudnik = new SelectList(db.Sotrudniks, "ID_Sotrudnik", "Fam", reshenie.ID_Sotrudnik);
            ViewBag.ID_Zapros = new SelectList(db.Zaproes, "ID_Zapros", "Nom", reshenie.ID_Zapros);
            return View(reshenie);
        }

        // GET: Reshenies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reshenie reshenie = db.Reshenies.Find(id);
            if (reshenie == null)
            {
                return HttpNotFound();
            }
            return View(reshenie);
        }

        // POST: Reshenies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reshenie reshenie = db.Reshenies.Find(id);
            db.Reshenies.Remove(reshenie);
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
