namespace POS.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Double : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PurchaseReceivings", "PurchaseTotalAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.PurchaseReceivingDetails", "PurchasePrice", c => c.Double(nullable: false));
            AlterColumn("dbo.PurchaseReceivingDetails", "PurchaseItemTotalPrice", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PurchaseReceivingDetails", "PurchaseItemTotalPrice", c => c.Int(nullable: false));
            AlterColumn("dbo.PurchaseReceivingDetails", "PurchasePrice", c => c.Int(nullable: false));
            AlterColumn("dbo.PurchaseReceivings", "PurchaseTotalAmount", c => c.Long(nullable: false));
        }
    }
}
