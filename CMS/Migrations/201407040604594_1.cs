namespace CMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PageItems", "DateCreated", c => c.String());
            AlterColumn("dbo.PageItems", "LastUpdate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PageItems", "LastUpdate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PageItems", "DateCreated", c => c.DateTime(nullable: false));
        }
    }
}
