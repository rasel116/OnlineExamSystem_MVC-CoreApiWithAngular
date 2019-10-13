namespace OnlineExamMvcApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class examsidfds8373nk : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "Exhibit_ExhibitId", "dbo.Exhibits");
            DropForeignKey("dbo.Questions", "QuestionCategory_QuestionCategoryId", "dbo.QuestionCategories");
            DropForeignKey("dbo.Questions", "Subject_SubjectID", "dbo.Subjects");
            DropIndex("dbo.Questions", new[] { "Exhibit_ExhibitId" });
            DropIndex("dbo.Questions", new[] { "QuestionCategory_QuestionCategoryId" });
            DropIndex("dbo.Questions", new[] { "Subject_SubjectID" });
            RenameColumn(table: "dbo.Questions", name: "Exhibit_ExhibitId", newName: "ExhibitId");
            RenameColumn(table: "dbo.Questions", name: "QuestionCategory_QuestionCategoryId", newName: "QuestionCategoryId");
            RenameColumn(table: "dbo.Questions", name: "Subject_SubjectID", newName: "SubjectID");
            AlterColumn("dbo.Questions", "ExhibitId", c => c.Int(nullable: false));
            AlterColumn("dbo.Questions", "QuestionCategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Questions", "SubjectID", c => c.Int(nullable: false));
            CreateIndex("dbo.Questions", "SubjectID");
            CreateIndex("dbo.Questions", "ExhibitId");
            CreateIndex("dbo.Questions", "QuestionCategoryId");
            AddForeignKey("dbo.Questions", "ExhibitId", "dbo.Exhibits", "ExhibitId", cascadeDelete: true);
            AddForeignKey("dbo.Questions", "QuestionCategoryId", "dbo.QuestionCategories", "QuestionCategoryId", cascadeDelete: true);
            AddForeignKey("dbo.Questions", "SubjectID", "dbo.Subjects", "SubjectID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "SubjectID", "dbo.Subjects");
            DropForeignKey("dbo.Questions", "QuestionCategoryId", "dbo.QuestionCategories");
            DropForeignKey("dbo.Questions", "ExhibitId", "dbo.Exhibits");
            DropIndex("dbo.Questions", new[] { "QuestionCategoryId" });
            DropIndex("dbo.Questions", new[] { "ExhibitId" });
            DropIndex("dbo.Questions", new[] { "SubjectID" });
            AlterColumn("dbo.Questions", "SubjectID", c => c.Int());
            AlterColumn("dbo.Questions", "QuestionCategoryId", c => c.Int());
            AlterColumn("dbo.Questions", "ExhibitId", c => c.Int());
            RenameColumn(table: "dbo.Questions", name: "SubjectID", newName: "Subject_SubjectID");
            RenameColumn(table: "dbo.Questions", name: "QuestionCategoryId", newName: "QuestionCategory_QuestionCategoryId");
            RenameColumn(table: "dbo.Questions", name: "ExhibitId", newName: "Exhibit_ExhibitId");
            CreateIndex("dbo.Questions", "Subject_SubjectID");
            CreateIndex("dbo.Questions", "QuestionCategory_QuestionCategoryId");
            CreateIndex("dbo.Questions", "Exhibit_ExhibitId");
            AddForeignKey("dbo.Questions", "Subject_SubjectID", "dbo.Subjects", "SubjectID");
            AddForeignKey("dbo.Questions", "QuestionCategory_QuestionCategoryId", "dbo.QuestionCategories", "QuestionCategoryId");
            AddForeignKey("dbo.Questions", "Exhibit_ExhibitId", "dbo.Exhibits", "ExhibitId");
        }
    }
}
