using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Add New
using Microsoft.Practices.Unity;

namespace OnlineExamMvcApi.Models.Repository
{
    public class ClsQuestionCategory : IDataAccessRepository<QuestionCategory, int>
    {
        [Dependency]
        public ApplicationDbContext db { get; set; }

        public void Delete(int id)
        {
            var qstcatgory = db.QuestionCategories.Find(id);
            if (qstcatgory != null)
            {
                db.QuestionCategories.Remove(qstcatgory);
                db.SaveChanges();
            }
        }

        public IEnumerable<QuestionCategory> Get()
        {
            return db.QuestionCategories.ToList();
        }

        public QuestionCategory Get(int id)
        {
            return db.QuestionCategories.Find(id);
        }

        public void Post(QuestionCategory entity)
        {
            Question question = new Question();
            //question.QuestionCategoryId = entity.QuestionCategoryId;
            db.Questions.Add(question);

            db.QuestionCategories.Add(entity);
            db.SaveChanges();
        }

        public void Put(int id, QuestionCategory entity)
        {
            var qstcatgory = db.QuestionCategories.Find(id);
            if (qstcatgory != null)
            {
                qstcatgory.Category = entity.Category;
                db.SaveChanges();
            }
        }
    }
}