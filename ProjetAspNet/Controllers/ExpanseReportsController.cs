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
    public class ExpanseReportsController : Controller
    {
        private NotesDeFraisEntities db = new NotesDeFraisEntities();

        // GET: ExpanseReports
        public ActionResult Index()
        {
            var expanseReports = db.ExpanseReports.Include(e => e.Employees).Include(e => e.Employees1);
            return View(expanseReports.ToList());
        }

        // GET: ExpanseReports/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpanseReports expanseReports = db.ExpanseReports.Find(id);
            if (expanseReports == null)
            {
                return HttpNotFound();
            }
            return View(expanseReports);
        }

        // GET: ExpanseReports/Create
        public ActionResult Create()
        {
            ViewBag.Employee_ID = new SelectList(db.Employees, "Employee_ID", "User_ID");
            ViewBag.Author_ID = new SelectList(db.Employees, "Employee_ID", "User_ID");
            return View();
        }

        // POST: ExpanseReports/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExpanseReport_ID,Employee_ID,Author_ID,CreationDate,Year,Month,StatusCode,ManagerValidationDate,AccountingValidatationDate,Total_HT,Total_TVA,Total_TTC,ManagerComment,AccountingComment")] ExpanseReports expanseReports)
        {
            if (ModelState.IsValid)
            {
                expanseReports.ExpanseReport_ID = Guid.NewGuid();
                db.ExpanseReports.Add(expanseReports);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Employee_ID = new SelectList(db.Employees, "Employee_ID", "User_ID", expanseReports.Employee_ID);
            ViewBag.Author_ID = new SelectList(db.Employees, "Employee_ID", "User_ID", expanseReports.Author_ID);
            return View(expanseReports);
        }

        // GET: ExpanseReports/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpanseReports expanseReports = db.ExpanseReports.Find(id);
            if (expanseReports == null)
            {
                return HttpNotFound();
            }
            ViewBag.Employee_ID = new SelectList(db.Employees, "Employee_ID", "User_ID", expanseReports.Employee_ID);
            ViewBag.Author_ID = new SelectList(db.Employees, "Employee_ID", "User_ID", expanseReports.Author_ID);
            return View(expanseReports);
        }

        // POST: ExpanseReports/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExpanseReport_ID,Employee_ID,Author_ID,CreationDate,Year,Month,StatusCode,ManagerValidationDate,AccountingValidatationDate,Total_HT,Total_TVA,Total_TTC,ManagerComment,AccountingComment")] ExpanseReports expanseReports)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expanseReports).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Employee_ID = new SelectList(db.Employees, "Employee_ID", "User_ID", expanseReports.Employee_ID);
            ViewBag.Author_ID = new SelectList(db.Employees, "Employee_ID", "User_ID", expanseReports.Author_ID);
            return View(expanseReports);
        }

        // GET: ExpanseReports/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpanseReports expanseReports = db.ExpanseReports.Find(id);
            if (expanseReports == null)
            {
                return HttpNotFound();
            }
            return View(expanseReports);
        }

        // POST: ExpanseReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ExpanseReports expanseReports = db.ExpanseReports.Find(id);
            db.ExpanseReports.Remove(expanseReports);
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
