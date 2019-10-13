using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Add New
using Microsoft.Practices.Unity;

namespace OnlineExamMvcApi.Models.Repository
{
    public class ClsTestXQuestion : IDataAccessRepository<TestXQuestion, int>
    {
        [Dependency]
        public ApplicationDbContext db { get; set; }

        public void Delete(int id)
        {
            var testXQ = db.TestXQuestions.Find(id);
            if (testXQ != null)
            {
                db.TestXQuestions.Remove(testXQ);
                db.SaveChanges();
            }
        }

        public IEnumerable<TestXQuestion> Get()
        {
            return db.TestXQuestions.ToList();
        }

        public TestXQuestion Get(int id)
        {
            return db.TestXQuestions.Find(id);
        }

        public void Post(TestXQuestion entity)
        {
            TestXPaper testXPaper = new TestXPaper();
 
            db.TestXPapers.Add(testXPaper);

            db.TestXQuestions.Add(entity);
            db.SaveChanges();
        }

        public void Put(int id, TestXQuestion entity)
        {
            var testXQ = db.TestXQuestions.Find(id);
            if (testXQ != null)
            {
                testXQ.UniqueQuestionID = entity.UniqueQuestionID;
                testXQ.IsActive = entity.IsActive;
                //testXQ.TestId = entity.TestId;
                db.SaveChanges();
            }
        }
    }
}