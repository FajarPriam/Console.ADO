namespace Bootcamp.CRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingvirtualsupplier : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "Suppliers_Id", c => c.Int());
            CreateIndex("dbo.Items", "Suppliers_Id");
            AddForeignKey("dbo.Items", "Suppliers_Id", "dbo.Suppliers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "Suppliers_Id", "dbo.Suppliers");
            DropIndex("dbo.Items", new[] { "Suppliers_Id" });
            DropColumn("dbo.Items", "Suppliers_Id");
        }
    }
}
