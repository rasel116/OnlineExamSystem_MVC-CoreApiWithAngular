using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace OnlineExamCoreApi.Models.Repository
{
    public class ClsSubject : IDataAccessRepository<Subject>
    {
        readonly CrudInCoreWebApiDbContext _subjectContext;
        public ClsSubject(CrudInCoreWebApiDbContext context)
        {
            _subjectContext = context;
        }
        public void Add(Subject entity)
        {
            Question question = new Question();
            question.SubjectID = entity.SubjectID;
            _subjectContext.Questions.Add(question);


            _subjectContext.Subjects.Add(entity);
            _subjectContext.SaveChanges();
        }

        public void Delete(Subject entity)
        {
            _subjectContext.Subjects.Remove(entity);
            _subjectContext.SaveChanges();
        }

        public Subject Get(long id)
        {
            return _subjectContext.Subjects.FirstOrDefault(e => e.SubjectID== id);
        }

        public IEnumerable<Subject> GetAll()
        {
            return _subjectContext.Subjects.ToList();
        }

        public void Update(Subject subject, Subject entity)
        {
            subject.SubjectName = entity.SubjectName;
            _subjectContext.SaveChanges();
        }
    }
}
