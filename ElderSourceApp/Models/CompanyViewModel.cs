using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ElderSourceApp.Models;

namespace ElderSourceApp.Models
{

    

    public class CompanyViewModel
    {

        public CompanyModel CompanyModel { get; set; }
        public CriteriaModel CriteriaModel { get; set; }

        public int CompanyModelID { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public String State { get; set; }
        public String ZipCode { get; set; }
        public String CompanyType { get; set; }
        public String Phone { get; set; }
        public DateTime lastPaidDate { get; set; }
        public String Description { get; set; }
        public virtual IList<CriteriaModel> criteriaList { get; set; }
    }
}