namespace Bootcamp.CRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class checkingerror : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.TransactionItems", name: "Transactions_Id", newName: "Transaction_Id");
            RenameIndex(table: "dbo.TransactionItems", name: "IX_Transactions_Id", newName: "IX_Transaction_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.TransactionItems", name: "IX_Transaction_Id", newName: "IX_Transactions_Id");
            RenameColumn(table: "dbo.TransactionItems", name: "Transaction_Id", newName: "Transactions_Id");
        }
    }
}
