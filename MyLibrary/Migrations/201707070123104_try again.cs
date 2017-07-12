namespace MyLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tryagain : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookAuthors",
                c => new
                    {
                        BookAuthorID = c.Int(nullable: false, identity: true),
                        BookID = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.BookAuthorID)
                .ForeignKey("dbo.Books", t => t.BookID, cascadeDelete: true)
                .Index(t => t.BookID);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        PublisherName = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.BookID)
                .ForeignKey("dbo.Publishers", t => t.PublisherName)
                .Index(t => t.PublisherName);
            
            CreateTable(
                "dbo.Publishers",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        Address = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        BranchID = c.Int(nullable: false, identity: true),
                        BranchName = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.BranchID);
            
            CreateTable(
                "dbo.Copies",
                c => new
                    {
                        CopiesID = c.Int(nullable: false, identity: true),
                        BookID = c.Int(nullable: false),
                        BranchID = c.Int(nullable: false),
                        NoCopies = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CopiesID)
                .ForeignKey("dbo.Books", t => t.BookID, cascadeDelete: true)
                .ForeignKey("dbo.Branches", t => t.BranchID, cascadeDelete: true)
                .Index(t => t.BookID)
                .Index(t => t.BranchID);
            
            CreateTable(
                "dbo.Loans",
                c => new
                    {
                        LoanID = c.Int(nullable: false, identity: true),
                        BookID = c.Int(nullable: false),
                        BranchID = c.Int(nullable: false),
                        ApplicationUserID = c.Int(nullable: false),
                        DateOut = c.DateTime(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        Borrower_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.LoanID)
                .ForeignKey("dbo.Books", t => t.BookID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.Borrower_Id)
                .ForeignKey("dbo.Branches", t => t.BranchID, cascadeDelete: true)
                .Index(t => t.BookID)
                .Index(t => t.BranchID)
                .Index(t => t.Borrower_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Loans", "BranchID", "dbo.Branches");
            DropForeignKey("dbo.Loans", "Borrower_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Loans", "BookID", "dbo.Books");
            DropForeignKey("dbo.Copies", "BranchID", "dbo.Branches");
            DropForeignKey("dbo.Copies", "BookID", "dbo.Books");
            DropForeignKey("dbo.BookAuthors", "BookID", "dbo.Books");
            DropForeignKey("dbo.Books", "PublisherName", "dbo.Publishers");
            DropIndex("dbo.Loans", new[] { "Borrower_Id" });
            DropIndex("dbo.Loans", new[] { "BranchID" });
            DropIndex("dbo.Loans", new[] { "BookID" });
            DropIndex("dbo.Copies", new[] { "BranchID" });
            DropIndex("dbo.Copies", new[] { "BookID" });
            DropIndex("dbo.Books", new[] { "PublisherName" });
            DropIndex("dbo.BookAuthors", new[] { "BookID" });
            DropTable("dbo.Loans");
            DropTable("dbo.Copies");
            DropTable("dbo.Branches");
            DropTable("dbo.Publishers");
            DropTable("dbo.Books");
            DropTable("dbo.BookAuthors");
        }
    }
}
