﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ElderSourceApp.Models;
using System.Collections;

namespace ElderSourceApp.Controllers
{
    public class CompanyController : Controller
    {
        private CompanyContext db = new CompanyContext();

        // GET: Company
        public ActionResult Index()
        {
            return View(db.Company.ToList());
        }

        // GET: Company/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyModel compId = db.Company.Find(id);

            var companyModel =
                (from c in db.Company
                 join e in db.Criteria on c.CompanyModelID equals id
                 select new CompanyViewModel
                 {
                     //map data from query to viewmodel
                     CompanyModelID = c.CompanyModelID,
                     CompanyName = c.CompanyName,
                     CompanyType = c.CompanyType,
                     City = c.City,
                     State = c.State,
                     ZipCode = c.ZipCode,
                     Phone = c.Phone,
                     Description = c.Description,
                     lastPaidDate = c.lastPaidDate,
                     criteriaList = c.criteriaList.ToList(),
                 }).SingleOrDefault();


            if (id == null)
            {
                return HttpNotFound();
            }
            return View(companyModel);
        }

        // GET: Company/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Company/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CompanyModel companyModel, CriteriaModel criteriaModel)
        {
            if (ModelState.IsValid)
            {
             

                db.Company.Add(companyModel);
                db.Criteria.Add(criteriaModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(companyModel);
        }

        // GET: Company/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyModel companyModel = db.Company.Find(id);
            if (companyModel == null)
            {
                return HttpNotFound();
            }
            return View(companyModel);
        }

        // POST: Company/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompanyModelID,CompanyName,City,State,ZipCode,CompanyType,Phone,HasSymbol,EmployeesTrained,HasPolicies,HasDeclaration,InArrears")] CompanyModel companyModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companyModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(companyModel);
        }

        // GET: Company/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyModel companyModel = db.Company.Find(id);
            if (companyModel == null)
            {
                return HttpNotFound();
            }
            return View(companyModel);
        }

        // POST: Company/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompanyModel companyModel = db.Company.Find(id);
            db.Company.Remove(companyModel);
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
