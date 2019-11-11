using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using sisoC.Models;

namespace sisoC.Controllers
{
    public class ExamenController : Controller
    {
        private SisoCdataContext db = new SisoCdataContext();

        // GET: Examen
        public ActionResult Index()
        {
            var examen = db.Examen.Include(e => e.Enterprise).Include(e => e.ExActivo).Include(e => e.ExamenLevel).Include(e => e.ExamenType).Include(e => e.ExFono).Include(e => e.ExMedico).Include(e => e.ExOpto).Include(e => e.ExPsico).Include(e => e.OtherExam).Include(e => e.Pacient);
            return View(examen.ToList());
        }

        // GET: Examen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examen examen = db.Examen.Find(id);
            if (examen == null)
            {
                return HttpNotFound();
            }
            return View(examen);
        }

        // GET: Examen/Create
        public ActionResult Create()
        {
            ViewBag.EnterpriseID = new SelectList(db.Enterprises, "EnterpriseID", "Document");
            ViewBag.ExActivoID = new SelectList(db.ExActivoes, "ExActivoID", "Description");
            ViewBag.ExamenLevelID = new SelectList(db.ExamenLevels, "ExamenLevelID", "Description");
            ViewBag.ExamenTypeID = new SelectList(db.ExamenTypes, "ExamenTypeID", "Description");
            ViewBag.ExFonoID = new SelectList(db.ExFonoes, "ExFonoID", "Description");
            ViewBag.ExMedicoID = new SelectList(db.ExMedicoes, "ExMedicoID", "Description");
            ViewBag.ExOptoID = new SelectList(db.ExOptoes, "ExOptoID", "Description");
            ViewBag.ExPsicoID = new SelectList(db.ExPsicoes, "ExPsicoID", "Description");
            ViewBag.OtherExamID = new SelectList(db.OtherExams, "OtherExamID", "Description");
            ViewBag.PacientID = new SelectList(db.Pacients, "PacientID", "Document");
            return View();
        }

        // POST: Examen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExamenID,Date,Time,ExamenTypeID,ExamenLevelID,OtherExamID,PacientID,EnterpriseID,ExOptoID,ExFonoID,ExPsicoID,ExMedicoID,ExActivoID")] Examen examen)
        {
            if (ModelState.IsValid)
            {
                db.Examen.Add(examen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EnterpriseID = new SelectList(db.Enterprises, "EnterpriseID", "Document", examen.EnterpriseID);
            ViewBag.ExActivoID = new SelectList(db.ExActivoes, "ExActivoID", "Description", examen.ExActivoID);
            ViewBag.ExamenLevelID = new SelectList(db.ExamenLevels, "ExamenLevelID", "Description", examen.ExamenLevelID);
            ViewBag.ExamenTypeID = new SelectList(db.ExamenTypes, "ExamenTypeID", "Description", examen.ExamenTypeID);
            ViewBag.ExFonoID = new SelectList(db.ExFonoes, "ExFonoID", "Description", examen.ExFonoID);
            ViewBag.ExMedicoID = new SelectList(db.ExMedicoes, "ExMedicoID", "Description", examen.ExMedicoID);
            ViewBag.ExOptoID = new SelectList(db.ExOptoes, "ExOptoID", "Description", examen.ExOptoID);
            ViewBag.ExPsicoID = new SelectList(db.ExPsicoes, "ExPsicoID", "Description", examen.ExPsicoID);
            ViewBag.OtherExamID = new SelectList(db.OtherExams, "OtherExamID", "Description", examen.OtherExamID);
            ViewBag.PacientID = new SelectList(db.Pacients, "PacientID", "Document", examen.PacientID);
            return View(examen);
        }

        // GET: Examen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examen examen = db.Examen.Find(id);
            if (examen == null)
            {
                return HttpNotFound();
            }
            ViewBag.EnterpriseID = new SelectList(db.Enterprises, "EnterpriseID", "Document", examen.EnterpriseID);
            ViewBag.ExActivoID = new SelectList(db.ExActivoes, "ExActivoID", "Description", examen.ExActivoID);
            ViewBag.ExamenLevelID = new SelectList(db.ExamenLevels, "ExamenLevelID", "Description", examen.ExamenLevelID);
            ViewBag.ExamenTypeID = new SelectList(db.ExamenTypes, "ExamenTypeID", "Description", examen.ExamenTypeID);
            ViewBag.ExFonoID = new SelectList(db.ExFonoes, "ExFonoID", "Description", examen.ExFonoID);
            ViewBag.ExMedicoID = new SelectList(db.ExMedicoes, "ExMedicoID", "Description", examen.ExMedicoID);
            ViewBag.ExOptoID = new SelectList(db.ExOptoes, "ExOptoID", "Description", examen.ExOptoID);
            ViewBag.ExPsicoID = new SelectList(db.ExPsicoes, "ExPsicoID", "Description", examen.ExPsicoID);
            ViewBag.OtherExamID = new SelectList(db.OtherExams, "OtherExamID", "Description", examen.OtherExamID);
            ViewBag.PacientID = new SelectList(db.Pacients, "PacientID", "Document", examen.PacientID);
            return View(examen);
        }

        // POST: Examen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExamenID,Date,Time,ExamenTypeID,ExamenLevelID,OtherExamID,PacientID,EnterpriseID,ExOptoID,ExFonoID,ExPsicoID,ExMedicoID,ExActivoID")] Examen examen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(examen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EnterpriseID = new SelectList(db.Enterprises, "EnterpriseID", "Document", examen.EnterpriseID);
            ViewBag.ExActivoID = new SelectList(db.ExActivoes, "ExActivoID", "Description", examen.ExActivoID);
            ViewBag.ExamenLevelID = new SelectList(db.ExamenLevels, "ExamenLevelID", "Description", examen.ExamenLevelID);
            ViewBag.ExamenTypeID = new SelectList(db.ExamenTypes, "ExamenTypeID", "Description", examen.ExamenTypeID);
            ViewBag.ExFonoID = new SelectList(db.ExFonoes, "ExFonoID", "Description", examen.ExFonoID);
            ViewBag.ExMedicoID = new SelectList(db.ExMedicoes, "ExMedicoID", "Description", examen.ExMedicoID);
            ViewBag.ExOptoID = new SelectList(db.ExOptoes, "ExOptoID", "Description", examen.ExOptoID);
            ViewBag.ExPsicoID = new SelectList(db.ExPsicoes, "ExPsicoID", "Description", examen.ExPsicoID);
            ViewBag.OtherExamID = new SelectList(db.OtherExams, "OtherExamID", "Description", examen.OtherExamID);
            ViewBag.PacientID = new SelectList(db.Pacients, "PacientID", "Document", examen.PacientID);
            return View(examen);
        }

        // GET: Examen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examen examen = db.Examen.Find(id);
            if (examen == null)
            {
                return HttpNotFound();
            }
            return View(examen);
        }

        // POST: Examen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Examen examen = db.Examen.Find(id);
            db.Examen.Remove(examen);
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
