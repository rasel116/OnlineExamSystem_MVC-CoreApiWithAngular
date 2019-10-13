using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Add New
using Microsoft.Practices.Unity;
namespace OnlineExamMvcApi.Models.Repository
{
    public class ClsQuizQuestion : IDataAccessRepository<QuizQuestion, int>
    {
        [Dependency]
        public ApplicationDbContext db { get; set; }

        public void Delete(int id)
        {
            var QQ = db.QuizQuestions.Find(id);
            if (QQ != null)
            {
                db.QuizQuestions.Remove(QQ);
                db.SaveChanges();
            }
        }

        public IEnumerable<QuizQuestion> Get()
        {
            return db.QuizQuestions.ToList();
        }

        public QuizQuestion Get(int id)
        {
            return db.QuizQuestions.Find(id);
        }

        public void Post(QuizQuestion entity)
        {
            db.QuizQuestions.Add(entity);
            db.SaveChanges();
        }

        public void Put(int id, QuizQuestion entity)
        {
            var QQ = db.QuizQuestions.Find(id);
            if (QQ != null)
            {
                QQ.SubjectID = entity.SubjectID;
                QQ.QuestionCategoryId = entity.QuestionCategoryId;
                QQ.ExhibitId = entity.ExhibitId;
                QQ.Qn = entity.Qn;
                QQ.Option1 = entity.Option1;
                QQ.Option2 = entity.Option2;
                QQ.Option3 = entity.Option3;
                QQ.Option4 = entity.Option4;
                QQ.Answer = entity.Answer;
                db.SaveChanges();
            }
        }
    }
}