using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamCoreApi.Models.Repository
{
    public class ClsTest : IDataAccessRepository<Test>
    {
        readonly CrudInCoreWebApiDbContext _testContext;
        public ClsTest(CrudInCoreWebApiDbContext context)
        {
            _testContext = context;
        }
        public void Add(Test entity)
        {
            TestXQuestion testXQuestion = new TestXQuestion();
            testXQuestion.UniqueTestID = entity.UniqueID;
            _testContext.TestXQuestions.Add(testXQuestion);


            _testContext.Tests.Add(entity);
            _testContext.SaveChanges();
        }

        public void Delete(Test entity)
        {
            _testContext.Tests.Remove(entity);
            _testContext.SaveChanges();
        }

        public Test Get(long id)
        {
            return _testContext.Tests.FirstOrDefault(e => e.TestId == id);
        }

        public IEnumerable<Test> GetAll()
        {
            return _testContext.Tests.ToList();
        }

        public void Update(Test test, Test entity)
        {
            test.Name = entity.Name;
            test.Description = entity.Description;
            test.IsActive = entity.IsActive;
            test.DurationInMinute = entity.DurationInMinute;

            _testContext.SaveChanges();
        }
    }
}
