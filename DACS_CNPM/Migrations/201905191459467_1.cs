namespace DACS_CNPM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Quan_Tri", "MatKhau", c => c.String(nullable: false, maxLength: 100, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Quan_Tri", "MatKhau", c => c.String(maxLength: 100, unicode: false));
        }
    }
}
