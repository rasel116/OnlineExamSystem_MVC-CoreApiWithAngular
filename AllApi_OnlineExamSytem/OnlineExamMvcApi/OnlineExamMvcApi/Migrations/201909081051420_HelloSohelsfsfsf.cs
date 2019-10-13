namespace OnlineExamMvcApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HelloSohelsfsfsf : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminPanels",
                c => new
                    {
                        AdminPanelId = c.Int(nullable: false, identity: true),
                        AdminName = c.String(),
                        AdminEmail = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AdminPanelId);
            
            CreateTable(
                "dbo.Choices",
                c => new
                    {
                        ChoiceId = c.Int(nullable: false, identity: true),
                        Label = c.String(),
                        Points = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsActive = c.Boolean(nullable: false),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ChoiceId)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        QuestionType = c.String(),
                        Question1 = c.String(),
                        Points = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        SubjectID = c.Int(nullable: false),
                        ExhibitId = c.Int(nullable: false),
                        QuestionCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionId)
                .ForeignKey("dbo.Exhibits", t => t.ExhibitId, cascadeDelete: true)
                .ForeignKey("dbo.QuestionCategories", t => t.QuestionCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectID, cascadeDelete: true)
                .Index(t => t.SubjectID)
                .Index(t => t.ExhibitId)
                .Index(t => t.QuestionCategoryId);
            
            CreateTable(
                "dbo.Exhibits",
                c => new
                    {
                        ExhibitId = c.Int(nullable: false, identity: true),
                        ExhibitData = c.String(),
                    })
                .PrimaryKey(t => t.ExhibitId);
            
            CreateTable(
                "dbo.QuestionCategories",
                c => new
                    {
                        QuestionCategoryId = c.Int(nullable: false, identity: true),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.QuestionCategoryId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectID = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(),
                    })
                .PrimaryKey(t => t.SubjectID);
            
            CreateTable(
                "dbo.TestXQuestions",
                c => new
                    {
                        TestXQuestionId = c.Int(nullable: false, identity: true),
                        QuestionNumber = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        QuestionId = c.Int(nullable: false),
                        TestId = c.Int(),
                    })
                .PrimaryKey(t => t.TestXQuestionId)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .ForeignKey("dbo.Tests", t => t.TestId)
                .Index(t => t.QuestionId)
                .Index(t => t.TestId);
            
            CreateTable(
                "dbo.QuestionXDurations",
                c => new
                    {
                        QuestionXDurationId = c.Int(nullable: false, identity: true),
                        RequestTime = c.DateTime(nullable: false),
                        LeaveTime = c.DateTime(),
                        AnsweredTime = c.DateTime(),
                        RegistrationId = c.Int(),
                        TestXQuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionXDurationId)
                .ForeignKey("dbo.Registrations", t => t.RegistrationId)
                .ForeignKey("dbo.TestXQuestions", t => t.TestXQuestionId, cascadeDelete: true)
                .Index(t => t.RegistrationId)
                .Index(t => t.TestXQuestionId);
            
            CreateTable(
                "dbo.Registrations",
                c => new
                    {
                        RegistrationId = c.Int(nullable: false, identity: true),
                        RegistrationDate = c.DateTime(nullable: false),
                        Token = c.Guid(nullable: false),
                        TokenExpireTime = c.DateTime(nullable: false),
                        TestId = c.Int(),
                        StudentId = c.Int(),
                        OrganizationID = c.Int(),
                    })
                .PrimaryKey(t => t.RegistrationId)
                .ForeignKey("dbo.Organizations", t => t.OrganizationID)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .ForeignKey("dbo.Tests", t => t.TestId)
                .Index(t => t.TestId)
                .Index(t => t.StudentId)
                .Index(t => t.OrganizationID);
            
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        OrganizationID = c.Int(nullable: false, identity: true),
                        OrgName = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        AdminPanelId = c.Int(),
                    })
                .PrimaryKey(t => t.OrganizationID)
                .ForeignKey("dbo.AdminPanels", t => t.AdminPanelId)
                .Index(t => t.AdminPanelId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AccessLevel = c.Int(nullable: false),
                        EntryDate = c.DateTime(nullable: false),
                        Email = c.String(),
                        Phone = c.String(),
                        OrganizationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Organizations", t => t.OrganizationID, cascadeDelete: true)
                .Index(t => t.OrganizationID);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherID = c.Int(nullable: false, identity: true),
                        TeacherName = c.String(),
                        EntryDate = c.DateTime(),
                        Email = c.String(),
                        Phone = c.String(),
                        OrganizationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeacherID)
                .ForeignKey("dbo.Organizations", t => t.OrganizationID, cascadeDelete: true)
                .Index(t => t.OrganizationID);
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        TestId = c.Int(nullable: false, identity: true),
                        TeacherName = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        DurationInMinute = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TestId);
            
            CreateTable(
                "dbo.TestXPapers",
                c => new
                    {
                        TestXPaperId = c.Int(nullable: false, identity: true),
                        Answer = c.String(),
                        MarkScored = c.Decimal(precision: 18, scale: 2),
                        ChoiceId = c.Int(nullable: false),
                        RegistrationId = c.Int(),
                    })
                .PrimaryKey(t => t.TestXPaperId)
                .ForeignKey("dbo.Choices", t => t.ChoiceId, cascadeDelete: true)
                .ForeignKey("dbo.Registrations", t => t.RegistrationId)
                .Index(t => t.ChoiceId)
                .Index(t => t.RegistrationId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.TestXPapers", "RegistrationId", "dbo.Registrations");
            DropForeignKey("dbo.TestXPapers", "ChoiceId", "dbo.Choices");
            DropForeignKey("dbo.TestXQuestions", "TestId", "dbo.Tests");
            DropForeignKey("dbo.QuestionXDurations", "TestXQuestionId", "dbo.TestXQuestions");
            DropForeignKey("dbo.QuestionXDurations", "RegistrationId", "dbo.Registrations");
            DropForeignKey("dbo.Registrations", "TestId", "dbo.Tests");
            DropForeignKey("dbo.Registrations", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Registrations", "OrganizationID", "dbo.Organizations");
            DropForeignKey("dbo.Teachers", "OrganizationID", "dbo.Organizations");
            DropForeignKey("dbo.Students", "OrganizationID", "dbo.Organizations");
            DropForeignKey("dbo.Organizations", "AdminPanelId", "dbo.AdminPanels");
            DropForeignKey("dbo.TestXQuestions", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Questions", "SubjectID", "dbo.Subjects");
            DropForeignKey("dbo.Questions", "QuestionCategoryId", "dbo.QuestionCategories");
            DropForeignKey("dbo.Questions", "ExhibitId", "dbo.Exhibits");
            DropForeignKey("dbo.Choices", "QuestionId", "dbo.Questions");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.TestXPapers", new[] { "RegistrationId" });
            DropIndex("dbo.TestXPapers", new[] { "ChoiceId" });
            DropIndex("dbo.Teachers", new[] { "OrganizationID" });
            DropIndex("dbo.Students", new[] { "OrganizationID" });
            DropIndex("dbo.Organizations", new[] { "AdminPanelId" });
            DropIndex("dbo.Registrations", new[] { "OrganizationID" });
            DropIndex("dbo.Registrations", new[] { "StudentId" });
            DropIndex("dbo.Registrations", new[] { "TestId" });
            DropIndex("dbo.QuestionXDurations", new[] { "TestXQuestionId" });
            DropIndex("dbo.QuestionXDurations", new[] { "RegistrationId" });
            DropIndex("dbo.TestXQuestions", new[] { "TestId" });
            DropIndex("dbo.TestXQuestions", new[] { "QuestionId" });
            DropIndex("dbo.Questions", new[] { "QuestionCategoryId" });
            DropIndex("dbo.Questions", new[] { "ExhibitId" });
            DropIndex("dbo.Questions", new[] { "SubjectID" });
            DropIndex("dbo.Choices", new[] { "QuestionId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.TestXPapers");
            DropTable("dbo.Tests");
            DropTable("dbo.Teachers");
            DropTable("dbo.Students");
            DropTable("dbo.Organizations");
            DropTable("dbo.Registrations");
            DropTable("dbo.QuestionXDurations");
            DropTable("dbo.TestXQuestions");
            DropTable("dbo.Subjects");
            DropTable("dbo.QuestionCategories");
            DropTable("dbo.Exhibits");
            DropTable("dbo.Questions");
            DropTable("dbo.Choices");
            DropTable("dbo.AdminPanels");
        }
    }
}
