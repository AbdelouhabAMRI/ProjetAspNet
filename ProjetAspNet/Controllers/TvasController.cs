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
    public class TvasController : Controller
    {
        private NotesDeFraisEntities db = new NotesDeFraisEntities();

        // GET: Tvas
        public ActionResult Index()
        {
            return View(db.Tvas.ToList());
        }

        // GET: Tvas/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tvas tvas = db.Tvas.Find(id);
            if (tvas == null)
            {
                return HttpNotFound();
            }
            return View(tvas);
        }

        // GET: Tvas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tvas/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TVA_ID,Name,Value")] Tvas tvas)
        {
            if (ModelState.IsValid)
            {
                tvas.TVA_ID = Guid.NewGuid();
                db.Tvas.Add(tvas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tvas);
        }

        // GET: Tvas/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tvas tvas = db.Tvas.Find(id);
            if (tvas == null)
            {
                return HttpNotFound();
            }
            return View(tvas);
        }

        // POST: Tvas/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TVA_ID,Name,Value")] Tvas tvas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tvas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tvas);
        }

        // GET: Tvas/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tvas tvas = db.Tvas.Find(id);
            if (tvas == null)
            {
                return HttpNotFound();
            }
            return View(tvas);
        }

        // POST: Tvas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Tvas tvas = db.Tvas.Find(id);
            db.Tvas.Remove(tvas);
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
