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
    public class PolesController : Controller
    {
        private NotesDeFraisEntities db = new NotesDeFraisEntities();

        // GET: Poles
        public ActionResult Index()
        {
            var poles = db.Poles.Include(p => p.Employees1);
            return View(poles.ToList());
        }

        // GET: Poles/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poles poles = db.Poles.Find(id);
            if (poles == null)
            {
                return HttpNotFound();
            }
            return View(poles);
        }

        // GET: Poles/Create
        public ActionResult Create()
        {
            ViewBag.Manager_ID = new SelectList(db.Employees, "Employee_ID", "User_ID");
            return View();
        }

        // POST: Poles/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Pole_ID,Name,Manager_ID")] Poles poles)
        {
            if (ModelState.IsValid)
            {
                poles.Pole_ID = Guid.NewGuid();
                db.Poles.Add(poles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Manager_ID = new SelectList(db.Employees, "Employee_ID", "User_ID", poles.Manager_ID);
            return View(poles);
        }

        // GET: Poles/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poles poles = db.Poles.Find(id);
            if (poles == null)
            {
                return HttpNotFound();
            }
            ViewBag.Manager_ID = new SelectList(db.Employees, "Employee_ID", "User_ID", poles.Manager_ID);
            return View(poles);
        }

        // POST: Poles/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Pole_ID,Name,Manager_ID")] Poles poles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(poles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Manager_ID = new SelectList(db.Employees, "Employee_ID", "User_ID", poles.Manager_ID);
            return View(poles);
        }

        // GET: Poles/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poles poles = db.Poles.Find(id);
            if (poles == null)
            {
                return HttpNotFound();
            }
            return View(poles);
        }

        // POST: Poles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Poles poles = db.Poles.Find(id);
            db.Poles.Remove(poles);
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
