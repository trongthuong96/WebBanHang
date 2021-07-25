namespace _19DTHA_A_DO_AN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnImageOfShopCart : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShopCarts", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ShopCarts", "Image");
        }
    }
}
