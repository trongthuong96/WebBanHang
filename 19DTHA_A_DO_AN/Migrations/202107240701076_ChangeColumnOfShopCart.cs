namespace _19DTHA_A_DO_AN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeColumnOfShopCart : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ShopCarts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ShopCarts", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.ShopCarts", new[] { "UserId" });
            DropIndex("dbo.ShopCarts", new[] { "ProductId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.ShopCarts", "ProductId");
            CreateIndex("dbo.ShopCarts", "UserId");
            AddForeignKey("dbo.ShopCarts", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ShopCarts", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
