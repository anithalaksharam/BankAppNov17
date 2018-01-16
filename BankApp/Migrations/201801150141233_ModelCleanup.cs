namespace BankApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelCleanup : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Accounts", "EmailAddress", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Accounts", "EmailAddress", c => c.String(maxLength: 100));
        }
    }
}
