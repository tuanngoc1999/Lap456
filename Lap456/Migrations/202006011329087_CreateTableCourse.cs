namespace Lap456.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableCourse : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categlories",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LectureId = c.String(nullable: false, maxLength: 128),
                        Place = c.String(nullable: false, maxLength: 250),
                        DateTime = c.DateTime(nullable: false),
                        CategloryId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categlories", t => t.CategloryId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.LectureId, cascadeDelete: true)
                .Index(t => t.LectureId)
                .Index(t => t.CategloryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "LectureId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Courses", "CategloryId", "dbo.Categlories");
            DropIndex("dbo.Courses", new[] { "CategloryId" });
            DropIndex("dbo.Courses", new[] { "LectureId" });
            DropTable("dbo.Courses");
            DropTable("dbo.Categlories");
        }
    }
}
