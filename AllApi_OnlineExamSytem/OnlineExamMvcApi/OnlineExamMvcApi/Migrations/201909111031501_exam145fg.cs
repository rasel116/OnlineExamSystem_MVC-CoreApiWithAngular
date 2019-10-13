namespace OnlineExamMvcApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class exam145fg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TestXQuestions", "UniqueQuestionID", c => c.Int(nullable: false));
            AddColumn("dbo.TestXQuestions", "UniqueTestID", c => c.Int(nullable: false));
            DropColumn("dbo.TestXQuestions", "QuestionNumber");
            DropColumn("dbo.TestXQuestions", "UniqueID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TestXQuestions", "UniqueID", c => c.Int(nullable: false));
            AddColumn("dbo.TestXQuestions", "QuestionNumber", c => c.Int(nullable: false));
            DropColumn("dbo.TestXQuestions", "UniqueTestID");
            DropColumn("dbo.TestXQuestions", "UniqueQuestionID");
        }
    }
}
