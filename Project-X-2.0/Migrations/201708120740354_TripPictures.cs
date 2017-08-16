namespace Project_X_2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TripPictures : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TripPictures",
                c => new
                    {
                        TripPictureId = c.Int(nullable: false, identity: true),
                        TripId = c.Int(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        Contents = c.String(),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.TripPictureId)
                .ForeignKey("dbo.Trips", t => t.TripId, cascadeDelete: true)
                .Index(t => t.TripId);
            
            AddColumn("dbo.Trips", "TripPictureId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TripPictures", "TripId", "dbo.Trips");
            DropIndex("dbo.TripPictures", new[] { "TripId" });
            DropColumn("dbo.Trips", "TripPictureId");
            DropTable("dbo.TripPictures");
        }
    }
}
