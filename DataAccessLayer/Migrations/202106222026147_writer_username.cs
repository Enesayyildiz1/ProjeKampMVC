namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class writer_username : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "WriterUsername", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Writers", "WriterUsername");
        }
    }
}
