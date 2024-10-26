namespace WooxTravel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Destinations", "OtherCityUrl", c => c.String());
            AddColumn("dbo.Destinations", "OtherCityUrl1", c => c.String());
            AddColumn("dbo.Destinations", "OtherCityUrl2", c => c.String());
            AddColumn("dbo.Destinations", "OtherCityUrl3", c => c.String());
            AddColumn("dbo.Destinations", "OtherCityUrl4", c => c.String());
            AddColumn("dbo.Destinations", "OtherCityUrl5", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Destinations", "OtherCityUrl5");
            DropColumn("dbo.Destinations", "OtherCityUrl4");
            DropColumn("dbo.Destinations", "OtherCityUrl3");
            DropColumn("dbo.Destinations", "OtherCityUrl2");
            DropColumn("dbo.Destinations", "OtherCityUrl1");
            DropColumn("dbo.Destinations", "OtherCityUrl");
        }
    }
}
