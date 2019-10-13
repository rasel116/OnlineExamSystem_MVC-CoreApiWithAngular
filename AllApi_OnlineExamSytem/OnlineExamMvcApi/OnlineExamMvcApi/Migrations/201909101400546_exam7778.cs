namespace OnlineExamMvcApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class exam7778 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TestXQuestions", "UniqueID", c => c.Int(nullable: false));
            AddColumn("dbo.Tests", "UniqueID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tests", "UniqueID");
            DropColumn("dbo.TestXQuestions", "UniqueID");
        }
    }
}
