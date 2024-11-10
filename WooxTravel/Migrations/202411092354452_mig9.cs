namespace WooxTravel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "Surname", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reservations", "Surname");
        }
    }
}
