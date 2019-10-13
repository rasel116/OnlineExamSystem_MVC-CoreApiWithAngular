using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Add New
using Microsoft.Practices.Unity;

namespace OnlineExamMvcApi.Models.Repository
{
    public class ClsStudent : IDataAccessRepository<Student, int>
    {
        [Dependency]
        public ApplicationDbContext db { get; set; }

        public void Delete(int id)
        {
            var student = db.Students.Find(id);
            if (student != null)
            {
                db.Students.Remove(student);
                db.SaveChanges();
            }
        }

        public IEnumerable<Student> Get()
        {
            return db.Students.ToList();
        }

        public Student Get(int id)
        {
            return db.Students.Find(id);
        }

        public void Post(Student entity)
        {
            db.Students.Add(entity);
            db.SaveChanges();
        }

        public void Put(int id, Student entity)
        {
            var student = db.Students.Find(id);
            if (student != null)
            {
                student.Name = entity.Name;
                student.AccessLevel = entity.AccessLevel;
                student.EntryDate = entity.EntryDate;
                student.Email = entity.Email;
                student.Phone = entity.Phone;
                //student.PassHash = entity.PassHash;
                db.SaveChanges();
            }
        }
    }
}