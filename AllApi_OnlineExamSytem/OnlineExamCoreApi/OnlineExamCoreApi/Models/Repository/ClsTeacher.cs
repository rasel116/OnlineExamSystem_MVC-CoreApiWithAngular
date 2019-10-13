using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamCoreApi.Models.Repository
{
    public class ClsTeacher : IDataAccessRepository<Teacher>
    {
        readonly CrudInCoreWebApiDbContext _teacherContext;

        public ClsTeacher(CrudInCoreWebApiDbContext context)
        {
            _teacherContext = context;
        }

        public void Add(Teacher entity)
        {
            _teacherContext.Teachers.Add(entity);
            _teacherContext.SaveChanges();
        }

        public void Delete(Teacher entity)
        {
            _teacherContext.Teachers.Remove(entity);
            _teacherContext.SaveChanges();
        }

        public Teacher Get(long id)
        {
            return _teacherContext.Teachers.FirstOrDefault(e => e.TeacherID == id);
        }

        public IEnumerable<Teacher> GetAll()
        {
            return _teacherContext.Teachers.ToList();
        }

        public void Update(Teacher teacher, Teacher entity)
        {
            teacher.TeacherName = entity.TeacherName;
            teacher.EntryDate = entity.EntryDate;
            teacher.Email = entity.Email;
            teacher.Phone = entity.Phone;
            _teacherContext.SaveChanges();
        }
    }
}
