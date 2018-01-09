namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class schedule : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        ScheduleID = c.Int(nullable: false, identity: true),
                        Customer = c.String(),
                        Day = c.String(),
                        Frequency = c.String(),
                        VacationMode = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ScheduleID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Schedules");
        }
    }
}
