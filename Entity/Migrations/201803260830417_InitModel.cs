namespace Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookDetailInfoes",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        PlaceOfPublication = c.String(),
                        CopyrightDescription = c.String(),
                        ISBN = c.Int(),
                        Price = c.Decimal(precision: 18, scale: 2),
                        Folio = c.Int(),
                        Sheet = c.Int(),
                        Impression = c.Int(),
                        Revision = c.Int(),
                        PrintingCompany = c.Int(),
                    })
                .PrimaryKey(t => t.BookId);
            
            CreateTable(
                "dbo.BookInfoes",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        BookName = c.String(),
                        AuthorName = c.String(),
                        BookTypeId = c.String(),
                    })
                .PrimaryKey(t => t.BookId);
            
            CreateTable(
                "dbo.BorrowInfoes",
                c => new
                    {
                        BorrowId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(),
                        BookId = c.Int(),
                        BorrowTime = c.DateTime(),
                        ReturnTime = c.DateTime(),
                        State = c.Int(),
                    })
                .PrimaryKey(t => t.BorrowId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        UserAccount = c.String(nullable: false, maxLength: 128),
                        PassWord = c.String(),
                        UserName = c.String(),
                        UserSex = c.Int(),
                        StartTime = c.DateTime(),
                        EndTime = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.UserId, t.UserAccount });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.BorrowInfoes");
            DropTable("dbo.BookInfoes");
            DropTable("dbo.BookDetailInfoes");
        }
    }
}
