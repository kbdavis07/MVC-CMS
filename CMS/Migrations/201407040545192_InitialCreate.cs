namespace CMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PageItems",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        MetaTitle = c.String(nullable: false),
                        Title = c.String(nullable: false),
                        Content = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Keywords = c.String(nullable: false),
                        PageName = c.String(nullable: false),
                        Live = c.Boolean(nullable: false),
                        Author = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        LastUpdate = c.DateTime(nullable: false),
                        ControllerName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PageItems");
        }
    }
}
