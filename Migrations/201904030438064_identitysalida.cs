namespace NominaTarea.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class identitysalida : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Salida");
            AlterColumn("dbo.Salida", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Salida", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Salida");
            AlterColumn("dbo.Salida", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Salida", "Id");
        }
    }
}
