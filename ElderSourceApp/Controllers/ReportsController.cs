using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ElderSourceApp.Models;

namespace ElderSourceApp.Controllers
{
    public class ReportsController : Controller
    {
        private CompanyContext db = new CompanyContext();

        // GET: Reports
        public ActionResult Index()
        {
            var report = db.Report.Include(r => r.CompanyModel);
            return View(report.ToList());
        }

        // GET: Reports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportModel reportModel = db.Report.Find(id);
            if (reportModel == null)
            {
                return HttpNotFound();
            }
            return View(reportModel);
        }

        // GET: Reports/Create
        public ActionResult Create()
        {
            ViewBag.CompanyModelID = new SelectList(db.Company, "CompanyModelID", "CompanyName");
            return View();
        }

        // POST: Reports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReportId,reportName,dateCreated,lastDatePaid,CompanyModelID")] ReportModel reportModel)
        {
            if (ModelState.IsValid)
            {
                db.Report.Add(reportModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyModelID = new SelectList(db.Company, "CompanyModelID", "CompanyName", reportModel.CompanyModelID);
            return View(reportModel);
        }

        // GET: Reports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportModel reportModel = db.Report.Find(id);
            if (reportModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyModelID = new SelectList(db.Company, "CompanyModelID", "CompanyName", reportModel.CompanyModelID);
            return View(reportModel);
        }

        // POST: Reports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReportId,reportName,dateCreated,lastDatePaid,CompanyModelID")] ReportModel reportModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reportModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyModelID = new SelectList(db.Company, "CompanyModelID", "CompanyName", reportModel.CompanyModelID);
            return View(reportModel);
        }

        // GET: Reports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportModel reportModel = db.Report.Find(id);
            if (reportModel == null)
            {
                return HttpNotFound();
            }
            return View(reportModel);
        }

        // POST: Reports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReportModel reportModel = db.Report.Find(id);
            db.Report.Remove(reportModel);
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
