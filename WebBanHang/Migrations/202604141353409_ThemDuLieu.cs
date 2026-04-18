namespace WebBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThemDuLieu : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Image", c => c.String());
            DropColumn("dbo.Products", "Images");

        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Images", c => c.String());
            DropColumn("dbo.Products", "Image");
        }
    }
}
