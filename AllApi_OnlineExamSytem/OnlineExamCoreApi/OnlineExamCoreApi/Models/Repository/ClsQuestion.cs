using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamCoreApi.Models.Repository
{
    public class ClsQuestion : IDataAccessRepository<Question>
    {
        readonly CrudInCoreWebApiDbContext _questionContext;
        public ClsQuestion(CrudInCoreWebApiDbContext context)
        {
            _questionContext = context;
        }
        public void Add(Question entity)
        {

            Choice choice = new Choice();
            choice.UniqueQuestionID = entity.QuestionUniqueID;
            choice.Points = entity.Points;
            _questionContext.Choices.Add(choice);

            _questionContext.Questions.Add(entity);
            _questionContext.SaveChanges();
        }

        public void Delete(Question entity)
        {
            _questionContext.Questions.Remove(entity);
            _questionContext.SaveChanges();
        }

        public Question Get(long id)
        {
            return _questionContext.Questions.FirstOrDefault(e => e.QuestionId == id);
        }

        public IEnumerable<Question> GetAll()
        {
            return _questionContext.Questions.ToList();
        }

        public void Update(Question question, Question entity)
        {
            question.QuestionType = entity.QuestionType;
            question.Question1 = entity.Question1;
            question.Points = entity.Points;
            question.IsActive = entity.IsActive;
            _questionContext.SaveChanges();
        }
    }
}
