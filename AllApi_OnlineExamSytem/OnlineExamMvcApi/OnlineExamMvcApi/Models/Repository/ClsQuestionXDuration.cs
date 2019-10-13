using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Add New
using Microsoft.Practices.Unity;

namespace OnlineExamMvcApi.Models.Repository
{
    public class ClsQuestionXDuration : IDataAccessRepository<QuestionXDuration, int>
    {
        [Dependency]
        public ApplicationDbContext db { get; set; }

        public void Delete(int id)
        {
            var quesD = db.QuestionXDurations.Find(id);
            if (quesD != null)
            {
                db.QuestionXDurations.Remove(quesD);
                db.SaveChanges();
            }
        }

        public IEnumerable<QuestionXDuration> Get()
        {
            return db.QuestionXDurations.ToList();
        }

        public QuestionXDuration Get(int id)
        {
            return db.QuestionXDurations.Find(id);
        }

        public void Post(QuestionXDuration entity)
        {
            db.QuestionXDurations.Add(entity);
            db.SaveChanges();
        }

        public void Put(int id, QuestionXDuration entity)
        {
            var quesD = db.QuestionXDurations.Find(id);
            if (quesD != null)
            {
                quesD.RequestTime = entity.RequestTime;
                quesD.LeaveTime = entity.LeaveTime;
                quesD.AnsweredTime = entity.AnsweredTime;
                quesD.RegistrationId = entity.RegistrationId;
                db.SaveChanges();
            }
        }
    }
}