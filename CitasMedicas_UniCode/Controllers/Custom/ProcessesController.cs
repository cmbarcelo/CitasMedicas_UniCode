using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CitasMedicas_UniCode.Models;
using CitasMedicas_UniCode.Models.ModelCustom;

namespace CitasMedicas_UniCode.Controllers.Custom
{
    public class ProcessesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Processes
        public ActionResult Index()
        {
            var processes = db.Processes.Include(p => p.Treatment);
            return View(processes.ToList());
        }

        // GET: Processes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Process process = db.Processes.Find(id);
            if (process == null)
            {
                return HttpNotFound();
            }
            return View(process);
        }

        // GET: Processes/Create
        public ActionResult Create()
        {
            ViewBag.IdTreatment = new SelectList(db.Treatments, "IdTreatment", "TreatmentName");
            return View();
        }

        // POST: Processes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProcess,ProcessName,Price,IdTreatment")] Process process)
        {
            if (ModelState.IsValid)
            {
                db.Processes.Add(process);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdTreatment = new SelectList(db.Treatments, "IdTreatment", "TreatmentName", process.IdTreatment);
            return View(process);
        }

        // GET: Processes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Process process = db.Processes.Find(id);
            if (process == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTreatment = new SelectList(db.Treatments, "IdTreatment", "TreatmentName", process.IdTreatment);
            return View(process);
        }

        // POST: Processes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProcess,ProcessName,Price,IdTreatment")] Process process)
        {
            if (ModelState.IsValid)
            {
                db.Entry(process).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdTreatment = new SelectList(db.Treatments, "IdTreatment", "TreatmentName", process.IdTreatment);
            return View(process);
        }

        // GET: Processes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Process process = db.Processes.Find(id);
            if (process == null)
            {
                return HttpNotFound();
            }
            return View(process);
        }

        // POST: Processes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Process process = db.Processes.Find(id);
            db.Processes.Remove(process);
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
