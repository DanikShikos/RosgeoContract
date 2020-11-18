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
    public class TestsController : Controller
    {
        private RosGeoDevOpsEntities1 db = new RosGeoDevOpsEntities1();

        // GET: Tests
        public ActionResult Index()
        {
            var tests = db.Tests.Include(t => t.Mehanizm).Include(t => t.Type_Test);
            return View(tests.ToList());
        }

        // GET: Tests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = db.Tests.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        // GET: Tests/Create
        public ActionResult Create()
        {
            ViewBag.ID_Mehanizm = new SelectList(db.Mehanizms, "ID_Mehanizm", "Naim");
            ViewBag.ID_TypeTest = new SelectList(db.Type_Test, "ID_TypeTest", "Naim");
            return View();
        }

        // POST: Tests/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Test,Nom,Naim,Rezult,ID_TypeTest,ID_Mehanizm,DateTest")] Test test)
        {
            if (ModelState.IsValid)
            {
                db.Tests.Add(test);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Mehanizm = new SelectList(db.Mehanizms, "ID_Mehanizm", "Naim", test.ID_Mehanizm);
            ViewBag.ID_TypeTest = new SelectList(db.Type_Test, "ID_TypeTest", "Naim", test.ID_TypeTest);
            return View(test);
        }

        // GET: Tests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = db.Tests.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Mehanizm = new SelectList(db.Mehanizms, "ID_Mehanizm", "Naim", test.ID_Mehanizm);
            ViewBag.ID_TypeTest = new SelectList(db.Type_Test, "ID_TypeTest", "Naim", test.ID_TypeTest);
            return View(test);
        }

        // POST: Tests/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Test,Nom,Naim,Rezult,ID_TypeTest,ID_Mehanizm,DateTest")] Test test)
        {
            if (ModelState.IsValid)
            {
                db.Entry(test).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Mehanizm = new SelectList(db.Mehanizms, "ID_Mehanizm", "Naim", test.ID_Mehanizm);
            ViewBag.ID_TypeTest = new SelectList(db.Type_Test, "ID_TypeTest", "Naim", test.ID_TypeTest);
            return View(test);
        }

        // GET: Tests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = db.Tests.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        // POST: Tests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Test test = db.Tests.Find(id);
            db.Tests.Remove(test);
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
