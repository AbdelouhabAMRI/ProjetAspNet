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
    public class ProjectsController : Controller
    {
        private NotesDeFraisEntities db = new NotesDeFraisEntities();

        // GET: Projects
        public ActionResult Index()
        {
            var projects = db.Projects.Include(p => p.Customers).Include(p => p.Poles);
            return View(projects.ToList());
        }

        // GET: Projects/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projects projects = db.Projects.Find(id);
            if (projects == null)
            {
                return HttpNotFound();
            }
            return View(projects);
        }

        // GET: Projects/Create
        public ActionResult Create()
        {
            ViewBag.Customer_ID = new SelectList(db.Customers, "Customer_ID", "Name");
            ViewBag.Pole_ID = new SelectList(db.Poles, "Pole_ID", "Name");
            return View();
        }

        // POST: Projects/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Project_ID,Name,Description,Budget,Customer_ID,Pole_ID")] Projects projects)
        {
            if (ModelState.IsValid)
            {
                projects.Project_ID = Guid.NewGuid();
                db.Projects.Add(projects);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Customer_ID = new SelectList(db.Customers, "Customer_ID", "Name", projects.Customer_ID);
            ViewBag.Pole_ID = new SelectList(db.Poles, "Pole_ID", "Name", projects.Pole_ID);
            return View(projects);
        }

        // GET: Projects/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projects projects = db.Projects.Find(id);
            if (projects == null)
            {
                return HttpNotFound();
            }
            ViewBag.Customer_ID = new SelectList(db.Customers, "Customer_ID", "Name", projects.Customer_ID);
            ViewBag.Pole_ID = new SelectList(db.Poles, "Pole_ID", "Name", projects.Pole_ID);
            return View(projects);
        }

        // POST: Projects/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Project_ID,Name,Description,Budget,Customer_ID,Pole_ID")] Projects projects)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projects).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Customer_ID = new SelectList(db.Customers, "Customer_ID", "Name", projects.Customer_ID);
            ViewBag.Pole_ID = new SelectList(db.Poles, "Pole_ID", "Name", projects.Pole_ID);
            return View(projects);
        }

        // GET: Projects/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projects projects = db.Projects.Find(id);
            if (projects == null)
            {
                return HttpNotFound();
            }
            return View(projects);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Projects projects = db.Projects.Find(id);
            db.Projects.Remove(projects);
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
