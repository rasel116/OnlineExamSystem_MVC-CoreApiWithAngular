using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Add
using Microsoft.Practices.Unity;

namespace OnlineExamMvcApi.Models.Repository
{
    public class ClsSubject : IDataAccessRepository<Subject, int>
    {
        [Dependency]
        public ApplicationDbContext db { get; set; }

        public void Delete(int id)
        {
            var subject = db.Subjects.Find(id);
            if (subject != null)
            {
                db.Subjects.Remove(subject);
                db.SaveChanges();
            }
        }

        public IEnumerable<Subject> Get()
        {
            return db.Subjects.ToList();
        }

        public Subject Get(int id)
        {
            return db.Subjects.Find(id);
        }

        public void Post(Subject entity)
        {
            //Question question = new Question();
            ////question.SubjectID = entity.SubjectID;
            //db.Questions.Add(question);

            db.Subjects.Add(entity);
            db.SaveChanges();
        }

        public void Put(int id, Subject entity)
        {
            var subject = db.Subjects.Find(id);
            if (subject != null)
            {
                subject.SubjectName = entity.SubjectName;
                db.SaveChanges();
            }
        }
    }
}