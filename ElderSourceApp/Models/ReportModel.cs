using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ElderSourceApp.Models
{
    public class ReportModel
    {

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ReportId { get; set; }
         public string reportName { get; set; }
         public DateTime dateCreated { get; set; }
         public DateTime lastDatePaid { get; set; }
        [ForeignKey("CompanyModel")]
         public int CompanyModelID { get; set; }
         public virtual CompanyModel CompanyModel { get; set; }
    }
}