namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class confirmpassword : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "ConfirmPassword", c => c.String());
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Password", c => c.String());
            DropColumn("dbo.Users", "ConfirmPassword");
        }
    }
}
