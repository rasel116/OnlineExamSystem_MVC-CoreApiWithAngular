namespace OnlineExamMvcApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class exam145f : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TestXQuestions", "Label", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TestXQuestions", "Label");
        }
    }
}
