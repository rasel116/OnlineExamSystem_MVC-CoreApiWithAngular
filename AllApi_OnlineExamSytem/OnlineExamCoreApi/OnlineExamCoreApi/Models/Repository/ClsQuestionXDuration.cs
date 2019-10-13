using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamCoreApi.Models.Repository
{
    public class ClsQuestionXDuration : IDataAccessRepository<QuestionXDuration>
    {
        readonly CrudInCoreWebApiDbContext _questionXDurationContext;
        public ClsQuestionXDuration(CrudInCoreWebApiDbContext context)
        {
            _questionXDurationContext = context;
        }
        public void Add(QuestionXDuration entity)
        {
            _questionXDurationContext.QuestionXDurations.Add(entity);
            _questionXDurationContext.SaveChanges();
        }

        public void Delete(QuestionXDuration entity)
        {
            _questionXDurationContext.QuestionXDurations.Remove(entity);
            _questionXDurationContext.SaveChanges();
        }

        public QuestionXDuration Get(long id)
        {
            return _questionXDurationContext.QuestionXDurations.FirstOrDefault(e => e.QuestionXDurationId == id);
        }

        public IEnumerable<QuestionXDuration> GetAll()
        {
            return _questionXDurationContext.QuestionXDurations.ToList();

        }

        public void Update(QuestionXDuration questionXDuration, QuestionXDuration entity)
        {
            questionXDuration.RequestTime = entity.RequestTime;
            questionXDuration.LeaveTime = entity.LeaveTime;
            questionXDuration.AnsweredTime = entity.AnsweredTime;
            questionXDuration.RegistrationId = entity.RegistrationId;
            //questionXDuration.TestXQuestionId = entity.TestXQuestionId;
            _questionXDurationContext.SaveChanges();
        }
    }
}
