using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamCoreApi.Models.Repository
{
    public class ClsQuestionCategory : IDataAccessRepository<QuestionCategory>
    {
        readonly CrudInCoreWebApiDbContext _questionCategoryContext;
        public ClsQuestionCategory(CrudInCoreWebApiDbContext context)
        {
            _questionCategoryContext = context;
        }
        public void Add(QuestionCategory entity)
        {
            Question question = new Question();
            question.QuestionCategoryId = entity.QuestionCategoryId;
            _questionCategoryContext.Questions.Add(question);

            _questionCategoryContext.QuestionCategories.Add(entity);
            _questionCategoryContext.SaveChanges();
        }

        public void Delete(QuestionCategory entity)
        {
            _questionCategoryContext.QuestionCategories.Remove(entity);
            _questionCategoryContext.SaveChanges();
        }

        public QuestionCategory Get(long id)
        {
            return _questionCategoryContext.QuestionCategories.FirstOrDefault(e => e.QuestionCategoryId == id);
        }

        public IEnumerable<QuestionCategory> GetAll()
        {
            return _questionCategoryContext.QuestionCategories.ToList();
        }

        public void Update(QuestionCategory questionCategory, QuestionCategory entity)
        {
            questionCategory.Category = entity.Category;
            _questionCategoryContext.SaveChanges();
        }


    }
}
