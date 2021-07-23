namespace _19DTHA_A_DO_AN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNameIdentity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}
