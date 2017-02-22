using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ElderSourceApp.Models
{
    public class CriteriaModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int CriteriaId { get; set; }
        public string CriteriaName { get; set; }
        public Boolean isActivated { get; set; }


    }
}