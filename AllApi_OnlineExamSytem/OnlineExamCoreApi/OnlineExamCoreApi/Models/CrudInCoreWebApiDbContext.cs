using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

//Add New
using Microsoft.EntityFrameworkCore;

namespace OnlineExamCoreApi.Models
{
    public class CrudInCoreWebApiDbContext:IdentityDbContext<IdentityUser>
    {
        public CrudInCoreWebApiDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(
                new { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new { Id = "2", Name = "Customer", NormalizedName = "CUSTOMER" }
                );
        }


        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Exhibit> Exhibits { get; set; }
        public DbSet<QuestionCategory> QuestionCategories { get; set; }
        public DbSet<QuestionXDuration> QuestionXDurations { get; set; }
        public DbSet<TestXQuestion> TestXQuestions { get; set; }
        public DbSet<TestXPaper> TestXPapers { get; set; }
        public DbSet<AdminPanel> AdminPanels { get; set; }
        public DbSet<Organization> Organizations { get; set; }
    }

}
