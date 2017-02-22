using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElderSourceApp.Models
{
    public class ReportViewModel
    {
         [Key]
         public string ReportName { get; set; }
         public DateTime timeCreated { get; set; }
         public DateTime filterStart { get; set; }
         public DateTime filterEnd { get; set; }
         public bool inArrears { get; set; }
         public DateTime LastPaid { get; set; }
    }
}