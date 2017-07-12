namespace MyLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedback : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Loans", name: "ApplicationUser_Id", newName: "Borrower_Id");
            RenameIndex(table: "dbo.Loans", name: "IX_ApplicationUser_Id", newName: "IX_Borrower_Id");
            DropColumn("dbo.Loans", "ApplicationUserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Loans", "ApplicationUserID", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.Loans", name: "IX_Borrower_Id", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Loans", name: "Borrower_Id", newName: "ApplicationUser_Id");
        }
    }
}
