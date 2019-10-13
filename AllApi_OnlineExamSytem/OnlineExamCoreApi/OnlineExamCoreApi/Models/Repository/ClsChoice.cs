using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamCoreApi.Models.Repository
{
    public class ClsChoice : IDataAccessRepository<Choice>
    {
        readonly CrudInCoreWebApiDbContext _choiceContext;
        public ClsChoice(CrudInCoreWebApiDbContext context)
        {
            _choiceContext = context;
        }
        public void Add(Choice entity)
        {
            _choiceContext.Choices.Add(entity);
            _choiceContext.SaveChanges();
        }

        public void Delete(Choice entity)
        {
            _choiceContext.Choices.Remove(entity);
            _choiceContext.SaveChanges();
        }

        public Choice Get(long id)
        {
            return _choiceContext.Choices.FirstOrDefault(e => e.ChoiceId == id);
        }

        public IEnumerable<Choice> GetAll()
        {
            return _choiceContext.Choices.ToList();
        }

        public void Update(Choice choice, Choice entity)
        {
            choice.Label = entity.Label;
            choice.Points = entity.Points;
            choice.IsActive = entity.IsActive;
            _choiceContext.SaveChanges();
        }
    }
}
