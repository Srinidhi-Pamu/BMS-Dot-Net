namespace BMSwebapi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes22 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        AccountNumber = c.Long(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        LastName = c.String(nullable: false, maxLength: 30),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        ConfirmPassword = c.String(nullable: false),
                        Phone = c.String(),
                        Address = c.String(maxLength: 35),
                        Balance = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.PassBook",
                c => new
                    {
                        id1 = c.Int(nullable: false, identity: true),
                        AccountNumber = c.Long(nullable: false),
                        Amount = c.Double(nullable: false),
                        TimeofTransaction = c.DateTime(nullable: false),
                        Mode = c.String(),
                    })
                .PrimaryKey(t => t.id1);
            
            CreateTable(
                "dbo.TransactionDetail",
                c => new
                    {
                        id1 = c.Int(nullable: false, identity: true),
                        AccountNumber = c.Long(nullable: false),
                        Amount = c.Double(nullable: false),
                        TimeofTransaction = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id1);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TransactionDetail");
            DropTable("dbo.PassBook");
            DropTable("dbo.Account");
        }
    }
}
