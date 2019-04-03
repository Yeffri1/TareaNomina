namespace NominaTarea.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newfeatures : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Licencias");
            DropPrimaryKey("dbo.Permisos");
            DropPrimaryKey("dbo.Vacaciones");
            AlterColumn("dbo.Licencias", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Permisos", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Vacaciones", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Licencias", "Id");
            AddPrimaryKey("dbo.Permisos", "Id");
            AddPrimaryKey("dbo.Vacaciones", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Vacaciones");
            DropPrimaryKey("dbo.Permisos");
            DropPrimaryKey("dbo.Licencias");
            AlterColumn("dbo.Vacaciones", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Permisos", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Licencias", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Vacaciones", "Id");
            AddPrimaryKey("dbo.Permisos", "Id");
            AddPrimaryKey("dbo.Licencias", "Id");
        }
    }
}
