using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Add New
using Microsoft.Practices.Unity;

namespace OnlineExamMvcApi.Models.Repository
{
    public class ClsQuestion : IDataAccessRepository<Question, int>
    {
        [Dependency]
        public ApplicationDbContext db { get; set; }

        public void Delete(int id)
        {
            var question = db.Questions.Find(id);
            if (question != null)
            {
                db.Questions.Remove(question);
                db.SaveChanges();
            }
        }

        public IEnumerable<Question> Get()
        {
            return db.Questions.ToList();
        }

        public Question Get(int id)
        {
            return db.Questions.Find(id);
        }

        public void Post(Question entity)
        {

            Random unique = new Random();
            int uniqueQuestion = unique.Next();

            Choice choice = db.Choices.Where(s => s.Label == "UniqueQuestionID").FirstOrDefault();
            //choice.QuestionId = entity.QuestionId;
            choice.UniqueQuestionID = uniqueQuestion;
            //choice.Points = entity.Points;
            //choice.Label = "a";
            //db.Choices.Add(choice);
            db.SaveChanges();

            TestXQuestion testX  = db.TestXQuestions.Where(s => s.Label == "UniqueTestID").FirstOrDefault(); //=========================== We have to delete it and have to take value form cache when implement.
            //TestXQuestion testXQuestion = db.TestXQuestions.Where(t => t.UniqueID == entity.TestUniqueID).FirstOrDefault();
            //testXQuestion.QuestionId = entity.QuestionId;
            //db.TestXQuestions.Add(testXQuestion);
            testX.UniqueTestID = entity.TestUniqueID;
            db.SaveChanges();

            TestXQuestion testXQuestion = new TestXQuestion();
            testXQuestion.UniqueQuestionID = uniqueQuestion;
            testXQuestion.IsActive = entity.IsActive;
            testXQuestion.UniqueTestID = testX.UniqueTestID;
            testXQuestion.Label = "Question";
            db.TestXQuestions.Add(testXQuestion);
            db.SaveChanges();



            //entity.SubjectID = subjectVM.SubjectID;
            //entity.QuestionCategoryId = questionCategoryVM.QuestionCategoryId;
            //entity.ExhibitId = exhibitVM.ExhibitId;
            entity.QuestionUniqueID = uniqueQuestion;
            db.Questions.Add(entity);
            db.SaveChanges();

        }

        public void Put(int id, Question entity)
        {
            var question = db.Questions.Find(id);
            if (question != null)
            {
                question.QuestionType = entity.QuestionType;
                question.Question1 = entity.Question1;
                question.Points = entity.Points;
                question.IsActive = entity.IsActive;
                db.SaveChanges();
            }
        }
    }
}