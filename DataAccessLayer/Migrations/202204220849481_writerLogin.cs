namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class writerLogin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "PasswordSalt", c => c.Binary());
            AddColumn("dbo.Writers", "PasswordHash", c => c.Binary());
            DropColumn("dbo.Writers", "WriterPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Writers", "WriterPassword", c => c.String(maxLength: 200));
            DropColumn("dbo.Writers", "PasswordHash");
            DropColumn("dbo.Writers", "PasswordSalt");
        }
    }
}
