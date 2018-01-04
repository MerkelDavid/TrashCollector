namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class loginAndRegistration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "UserRoles", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "UserRoles");
        }
    }
}
