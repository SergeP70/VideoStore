namespace VideoStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMobileToApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Mobile", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Mobile");
        }
    }
}
