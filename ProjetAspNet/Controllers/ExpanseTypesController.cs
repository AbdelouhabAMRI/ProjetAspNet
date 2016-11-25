using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetAspNet.Models;

namespace ProjetAspNet.Controllers
{
    public class ExpanseTypesController : Controller
    {
        private NotesDeFraisEntities db = new NotesDeFraisEntities();

        // GET: ExpanseTypes
        public ActionResult Index()
        {
            var expanseTypes = db.ExpanseTypes.Include(e => e.Tvas);
            return View(expanseTypes.ToList());
        }

        // GET: ExpanseTypes/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpanseTypes expanseTypes = db.ExpanseTypes.Find(id);
            if (expanseTypes == null)
            {
                return HttpNotFound();
            }
            return View(expanseTypes);
        }

        // GET: ExpanseTypes/Create
        public ActionResult Create()
        {
            ViewBag.Tva_ID = new SelectList(db.Tvas, "TVA_ID", "Name");
            return View();
        }

        // POST: ExpanseTypes/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExpenseType_ID,Name,Ceiling,Fixed,OnlyManagers,Tva_ID")] ExpanseTypes expanseTypes)
        {
            if (ModelState.IsValid)
            {
                expanseTypes.ExpenseType_ID = Guid.NewGuid();
                db.ExpanseTypes.Add(expanseTypes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Tva_ID = new SelectList(db.Tvas, "TVA_ID", "Name", expanseTypes.Tva_ID);
            return View(expanseTypes);
        }

        // GET: ExpanseTypes/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpanseTypes expanseTypes = db.ExpanseTypes.Find(id);
            if (expanseTypes == null)
            {
                return HttpNotFound();
            }
            ViewBag.Tva_ID = new SelectList(db.Tvas, "TVA_ID", "Name", expanseTypes.Tva_ID);
            return View(expanseTypes);
        }

        // POST: ExpanseTypes/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExpenseType_ID,Name,Ceiling,Fixed,OnlyManagers,Tva_ID")] ExpanseTypes expanseTypes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expanseTypes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Tva_ID = new SelectList(db.Tvas, "TVA_ID", "Name", expanseTypes.Tva_ID);
            return View(expanseTypes);
        }

        // GET: ExpanseTypes/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpanseTypes expanseTypes = db.ExpanseTypes.Find(id);
            if (expanseTypes == null)
            {
                return HttpNotFound();
            }
            return View(expanseTypes);
        }

        // POST: ExpanseTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ExpanseTypes expanseTypes = db.ExpanseTypes.Find(id);
            db.ExpanseTypes.Remove(expanseTypes);
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
