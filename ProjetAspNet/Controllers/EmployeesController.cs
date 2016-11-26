using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetAspNet.Models;

namespace ProjetAspNet.Controllers
{
    public class EmployeesController : Controller
    {
        private NotesDeFraisEntities db = new NotesDeFraisEntities();

        // GET: Employees
        public async Task<ActionResult> Index()
        {
            var employees = db.Employees.Include(e => e.AspNetUsers).Include(e => e.Poles);
            return View(await employees.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employees employees = await db.Employees.FindAsync(id);
            if (employees == null)
            {
                return HttpNotFound();
            }
            return View(employees);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.User_ID = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.Pole_ID = new SelectList(db.Poles, "Pole_ID", "Name");
            return View();
        }

        // POST: Employees/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Employee_ID,User_ID,FirstName,LastName,Email,Telephone,Pole_ID")] Employees employees)
        {
            if (ModelState.IsValid)
            {
                employees.Employee_ID = Guid.NewGuid();
                db.Employees.Add(employees);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.User_ID = new SelectList(db.AspNetUsers, "Id", "Email", employees.User_ID);
            ViewBag.Pole_ID = new SelectList(db.Poles, "Pole_ID", "Name", employees.Pole_ID);
            return View(employees);
        }

        // GET: Employees/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employees employees = await db.Employees.FindAsync(id);
            if (employees == null)
            {
                return HttpNotFound();
            }
            ViewBag.User_ID = new SelectList(db.AspNetUsers, "Id", "Email", employees.User_ID);
            ViewBag.Pole_ID = new SelectList(db.Poles, "Pole_ID", "Name", employees.Pole_ID);
            return View(employees);
        }

        // POST: Employees/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Employee_ID,User_ID,FirstName,LastName,Email,Telephone,Pole_ID")] Employees employees)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employees).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.User_ID = new SelectList(db.AspNetUsers, "Id", "Email", employees.User_ID);
            ViewBag.Pole_ID = new SelectList(db.Poles, "Pole_ID", "Name", employees.Pole_ID);
            return View(employees);
        }

        // GET: Employees/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employees employees = await db.Employees.FindAsync(id);
            if (employees == null)
            {
                return HttpNotFound();
            }
            return View(employees);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Employees employees = await db.Employees.FindAsync(id);
            db.Employees.Remove(employees);
            await db.SaveChangesAsync();
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
