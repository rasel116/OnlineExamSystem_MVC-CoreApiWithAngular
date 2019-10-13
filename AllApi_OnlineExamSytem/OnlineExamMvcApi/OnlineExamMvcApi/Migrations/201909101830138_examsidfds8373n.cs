namespace OnlineExamMvcApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class examsidfds8373n : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "QuestionUniqueID", c => c.Int(nullable: false));
            AddColumn("dbo.Questions", "TestUniqueID", c => c.Int(nullable: false));
            DropColumn("dbo.Questions", "UniqueID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "UniqueID", c => c.Int(nullable: false));
            DropColumn("dbo.Questions", "TestUniqueID");
            DropColumn("dbo.Questions", "QuestionUniqueID");
        }
    }
}
