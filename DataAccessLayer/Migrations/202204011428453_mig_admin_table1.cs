namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_admin_table1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "AdminPassword", c => c.String(maxLength: 50));
            DropColumn("dbo.Admins", "AdminMail");
            DropColumn("dbo.Admins", "PasswordHash");
            DropColumn("dbo.Admins", "PasswordSalt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "PasswordSalt", c => c.Binary());
            AddColumn("dbo.Admins", "PasswordHash", c => c.Binary());
            AddColumn("dbo.Admins", "AdminMail", c => c.Binary());
            DropColumn("dbo.Admins", "AdminPassword");
        }
    }
}
