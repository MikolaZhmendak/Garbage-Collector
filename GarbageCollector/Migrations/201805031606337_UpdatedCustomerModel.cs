namespace GarbageCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedCustomerModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Password", c => c.String());
            DropColumn("dbo.Customers", "DateOfBirth");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "DateOfBirth", c => c.Int(nullable: false));
            DropColumn("dbo.Customers", "Password");
        }
    }
}
