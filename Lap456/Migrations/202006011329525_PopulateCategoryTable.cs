namespace Lap456.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCategoryTable : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into CATEGLORIES (ID, NAME) Values (1, 'DEV')");
            Sql("Insert into CATEGLORIES (ID, NAME) Values (2, 'Business')");
            Sql("Insert into CATEGLORIES (ID, NAME) Values (3, 'Marketing')");
        }
        
        public override void Down()
        {
        }
    }
}
