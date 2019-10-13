using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamCoreApi.Models.Repository
{
    public class ClsTestXPaper : IDataAccessRepository<TestXPaper>
    {
        readonly CrudInCoreWebApiDbContext _testXPaperContext;
        public ClsTestXPaper(CrudInCoreWebApiDbContext context)
        {
            _testXPaperContext = context;
        }
        public void Add(TestXPaper entity)
        {
            _testXPaperContext.TestXPapers.Add(entity);
            _testXPaperContext.SaveChanges();
        }

        public void Delete(TestXPaper entity)
        {
            _testXPaperContext.TestXPapers.Remove(entity);
            _testXPaperContext.SaveChanges();
        }

        public TestXPaper Get(long id)
        {
            return _testXPaperContext.TestXPapers.FirstOrDefault(e => e.TestXPaperId == id);
        }

        public IEnumerable<TestXPaper> GetAll()
        {
            return _testXPaperContext.TestXPapers.ToList();
        }

        public void Update(TestXPaper testXPaper, TestXPaper entity)
        {
            var myTotalMark = entity.MarkScored;           

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
            testXPaper.Answer = entity.Answer;
            testXPaper.MarkScored = entity.MarkScored;
            testXPaper.ChoiceId = entity.ChoiceId;
            testXPaper.RegistrationId = entity.RegistrationId;
            testXPaper.TestXQuestionId = entity.TestXQuestionId;
            _testXPaperContext.SaveChanges();
        }
    }
}
