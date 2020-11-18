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
    public class AuthsController : Controller
    {
        private RosGeoDevOpsEntities1 db = new RosGeoDevOpsEntities1();

        // GET: Auths
        public ActionResult Index()
        {
            var auths = db.Auths.Include(a => a.Sotrudnik).Include(a => a.Role);
            return View(auths.ToList());
        }

        // GET: Auths/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auth auth = db.Auths.Find(id);
            if (auth == null)
            {
                return HttpNotFound();
            }
            return View(auth);
        }

        // GET: Auths/Create
        public ActionResult Create()
        {
            ViewBag.ID_Sotrudnik = new SelectList(db.Sotrudniks, "ID_Sotrudnik", "Fam");
            ViewBag.ID_Role = new SelectList(db.Roles, "ID_Role", "Naim");
            return View();
        }

        // POST: Auths/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Auth,Login,Password,ID_Sotrudnik,ID_Role")] Auth auth)
        {
            if (ModelState.IsValid)
            {
                db.Auths.Add(auth);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Sotrudnik = new SelectList(db.Sotrudniks, "ID_Sotrudnik", "Fam", auth.ID_Sotrudnik);
            ViewBag.ID_Role = new SelectList(db.Roles, "ID_Role", "Naim", auth.ID_Role);
            return View(auth);
        }

        // GET: Auths/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auth auth = db.Auths.Find(id);
            if (auth == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Sotrudnik = new SelectList(db.Sotrudniks, "ID_Sotrudnik", "Fam", auth.ID_Sotrudnik);
            ViewBag.ID_Role = new SelectList(db.Roles, "ID_Role", "Naim", auth.ID_Role);
            return View(auth);
        }

        // POST: Auths/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Auth,Login,Password,ID_Sotrudnik,ID_Role")] Auth auth)
        {
            if (ModelState.IsValid)
            {
                db.Entry(auth).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Sotrudnik = new SelectList(db.Sotrudniks, "ID_Sotrudnik", "Fam", auth.ID_Sotrudnik);
            ViewBag.ID_Role = new SelectList(db.Roles, "ID_Role", "Naim", auth.ID_Role);
            return View(auth);
        }

        // GET: Auths/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auth auth = db.Auths.Find(id);
            if (auth == null)
            {
                return HttpNotFound();
            }
            return View(auth);
        }

        // POST: Auths/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Auth auth = db.Auths.Find(id);
            db.Auths.Remove(auth);
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
