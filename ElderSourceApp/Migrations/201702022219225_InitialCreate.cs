namespace ElderSourceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompanyModel",
                c => new
                    {
                        CompanyModelID = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                        CompanyType = c.String(),
                        Phone = c.String(),
                        Description = c.String()
                    })
                .PrimaryKey(t => t.CompanyModelID);

            CreateTable(
              "dbo.ReportModel",
              c => new
              {
                  ReportId = c.Int(nullable: false, identity: true),
                  reportName = c.String(),
                  dateCreated = c.DateTime(),
                  lastdatePaid = c.DateTime(),
                  CompanyModelID = c.Int(nullable: false)

              })
              .ForeignKey("CompanyModel",t => t.CompanyModelID)
              .PrimaryKey(t => t.ReportId)
              ;
              

            CreateTable(
              "dbo.CriteriaModel",
              c => new
              {
                 CriteriaId= c.Int(nullable: false, identity: true),
                 HasSymbol = c.Boolean(),
                 EmployeesTrained= c.Boolean(),
                  HasPolicies = c.Boolean(),
                  HasDeclaration = c.Boolean(),
                  CompanyModelID = c.Int(nullable: false)
              })
              .ForeignKey("CompanyModel", t => t.CompanyModelID)
              .PrimaryKey(t => t.CriteriaId);

         
        }
        
        public override void Down()
        {
            DropTable("dbo.CompanyModel");
        }
    }
}
