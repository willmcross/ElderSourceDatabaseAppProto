

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ElderSourceApp.Models
{
    public class CompanyContext : DbContext
    {
        public CompanyContext() : base("DefaultConnection")
        {
        }

        public DbSet<CompanyModel> Company { get; set; }
        public DbSet<ReportModel> Report { get; set; }
        public DbSet<CriteriaModel> Criteria { get; set; }
        public DbSet<CompanyCriteriaDictionary> CompanyCriteriaDictionary { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}