namespace Project_X_2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlacePictures : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlacePictures",
                c => new
                    {
                        PlacePictureId = c.Int(nullable: false, identity: true),
                        PlaceId = c.Int(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        Contents = c.String(),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.PlacePictureId)
                .ForeignKey("dbo.Places", t => t.PlaceId, cascadeDelete: true)
                .Index(t => t.PlaceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlacePictures", "PlaceId", "dbo.Places");
            DropIndex("dbo.PlacePictures", new[] { "PlaceId" });
            DropTable("dbo.PlacePictures");
        }
    }
}
