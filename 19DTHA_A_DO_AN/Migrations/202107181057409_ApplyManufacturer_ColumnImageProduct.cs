namespace _19DTHA_A_DO_AN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyManufacturer_ColumnImageProduct : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "Image", c => c.String());
            AddColumn("dbo.Products", "ManufacturerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "ManufacturerId");
            AddForeignKey("dbo.Products", "ManufacturerId", "dbo.Manufacturers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "ManufacturerId", "dbo.Manufacturers");
            DropIndex("dbo.Products", new[] { "ManufacturerId" });
            DropColumn("dbo.Products", "ManufacturerId");
            DropColumn("dbo.Products", "Image");
            DropTable("dbo.Manufacturers");
        }
    }
}
