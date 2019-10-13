namespace OnlineExamMvcApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class exam7778f : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TestXQuestions", "QuestionId", "dbo.Questions");
            DropIndex("dbo.TestXQuestions", new[] { "QuestionId" });
            RenameColumn(table: "dbo.TestXQuestions", name: "QuestionId", newName: "Question_QuestionId");
            AlterColumn("dbo.TestXQuestions", "Question_QuestionId", c => c.Int());
            CreateIndex("dbo.TestXQuestions", "Question_QuestionId");
            AddForeignKey("dbo.TestXQuestions", "Question_QuestionId", "dbo.Questions", "QuestionId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestXQuestions", "Question_QuestionId", "dbo.Questions");
            DropIndex("dbo.TestXQuestions", new[] { "Question_QuestionId" });
            AlterColumn("dbo.TestXQuestions", "Question_QuestionId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.TestXQuestions", name: "Question_QuestionId", newName: "QuestionId");
            CreateIndex("dbo.TestXQuestions", "QuestionId");
            AddForeignKey("dbo.TestXQuestions", "QuestionId", "dbo.Questions", "QuestionId", cascadeDelete: true);
        }
    }
}
