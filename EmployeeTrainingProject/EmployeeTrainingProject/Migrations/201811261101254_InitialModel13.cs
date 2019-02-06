namespace EmployeeTrainingProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel13 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Name", c => c.String(nullable: false, maxLength: 30));
        }
    }
}
