namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "WriterAbout", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Writers", "WriterAbout");
        }
    }
}
