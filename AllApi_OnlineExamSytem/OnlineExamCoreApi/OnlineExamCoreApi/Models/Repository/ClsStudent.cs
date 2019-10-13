using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Add New
using OnlineExamCoreApi.Models;
using OnlineExamCoreApi.Models.Repository;


namespace OnlineExamCoreApi.Models.Repository
{
    public class ClsStudent : IDataAccessRepository<Student>
    {
        readonly CrudInCoreWebApiDbContext _studentContext;

        public ClsStudent(CrudInCoreWebApiDbContext context)
        {
            _studentContext = context;
        }
        public void Add(Student entity)
        {

            _studentContext.Students.Add(entity);
            _studentContext.SaveChanges();
        }

        public void Delete(Student entity)
        {
            _studentContext.Students.Remove(entity);
            _studentContext.SaveChanges();
        }

        public Student Get(long id)
        {
            return _studentContext.Students.FirstOrDefault(e => e.StudentId == id);
        }

        public IEnumerable<Student> GetAll()
        {
            return _studentContext.Students.ToList();
        }

        public void Update(Student student, Student entity)
        {
            student.Name = entity.Name;
            student.AccessLevel = entity.AccessLevel;
            student.EntryDate = entity.EntryDate;
            student.Email = entity.Email;
            student.Phone = entity.Phone;
            student.PassHash = entity.PassHash;
            _studentContext.SaveChanges();
        }
    }
}
