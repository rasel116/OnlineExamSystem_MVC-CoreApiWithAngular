namespace OnlineExamMvcApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Wer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Participants",
                c => new
                    {
                        ParticipantID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Score = c.Int(),
                        TimeSpent = c.Int(),
                    })
                .PrimaryKey(t => t.ParticipantID);
            
            CreateTable(
                "dbo.QuizQuestions",
                c => new
                    {
                        QuizQuestionID = c.Int(nullable: false, identity: true),
                        SubjectID = c.Int(),
                        QuestionCategoryId = c.Int(),
                        ExhibitId = c.Int(),
                        Qn = c.String(),
                        Option1 = c.String(),
                        Option2 = c.String(),
                        Option3 = c.String(),
                        Option4 = c.String(),
                        Answer = c.Int(),
                    })
                .PrimaryKey(t => t.QuizQuestionID)
                .ForeignKey("dbo.Exhibits", t => t.ExhibitId)
                .ForeignKey("dbo.QuestionCategories", t => t.QuestionCategoryId)
                .ForeignKey("dbo.Subjects", t => t.SubjectID)
                .Index(t => t.SubjectID)
                .Index(t => t.QuestionCategoryId)
                .Index(t => t.ExhibitId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuizQuestions", "SubjectID", "dbo.Subjects");
            DropForeignKey("dbo.QuizQuestions", "QuestionCategoryId", "dbo.QuestionCategories");
            DropForeignKey("dbo.QuizQuestions", "ExhibitId", "dbo.Exhibits");
            DropIndex("dbo.QuizQuestions", new[] { "ExhibitId" });
            DropIndex("dbo.QuizQuestions", new[] { "QuestionCategoryId" });
            DropIndex("dbo.QuizQuestions", new[] { "SubjectID" });
            DropTable("dbo.QuizQuestions");
            DropTable("dbo.Participants");
        }
    }
}
