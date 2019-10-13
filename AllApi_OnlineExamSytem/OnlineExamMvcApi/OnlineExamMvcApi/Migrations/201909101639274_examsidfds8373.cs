namespace OnlineExamMvcApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class examsidfds8373 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Choices", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.TestXQuestions", "TestId", "dbo.Tests");
            DropForeignKey("dbo.TestXQuestions", "Question_QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Questions", "ExhibitId", "dbo.Exhibits");
            DropForeignKey("dbo.Questions", "QuestionCategoryId", "dbo.QuestionCategories");
            DropForeignKey("dbo.Questions", "SubjectID", "dbo.Subjects");
            DropIndex("dbo.Choices", new[] { "QuestionId" });
            DropIndex("dbo.Questions", new[] { "SubjectID" });
            DropIndex("dbo.Questions", new[] { "ExhibitId" });
            DropIndex("dbo.Questions", new[] { "QuestionCategoryId" });
            DropIndex("dbo.TestXQuestions", new[] { "TestId" });
            DropIndex("dbo.TestXQuestions", new[] { "Question_QuestionId" });
            RenameColumn(table: "dbo.Questions", name: "ExhibitId", newName: "Exhibit_ExhibitId");
            RenameColumn(table: "dbo.Questions", name: "QuestionCategoryId", newName: "QuestionCategory_QuestionCategoryId");
            RenameColumn(table: "dbo.Questions", name: "SubjectID", newName: "Subject_SubjectID");
            AddColumn("dbo.Choices", "UniqueQuestionID", c => c.Int(nullable: false));
            AddColumn("dbo.Questions", "UniqueID", c => c.Int(nullable: false));
            AlterColumn("dbo.Questions", "Subject_SubjectID", c => c.Int());
            AlterColumn("dbo.Questions", "Exhibit_ExhibitId", c => c.Int());
            AlterColumn("dbo.Questions", "QuestionCategory_QuestionCategoryId", c => c.Int());
            CreateIndex("dbo.Questions", "Exhibit_ExhibitId");
            CreateIndex("dbo.Questions", "QuestionCategory_QuestionCategoryId");
            CreateIndex("dbo.Questions", "Subject_SubjectID");
            AddForeignKey("dbo.Questions", "Exhibit_ExhibitId", "dbo.Exhibits", "ExhibitId");
            AddForeignKey("dbo.Questions", "QuestionCategory_QuestionCategoryId", "dbo.QuestionCategories", "QuestionCategoryId");
            AddForeignKey("dbo.Questions", "Subject_SubjectID", "dbo.Subjects", "SubjectID");
            DropColumn("dbo.Choices", "QuestionId");
            DropColumn("dbo.TestXQuestions", "TestId");
            DropColumn("dbo.TestXQuestions", "Question_QuestionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TestXQuestions", "Question_QuestionId", c => c.Int());
            AddColumn("dbo.TestXQuestions", "TestId", c => c.Int());
            AddColumn("dbo.Choices", "QuestionId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Questions", "Subject_SubjectID", "dbo.Subjects");
            DropForeignKey("dbo.Questions", "QuestionCategory_QuestionCategoryId", "dbo.QuestionCategories");
            DropForeignKey("dbo.Questions", "Exhibit_ExhibitId", "dbo.Exhibits");
            DropIndex("dbo.Questions", new[] { "Subject_SubjectID" });
            DropIndex("dbo.Questions", new[] { "QuestionCategory_QuestionCategoryId" });
            DropIndex("dbo.Questions", new[] { "Exhibit_ExhibitId" });
            AlterColumn("dbo.Questions", "QuestionCategory_QuestionCategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Questions", "Exhibit_ExhibitId", c => c.Int(nullable: false));
            AlterColumn("dbo.Questions", "Subject_SubjectID", c => c.Int(nullable: false));
            DropColumn("dbo.Questions", "UniqueID");
            DropColumn("dbo.Choices", "UniqueQuestionID");
            RenameColumn(table: "dbo.Questions", name: "Subject_SubjectID", newName: "SubjectID");
            RenameColumn(table: "dbo.Questions", name: "QuestionCategory_QuestionCategoryId", newName: "QuestionCategoryId");
            RenameColumn(table: "dbo.Questions", name: "Exhibit_ExhibitId", newName: "ExhibitId");
            CreateIndex("dbo.TestXQuestions", "Question_QuestionId");
            CreateIndex("dbo.TestXQuestions", "TestId");
            CreateIndex("dbo.Questions", "QuestionCategoryId");
            CreateIndex("dbo.Questions", "ExhibitId");
            CreateIndex("dbo.Questions", "SubjectID");
            CreateIndex("dbo.Choices", "QuestionId");
            AddForeignKey("dbo.Questions", "SubjectID", "dbo.Subjects", "SubjectID", cascadeDelete: true);
            AddForeignKey("dbo.Questions", "QuestionCategoryId", "dbo.QuestionCategories", "QuestionCategoryId", cascadeDelete: true);
            AddForeignKey("dbo.Questions", "ExhibitId", "dbo.Exhibits", "ExhibitId", cascadeDelete: true);
            AddForeignKey("dbo.TestXQuestions", "Question_QuestionId", "dbo.Questions", "QuestionId");
            AddForeignKey("dbo.TestXQuestions", "TestId", "dbo.Tests", "TestId");
            AddForeignKey("dbo.Choices", "QuestionId", "dbo.Questions", "QuestionId", cascadeDelete: true);
        }
    }
}
