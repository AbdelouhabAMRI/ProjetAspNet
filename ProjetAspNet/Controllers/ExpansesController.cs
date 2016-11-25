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
    public class ExpansesController : Controller
    {
        private NotesDeFraisEntities db = new NotesDeFraisEntities();

        // GET: Expanses
        public ActionResult Index()
        {
            var expanses = db.Expanses.Include(e => e.Customers).Include(e => e.ExpanseReports).Include(e => e.ExpanseTypes).Include(e => e.Projects);
            return View(expanses.ToList());
        }

        // GET: Expanses/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expanses expanses = db.Expanses.Find(id);
            if (expanses == null)
            {
                return HttpNotFound();
            }
            return View(expanses);
        }

        // GET: Expanses/Create
        public ActionResult Create()
        {
            ViewBag.Customer_ID = new SelectList(db.Customers, "Customer_ID", "Name");
            ViewBag.ExpanseReport_ID = new SelectList(db.ExpanseReports, "ExpanseReport_ID", "ManagerComment");
            ViewBag.ExpanseType_ID = new SelectList(db.ExpanseTypes, "ExpenseType_ID", "Name");
            ViewBag.Project_ID = new SelectList(db.Projects, "Project_ID", "Name");
            return View();
        }

        // POST: Expanses/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Expanse_ID,ExpanseReport_ID,Day,ExpanseType_ID,Customer_ID,Project_ID,Amount_HT,Amount_TVA,Amount_TTC")] Expanses expanses)
        {
            if (ModelState.IsValid)
            {
                expanses.Expanse_ID = Guid.NewGuid();
                db.Expanses.Add(expanses);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Customer_ID = new SelectList(db.Customers, "Customer_ID", "Name", expanses.Customer_ID);
            ViewBag.ExpanseReport_ID = new SelectList(db.ExpanseReports, "ExpanseReport_ID", "ManagerComment", expanses.ExpanseReport_ID);
            ViewBag.ExpanseType_ID = new SelectList(db.ExpanseTypes, "ExpenseType_ID", "Name", expanses.ExpanseType_ID);
            ViewBag.Project_ID = new SelectList(db.Projects, "Project_ID", "Name", expanses.Project_ID);
            return View(expanses);
        }

        // GET: Expanses/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expanses expanses = db.Expanses.Find(id);
            if (expanses == null)
            {
                return HttpNotFound();
            }
            ViewBag.Customer_ID = new SelectList(db.Customers, "Customer_ID", "Name", expanses.Customer_ID);
            ViewBag.ExpanseReport_ID = new SelectList(db.ExpanseReports, "ExpanseReport_ID", "ManagerComment", expanses.ExpanseReport_ID);
            ViewBag.ExpanseType_ID = new SelectList(db.ExpanseTypes, "ExpenseType_ID", "Name", expanses.ExpanseType_ID);
            ViewBag.Project_ID = new SelectList(db.Projects, "Project_ID", "Name", expanses.Project_ID);
            return View(expanses);
        }

        // POST: Expanses/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Expanse_ID,ExpanseReport_ID,Day,ExpanseType_ID,Customer_ID,Project_ID,Amount_HT,Amount_TVA,Amount_TTC")] Expanses expanses)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expanses).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Customer_ID = new SelectList(db.Customers, "Customer_ID", "Name", expanses.Customer_ID);
            ViewBag.ExpanseReport_ID = new SelectList(db.ExpanseReports, "ExpanseReport_ID", "ManagerComment", expanses.ExpanseReport_ID);
            ViewBag.ExpanseType_ID = new SelectList(db.ExpanseTypes, "ExpenseType_ID", "Name", expanses.ExpanseType_ID);
            ViewBag.Project_ID = new SelectList(db.Projects, "Project_ID", "Name", expanses.Project_ID);
            return View(expanses);
        }

        // GET: Expanses/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expanses expanses = db.Expanses.Find(id);
            if (expanses == null)
            {
                return HttpNotFound();
            }
            return View(expanses);
        }

        // POST: Expanses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Expanses expanses = db.Expanses.Find(id);
            db.Expanses.Remove(expanses);
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
