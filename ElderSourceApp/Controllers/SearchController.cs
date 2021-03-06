﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElderSourceApp.Models;

namespace ElderSourceApp.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        CompanyContext _db = new CompanyContext();
        public ActionResult Index(string companyName = null, string companyType = null, string city = null, string zipCode = null)
        {
            var model =
               _db.Company
               .OrderByDescending(r => r.CompanyName)
               .Where(r => companyName == null || r.CompanyName.StartsWith(companyName))
               .Where(r => companyType == null || r.CompanyType.StartsWith(companyType))
               .Where(r => city == null || r.City.StartsWith(city))
               .Where(r => zipCode == null || r.ZipCode.StartsWith(zipCode))
               .Select(r => new CompanyViewModel 
               {
                   CompanyModelID = r.CompanyModelID,
                   CompanyName = r.CompanyName,
                   City = r.City,
                   State = r.State,
                   ZipCode = r.ZipCode,
                   CompanyType = r.CompanyType,
                   Phone = r.Phone
               });

            return View(model);
        }
    }
}

