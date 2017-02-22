using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ElderSourceApp.Models
{
    public class CompanyCriteriaDictionary
    {

        [Key]
        [Column (Order = 1)]
        public int dCompanyId { get; set; }
        public virtual CompanyModel CompanyModel { get; set; }
        [Key]
        [Column(Order = 2)]
        public int dCriteriaId { get; set; }
        public virtual CriteriaModel CriteriaModel { get; set; }

    }
}