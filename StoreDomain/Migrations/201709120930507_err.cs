namespace StoreDomain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class err : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Books");
            AlterColumn("dbo.Books", "Id", c => c.Guid(nullable: false, identity: true, defaultValueSql: "NEWID()"));
            AddPrimaryKey("dbo.Books", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Books");
            AlterColumn("dbo.Books", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Books", "Id");
        }
    }
}
