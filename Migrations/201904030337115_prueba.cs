namespace NominaTarea.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prueba : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Cargoes", newName: "Cargo");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Cargo", newName: "Cargoes");
        }
    }
}
