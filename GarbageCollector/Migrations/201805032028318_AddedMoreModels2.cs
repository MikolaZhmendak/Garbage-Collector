namespace GarbageCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMoreModels2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerPhoneNumbers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AreaCode = c.Int(nullable: false),
                        PhoneNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmployeeAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PrimaryEmployeeAddress = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmployeePhoneNumbers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhoneNumer = c.Int(nullable: false),
                        AreaCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FinishedPickups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        FinishedDates = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PickupDates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Month = c.Int(nullable: false),
                        DateOfWeek = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PickupDates");
            DropTable("dbo.FinishedPickups");
            DropTable("dbo.EmployeePhoneNumbers");
            DropTable("dbo.EmployeeAddresses");
            DropTable("dbo.Employees");
            DropTable("dbo.CustomerPhoneNumbers");
        }
    }
}
