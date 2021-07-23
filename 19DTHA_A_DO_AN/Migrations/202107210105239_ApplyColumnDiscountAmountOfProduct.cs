namespace _19DTHA_A_DO_AN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyColumnDiscountAmountOfProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "DiscountAmount", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "DiscountAmount");
        }
    }
}
