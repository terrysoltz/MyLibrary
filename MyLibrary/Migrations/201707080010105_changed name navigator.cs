namespace MyLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changednamenavigator : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Loans", name: "Borrower_Id", newName: "ApplicationUser_Id");
            RenameIndex(table: "dbo.Loans", name: "IX_Borrower_Id", newName: "IX_ApplicationUser_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Loans", name: "IX_ApplicationUser_Id", newName: "IX_Borrower_Id");
            RenameColumn(table: "dbo.Loans", name: "ApplicationUser_Id", newName: "Borrower_Id");
        }
    }
}
