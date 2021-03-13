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
    public class ConsultoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Consultories
        public ActionResult Index()
        {
            return View(db.Consultories.ToList());
        }

        // GET: Consultories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultory consultory = db.Consultories.Find(id);
            if (consultory == null)
            {
                return HttpNotFound();
            }
            return View(consultory);
        }

        // GET: Consultories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Consultories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdConsultory,ConsultoryName,ConsultoryEmail")] Consultory consultory)
        {
            if (ModelState.IsValid)
            {
                db.Consultories.Add(consultory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(consultory);
        }

        // GET: Consultories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultory consultory = db.Consultories.Find(id);
            if (consultory == null)
            {
                return HttpNotFound();
            }
            return View(consultory);
        }

        // POST: Consultories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdConsultory,ConsultoryName,ConsultoryEmail")] Consultory consultory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consultory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(consultory);
        }

        // GET: Consultories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultory consultory = db.Consultories.Find(id);
            if (consultory == null)
            {
                return HttpNotFound();
            }
            return View(consultory);
        }

        // POST: Consultories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Consultory consultory = db.Consultories.Find(id);
            db.Consultories.Remove(consultory);
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
