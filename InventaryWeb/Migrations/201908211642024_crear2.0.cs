namespace InventaryWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class crear20 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EntryDetails", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.ExitDetails", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.EntryDetails", "EntryNote_Id", "dbo.EntryNotes");
            DropForeignKey("dbo.ExitDetails", "ExitNote_Id", "dbo.ExitNotes");
            DropIndex("dbo.EntryDetails", new[] { "Product_Id" });
            DropIndex("dbo.EntryDetails", new[] { "EntryNote_Id" });
            DropIndex("dbo.ExitDetails", new[] { "Product_Id" });
            DropIndex("dbo.ExitDetails", new[] { "ExitNote_Id" });
            RenameColumn(table: "dbo.EntryDetails", name: "Product_Id", newName: "ProductID");
            RenameColumn(table: "dbo.ExitDetails", name: "Product_Id", newName: "ProductID");
            RenameColumn(table: "dbo.EntryDetails", name: "EntryNote_Id", newName: "EntryNoteID");
            RenameColumn(table: "dbo.ExitDetails", name: "ExitNote_Id", newName: "ExitNoteID");
            AlterColumn("dbo.EntryDetails", "ProductID", c => c.Int(nullable: false));
            AlterColumn("dbo.EntryDetails", "EntryNoteID", c => c.Int(nullable: false));
            AlterColumn("dbo.ExitDetails", "ProductID", c => c.Int(nullable: false));
            AlterColumn("dbo.ExitDetails", "ExitNoteID", c => c.Int(nullable: false));
            CreateIndex("dbo.EntryDetails", "ProductID");
            CreateIndex("dbo.EntryDetails", "EntryNoteID");
            CreateIndex("dbo.ExitDetails", "ProductID");
            CreateIndex("dbo.ExitDetails", "ExitNoteID");
            AddForeignKey("dbo.EntryDetails", "ProductID", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ExitDetails", "ProductID", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.EntryDetails", "EntryNoteID", "dbo.EntryNotes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ExitDetails", "ExitNoteID", "dbo.ExitNotes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExitDetails", "ExitNoteID", "dbo.ExitNotes");
            DropForeignKey("dbo.EntryDetails", "EntryNoteID", "dbo.EntryNotes");
            DropForeignKey("dbo.ExitDetails", "ProductID", "dbo.Products");
            DropForeignKey("dbo.EntryDetails", "ProductID", "dbo.Products");
            DropIndex("dbo.ExitDetails", new[] { "ExitNoteID" });
            DropIndex("dbo.ExitDetails", new[] { "ProductID" });
            DropIndex("dbo.EntryDetails", new[] { "EntryNoteID" });
            DropIndex("dbo.EntryDetails", new[] { "ProductID" });
            AlterColumn("dbo.ExitDetails", "ExitNoteID", c => c.Int());
            AlterColumn("dbo.ExitDetails", "ProductID", c => c.Int());
            AlterColumn("dbo.EntryDetails", "EntryNoteID", c => c.Int());
            AlterColumn("dbo.EntryDetails", "ProductID", c => c.Int());
            RenameColumn(table: "dbo.ExitDetails", name: "ExitNoteID", newName: "ExitNote_Id");
            RenameColumn(table: "dbo.EntryDetails", name: "EntryNoteID", newName: "EntryNote_Id");
            RenameColumn(table: "dbo.ExitDetails", name: "ProductID", newName: "Product_Id");
            RenameColumn(table: "dbo.EntryDetails", name: "ProductID", newName: "Product_Id");
            CreateIndex("dbo.ExitDetails", "ExitNote_Id");
            CreateIndex("dbo.ExitDetails", "Product_Id");
            CreateIndex("dbo.EntryDetails", "EntryNote_Id");
            CreateIndex("dbo.EntryDetails", "Product_Id");
            AddForeignKey("dbo.ExitDetails", "ExitNote_Id", "dbo.ExitNotes", "Id");
            AddForeignKey("dbo.EntryDetails", "EntryNote_Id", "dbo.EntryNotes", "Id");
            AddForeignKey("dbo.ExitDetails", "Product_Id", "dbo.Products", "Id");
            AddForeignKey("dbo.EntryDetails", "Product_Id", "dbo.Products", "Id");
        }
    }
}
