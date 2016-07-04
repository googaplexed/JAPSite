namespace JAPhotography.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImageModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        photoName = c.String(),
                        photoCaption = c.String(),
                        thumbnail = c.Binary(),
                        image = c.Binary(),
                        client = c.String(),
                        type = c.String(),
                        width = c.Int(nullable: false),
                        height = c.Int(nullable: false),
                        size = c.Int(nullable: false),
                        dateAdded = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ImageModels");
        }
    }
}
