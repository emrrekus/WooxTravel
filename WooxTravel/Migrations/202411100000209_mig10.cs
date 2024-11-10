namespace WooxTravel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "ResarvationPrice", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reservations", "ResarvationPrice");
        }
    }
}
