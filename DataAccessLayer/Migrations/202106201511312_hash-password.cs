namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hashpassword : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "PasswordSalt", c => c.Binary());
            AddColumn("dbo.Users", "PasswordHash", c => c.Binary());
            DropColumn("dbo.Users", "Password");
            DropColumn("dbo.Users", "ConfirmPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "ConfirmPassword", c => c.String());
            AddColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.Users", "PasswordHash");
            DropColumn("dbo.Users", "PasswordSalt");
        }
    }
}
