using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamCoreApi.Models.Repository
{
    public class ClsTestXQuestion : IDataAccessRepository<TestXQuestion>
    {
        readonly CrudInCoreWebApiDbContext _testXQuestionContext;
        public ClsTestXQuestion(CrudInCoreWebApiDbContext context)
        {
            _testXQuestionContext = context;
        }
        public void Add(TestXQuestion entity)
        {
            TestXPaper testXPaper = new TestXPaper();
            testXPaper.TestXQuestionId = entity.TestXQuestionId;
            _testXQuestionContext.TestXPapers.Add(testXPaper);


            _testXQuestionContext.TestXQuestions.Add(entity);
            _testXQuestionContext.SaveChanges();
        }

        public void Delete(TestXQuestion entity)
        {
            _testXQuestionContext.TestXQuestions.Remove(entity);
            _testXQuestionContext.SaveChanges();
        }

        public TestXQuestion Get(long id)
        {
            return _testXQuestionContext.TestXQuestions.FirstOrDefault(e => e.TestXQuestionId== id);
        }

        public IEnumerable<TestXQuestion> GetAll()
        {
            return _testXQuestionContext.TestXQuestions.ToList();
        }

        public void Update(TestXQuestion testXQuestion, TestXQuestion entity)
        {
            testXQuestion.TestXQuestionId = entity.TestXQuestionId;
            testXQuestion.QuestionNumber = entity.QuestionNumber;
            testXQuestion.IsActive = entity.IsActive;
            testXQuestion.UniqueQuestionID = entity.UniqueQuestionID;
            testXQuestion.UniqueTestID = entity.UniqueTestID;
            _testXQuestionContext.SaveChanges();

        }
    }
}
