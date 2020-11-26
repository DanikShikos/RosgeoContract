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
        //все записи
        public ActionResult Index()
        {
            //берет все записи запроса с выборкой данных из связанных таблиц
            //include это что то типа inner join
            var zapros = db.Zaproes.Include(z => z.Sotrudnik).Include(z => z.Test).Include(z => z.Type_Zapros);
            //передает на вьюшку все записи в виде списка
            return View(zapros.ToList());
        }

        // GET: Zaproes/Details
        //детали о записи
        public ActionResult Details(int? id)
        {
            //проверка существует ли эта запись
            if (id == null)
            {
                //если не существует то возвращает статус "запрос не прошел"
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //если существует то ищет запрос с этим id
            Zapro zapro = db.Zaproes.Find(id);
            //если запись не найдена
            if (zapro == null)
            {
                //возвращает страницу "страница не найдена"
                return HttpNotFound();
            }
            //передает на вьшку деталей в виде одного экземпляра модели
            return View(zapro);
        }

        // GET: Zaproes/Create
        //переход на создание записи
        public ActionResult Create()
        {
            //заполнение виртуальных комбобоксов.   таблица       значения     отображение
            ViewBag.ID_Sotrudnik = new SelectList(db.Sotrudniks, "ID_Sotrudnik", "Fam");
            ViewBag.ID_Test = new SelectList(db.Tests, "ID_Test", "Nom");
            ViewBag.ID_TypeZapros = new SelectList(db.Type_Zapros, "ID_TypeZapros", "Naim");
            //переход на вьюшку создания
            return View();
        }

        // POST: Zaproes/Create
        //отправка данных для создания записи
        //указание то, чтобы только post запросы обрабатывались этой процедурой
        [HttpPost]
        //защита от подделки запросов
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Zapros,Nom,Naim,Opis,ID_Sotrudnik,ID_TypeZapros,DateZapr,ID_Test")] Zapro zapro)
        {
            //если модель доступна
            if (ModelState.IsValid)
            {
                //добавляет указанные выше данные
                db.Zaproes.Add(zapro);
                //сохраняет изменения
                db.SaveChanges();
                //переходит к списку записей
                return RedirectToAction("Index");
            }
            //иначе заново заполняет поля и перезагружает страницу
            ViewBag.ID_Sotrudnik = new SelectList(db.Sotrudniks, "ID_Sotrudnik", "Fam", zapro.ID_Sotrudnik);
            ViewBag.ID_Test = new SelectList(db.Tests, "ID_Test", "Nom", zapro.ID_Test);
            ViewBag.ID_TypeZapros = new SelectList(db.Type_Zapros, "ID_TypeZapros", "Naim", zapro.ID_TypeZapros);
            return View(zapro);
        }

        // GET: Zaproes/Edit
        //переход на редактирование записи
        public ActionResult Edit(int? id)
        {
            //если id Не передан
            if (id == null)
            {
                //возвращает состояние "запрос не прошел"
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //если передан то ищет запись с этим id
            Zapro zapro = db.Zaproes.Find(id);
            //если не найден запрос
            if (zapro == null)
            {
                //ошибка 404 "страница не найдена"
                return HttpNotFound();
            }
            //если найден заполняет выпадающие списки
            ViewBag.ID_Sotrudnik = new SelectList(db.Sotrudniks, "ID_Sotrudnik", "Fam", zapro.ID_Sotrudnik);
            ViewBag.ID_Test = new SelectList(db.Tests, "ID_Test", "Nom", zapro.ID_Test);
            ViewBag.ID_TypeZapros = new SelectList(db.Type_Zapros, "ID_TypeZapros", "Naim", zapro.ID_TypeZapros);
            //переход на вьшку редактирования с передачей полученного запроса
            return View(zapro);
        }

        // POST: Zaproes/Edit/5
        //изменение записи после заполнения данных
        //указание на пост-запрос
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Zapros,Nom,Naim,Opis,ID_Sotrudnik,ID_TypeZapros,DateZapr,ID_Test")] Zapro zapro)
        {
            //если модель доступна
            if (ModelState.IsValid)
            {
             
                //изменение состояния на изменяемое с учетом введенных параметров
                db.Entry(zapro).State = EntityState.Modified;
                //сохранение изменений
                db.SaveChanges();
                //переход к списку записей
                return RedirectToAction("Index");
            }
            //если недоступна заполнение комбобоксов
            ViewBag.ID_Sotrudnik = new SelectList(db.Sotrudniks, "ID_Sotrudnik", "Fam", zapro.ID_Sotrudnik);
            ViewBag.ID_Test = new SelectList(db.Tests, "ID_Test", "Nom", zapro.ID_Test);
            ViewBag.ID_TypeZapros = new SelectList(db.Type_Zapros, "ID_TypeZapros", "Naim", zapro.ID_TypeZapros);
            //перезагрузка страницы
            return View(zapro);
        }

        // GET: Zaproes/Delete
        //переход на страницу удаления
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
            //открывает форму с передачей найденной записи
            return View(zapro);
        }

        // POST: Zaproes/Delete
        // удаление записи после подтверждения удаления
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //находит запись с этим id
            Zapro zapro = db.Zaproes.Find(id);
            //удаляет эту запись
            db.Zaproes.Remove(zapro);
            //сохраняет изменения
            db.SaveChanges();
            //переходит на форму списка записей
            return RedirectToAction("Index");
        }
        //освобождает используемые ресурсы контекста
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
