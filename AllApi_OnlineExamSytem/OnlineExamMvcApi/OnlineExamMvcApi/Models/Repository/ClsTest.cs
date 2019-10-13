using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Add New
using Microsoft.Practices.Unity;

namespace OnlineExamMvcApi.Models.Repository
{
    public class ClsTest : IDataAccessRepository<Test, int>
    {
        [Dependency]
        public ApplicationDbContext db { get; set; }

        public void Delete(int id)
        {
            var test = db.Tests.Find(id);
            if (test != null)
            {
                db.Tests.Remove(test);
                db.SaveChanges();
            }
        }

        public IEnumerable<Test> Get()
        {
            return db.Tests.ToList();
        }

        public Test Get(int id)
        {
            return db.Tests.Find(id);
        }

        public void Post(Test entity)
        {
            Random unique = new Random();
            int uniqueID = unique.Next();

            int id = db.Tests.Max(t => t.TestId);
            //var txtid = db.Tests.Where(x => x.TestId == entity.TestId);
            entity.UniqueID = uniqueID;
            db.Tests.Add(entity);
            db.SaveChanges();

            TestXQuestion testX = db.TestXQuestions.Where(s => s.Label == "UniqueTestID").FirstOrDefault();
            testX.UniqueTestID = uniqueID;
            db.SaveChanges();
        }

        public void Put(int id, Test entity)
        {
            var test = db.Tests.Find(id);
            if (test != null)
            {
                test.Name = entity.Name;
                test.Description = entity.Description;
                test.IsActive = entity.IsActive;
                test.DurationInMinute = entity.DurationInMinute;
                db.SaveChanges();
            }
        }
    }
}