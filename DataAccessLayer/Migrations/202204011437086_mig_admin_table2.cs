namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_admin_table2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "AdminFirstName", c => c.String(maxLength: 50));
            AddColumn("dbo.Admins", "AdminLastName", c => c.String(maxLength: 50));
            AddColumn("dbo.Admins", "Email", c => c.String(maxLength: 50));
            AddColumn("dbo.Admins", "PasswordSalt", c => c.Binary());
            AddColumn("dbo.Admins", "PasswordHash", c => c.Binary());
            DropColumn("dbo.Admins", "AdminUserName");
            DropColumn("dbo.Admins", "AdminPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "AdminPassword", c => c.String(maxLength: 50));
            AddColumn("dbo.Admins", "AdminUserName", c => c.String(maxLength: 50));
            DropColumn("dbo.Admins", "PasswordHash");
            DropColumn("dbo.Admins", "PasswordSalt");
            DropColumn("dbo.Admins", "Email");
            DropColumn("dbo.Admins", "AdminLastName");
            DropColumn("dbo.Admins", "AdminFirstName");
        }
    }
}
