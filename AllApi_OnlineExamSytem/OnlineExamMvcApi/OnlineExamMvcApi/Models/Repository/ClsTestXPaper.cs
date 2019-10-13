using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;
using System.Web.Http.Results;

//Add New
using Microsoft.Practices.Unity;

namespace OnlineExamMvcApi.Models.Repository
{
    public class ClsTestXPaper : IDataAccessRepository<TestXPaper, int>
    {
        [Dependency]
        public ApplicationDbContext db { get; set; }

        public void Delete(int id)
        {
            var testXp = db.TestXPapers.Find(id);
            if (testXp != null)
            {
                db.TestXPapers.Remove(testXp);
                db.SaveChanges();
            }
        }



        public IEnumerable<TestXPaper> Get()
        {

            return db.TestXPapers.ToList();
        }

        //public TestXPaper Get(int id)
        //{

        //    return db.TestXPapers.Find(id);
        //}

        public TestXPaper Get(int id)
        {

            //var query = from x in db.TestXPapers
            //join y in db.TestXQuestions on x.TestXQuestionId equals y.QuestionId
            //where x.TestXQuestionId.Equals(id)

            //select new TestXPaper
            //{
            //    TestXQuestionId = y.TestXQuestionId

            //};

            var query = db.TestXPapers.Include("TestXQuestions").ToList();

            return db.TestXPapers.Find(query);

        }

     

        public void Post(TestXPaper entity)
        {
            db.TestXPapers.Add(entity);
            db.SaveChanges();
        }

        public void Put(int id, TestXPaper entity)
        {

            var myTotalMark = entity.MarkScored;

            var testXp = db.TestXPapers.Find(id);

            Choice choice = new Choice();

            if (choice.ChoiceId == entity.ChoiceId)
            {
                if (choice.IsActive == true)
                {
                    myTotalMark += 1;

                }
                else
                {
                    myTotalMark -= 1;
                }

            }



            if (testXp != null)
            {
                testXp.Answer = entity.Answer;
                testXp.MarkScored = entity.MarkScored;
                testXp.RegistrationId = entity.RegistrationId;
                db.SaveChanges();
            }
        }
    }
}