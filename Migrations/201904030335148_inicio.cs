namespace NominaTarea.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cargoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Empleadoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Apellido = c.String(nullable: false, maxLength: 50),
                        Codigo = c.String(nullable: false, maxLength: 50),
                        Telefono = c.String(nullable: false, maxLength: 10),
                        FechaIngreso = c.DateTime(nullable: false),
                        Salario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Estado = c.Boolean(nullable: false),
                        IdDpto = c.Int(nullable: false),
                        IdCargo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cargoes", t => t.IdCargo, cascadeDelete: true)
                .ForeignKey("dbo.Departamentoes", t => t.IdDpto, cascadeDelete: true)
                .Index(t => t.IdDpto)
                .Index(t => t.IdCargo);
            
            CreateTable(
                "dbo.Departamentoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 50),
                        Nombre = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Licencias",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        IdEmpleado = c.Int(nullable: false),
                        Desde = c.DateTime(nullable: false),
                        Hasta = c.DateTime(nullable: false),
                        Comentario = c.String(nullable: false, maxLength: 500),
                        Motivo = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empleadoes", t => t.IdEmpleado, cascadeDelete: true)
                .Index(t => t.IdEmpleado);
            
            CreateTable(
                "dbo.Permisos",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        IdEmpleado = c.Int(nullable: false),
                        Desde = c.DateTime(nullable: false),
                        Hasta = c.DateTime(nullable: false),
                        Comentario = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empleadoes", t => t.IdEmpleado, cascadeDelete: true)
                .Index(t => t.IdEmpleado);
            
            CreateTable(
                "dbo.Salidas",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        IdEmpleado = c.Int(nullable: false),
                        FechaSalida = c.DateTime(nullable: false),
                        TipoSalida = c.String(nullable: false),
                        Motivo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empleadoes", t => t.IdEmpleado, cascadeDelete: true)
                .Index(t => t.IdEmpleado);
            
            CreateTable(
                "dbo.Vacaciones",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        IdEmpleado = c.Int(nullable: false),
                        Desde = c.DateTime(nullable: false),
                        Hasta = c.DateTime(nullable: false),
                        Comentario = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empleadoes", t => t.IdEmpleado, cascadeDelete: true)
                .Index(t => t.IdEmpleado);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vacaciones", "IdEmpleado", "dbo.Empleadoes");
            DropForeignKey("dbo.Salidas", "IdEmpleado", "dbo.Empleadoes");
            DropForeignKey("dbo.Permisos", "IdEmpleado", "dbo.Empleadoes");
            DropForeignKey("dbo.Licencias", "IdEmpleado", "dbo.Empleadoes");
            DropForeignKey("dbo.Empleadoes", "IdDpto", "dbo.Departamentoes");
            DropForeignKey("dbo.Empleadoes", "IdCargo", "dbo.Cargoes");
            DropIndex("dbo.Vacaciones", new[] { "IdEmpleado" });
            DropIndex("dbo.Salidas", new[] { "IdEmpleado" });
            DropIndex("dbo.Permisos", new[] { "IdEmpleado" });
            DropIndex("dbo.Licencias", new[] { "IdEmpleado" });
            DropIndex("dbo.Empleadoes", new[] { "IdCargo" });
            DropIndex("dbo.Empleadoes", new[] { "IdDpto" });
            DropTable("dbo.Vacaciones");
            DropTable("dbo.Salidas");
            DropTable("dbo.Permisos");
            DropTable("dbo.Licencias");
            DropTable("dbo.Departamentoes");
            DropTable("dbo.Empleadoes");
            DropTable("dbo.Cargoes");
        }
    }
}
