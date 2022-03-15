namespace LoginAuthorize.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false, maxLength: 80),
                        username = c.String(nullable: false, maxLength: 30),
                        password = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.usuarios");
        }
    }
}
