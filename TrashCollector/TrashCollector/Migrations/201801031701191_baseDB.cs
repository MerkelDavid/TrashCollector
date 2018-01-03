namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class baseDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adresses",
                c => new
                    {
                        AdressID = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AdressID);
            
            CreateTable(
                "dbo.Charges",
                c => new
                    {
                        ChargeID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        DateBilled = c.DateTime(nullable: false),
                        Paid = c.Boolean(nullable: false),
                        Amount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ChargeID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Password = c.String(),
                        FrequencyID = c.Int(nullable: false),
                        AddressID = c.Int(nullable: false),
                        PaymentID = c.Int(nullable: false),
                        ChargesID = c.Int(nullable: false),
                        Adress_AdressID = c.Int(),
                        Charges_ChargeID = c.Int(),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.Adresses", t => t.Adress_AdressID)
                .ForeignKey("dbo.Charges", t => t.Charges_ChargeID)
                .ForeignKey("dbo.Frequencies", t => t.FrequencyID, cascadeDelete: true)
                .ForeignKey("dbo.Payments", t => t.PaymentID, cascadeDelete: true)
                .Index(t => t.FrequencyID)
                .Index(t => t.PaymentID)
                .Index(t => t.Adress_AdressID)
                .Index(t => t.Charges_ChargeID);
            
            CreateTable(
                "dbo.Frequencies",
                c => new
                    {
                        FrequencyID = c.Int(nullable: false, identity: true),
                        frequency = c.String(),
                    })
                .PrimaryKey(t => t.FrequencyID);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentID = c.Int(nullable: false, identity: true),
                        CardNumber = c.Int(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                        SecurityCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Customers", "PaymentID", "dbo.Payments");
            DropForeignKey("dbo.Customers", "FrequencyID", "dbo.Frequencies");
            DropForeignKey("dbo.Customers", "Charges_ChargeID", "dbo.Charges");
            DropForeignKey("dbo.Customers", "Adress_AdressID", "dbo.Adresses");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Customers", new[] { "Charges_ChargeID" });
            DropIndex("dbo.Customers", new[] { "Adress_AdressID" });
            DropIndex("dbo.Customers", new[] { "PaymentID" });
            DropIndex("dbo.Customers", new[] { "FrequencyID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Payments");
            DropTable("dbo.Frequencies");
            DropTable("dbo.Customers");
            DropTable("dbo.Charges");
            DropTable("dbo.Adresses");
        }
    }
}
