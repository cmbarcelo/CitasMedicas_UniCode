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
    public class MedicalAppointmentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MedicalAppointments
        public ActionResult Index()
        {
            var medicalAppointments = db.MedicalAppointments.Include(m => m.Consultory).Include(m => m.Doctor).Include(m => m.Patient).Include(m => m.Process).Include(m => m.Treatment);
            return View(medicalAppointments.ToList());
        }

        // GET: MedicalAppointments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {

                return View();
            }
            MedicalAppointments medicalAppointments = db.MedicalAppointments.Find(id);
            if (medicalAppointments == null)
            {
                return HttpNotFound();
            }
            return View(medicalAppointments);
        }

        // GET: MedicalAppointments/Create
        public ActionResult Create()
        {
            ViewBag.IdConsultory = new SelectList(db.Consultories, "IdConsultory", "ConsultoryName");
            ViewBag.IdDoctor = new SelectList(db.Doctors, "IdDoctor", "NameDoctor");
            ViewBag.IdPatient = new SelectList(db.Patients, "IdPatient", "CURP");
            ViewBag.IdProcess = new SelectList(db.Processes, "IdProcess", "ProcessName");
            ViewBag.IdTreatment = new SelectList(db.Treatments, "IdTreatment", "TreatmentName");
            return View();
        }

        // POST: MedicalAppointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdMedicalAppointments,Date,IdDoctor,IdConsultory,IdPatient,IdTreatment,IdProcess")] MedicalAppointments medicalAppointments)
        {
            if (ModelState.IsValid)
            {
                db.MedicalAppointments.Add(medicalAppointments);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdConsultory = new SelectList(db.Consultories, "IdConsultory", "ConsultoryName", medicalAppointments.IdConsultory);
            ViewBag.IdDoctor = new SelectList(db.Doctors, "IdDoctor", "NameDoctor", medicalAppointments.IdDoctor);
            ViewBag.IdPatient = new SelectList(db.Patients, "IdPatient", "CURP", medicalAppointments.IdPatient);
            ViewBag.IdProcess = new SelectList(db.Processes, "IdProcess", "ProcessName", medicalAppointments.IdProcess);
            ViewBag.IdTreatment = new SelectList(db.Treatments, "IdTreatment", "TreatmentName", medicalAppointments.IdTreatment);
            return View(medicalAppointments);
        }

        // GET: MedicalAppointments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalAppointments medicalAppointments = db.MedicalAppointments.Find(id);
            if (medicalAppointments == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdConsultory = new SelectList(db.Consultories, "IdConsultory", "ConsultoryName", medicalAppointments.IdConsultory);
            ViewBag.IdDoctor = new SelectList(db.Doctors, "IdDoctor", "NameDoctor", medicalAppointments.IdDoctor);
            ViewBag.IdPatient = new SelectList(db.Patients, "IdPatient", "CURP", medicalAppointments.IdPatient);
            ViewBag.IdProcess = new SelectList(db.Processes, "IdProcess", "ProcessName", medicalAppointments.IdProcess);
            ViewBag.IdTreatment = new SelectList(db.Treatments, "IdTreatment", "TreatmentName", medicalAppointments.IdTreatment);
            return View(medicalAppointments);
        }

        // POST: MedicalAppointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdMedicalAppointments,Date,IdDoctor,IdConsultory,IdPatient,IdTreatment,IdProcess")] MedicalAppointments medicalAppointments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicalAppointments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdConsultory = new SelectList(db.Consultories, "IdConsultory", "ConsultoryName", medicalAppointments.IdConsultory);
            ViewBag.IdDoctor = new SelectList(db.Doctors, "IdDoctor", "NameDoctor", medicalAppointments.IdDoctor);
            ViewBag.IdPatient = new SelectList(db.Patients, "IdPatient", "CURP", medicalAppointments.IdPatient);
            ViewBag.IdProcess = new SelectList(db.Processes, "IdProcess", "ProcessName", medicalAppointments.IdProcess);
            ViewBag.IdTreatment = new SelectList(db.Treatments, "IdTreatment", "TreatmentName", medicalAppointments.IdTreatment);
            return View(medicalAppointments);
        }

        // GET: MedicalAppointments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalAppointments medicalAppointments = db.MedicalAppointments.Find(id);
            if (medicalAppointments == null)
            {
                return HttpNotFound();
            }
            return View(medicalAppointments);
        }

        // POST: MedicalAppointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MedicalAppointments medicalAppointments = db.MedicalAppointments.Find(id);
            db.MedicalAppointments.Remove(medicalAppointments);
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
