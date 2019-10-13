using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Add New
using Microsoft.Practices.Unity;

namespace OnlineExamMvcApi.Models.Repository
{
    public class ClsRegistration : IDataAccessRepository<Registration, int>
    {
        [Dependency]
        public ApplicationDbContext db { get; set; }

        public void Delete(int id)
        {
            var reg = db.Registrations.Find(id);
            if (reg != null)
            {
                db.Registrations.Remove(reg);
                db.SaveChanges();
            }
        }

        public IEnumerable<Registration> Get()
        {
            return db.Registrations.ToList();
        }

        public Registration Get(int id)
        {
            return db.Registrations.Find(id);
        }

        public void Post(Registration entity)
        {
            db.Registrations.Add(entity);
            db.SaveChanges();
        }

        public void Put(int id, Registration entity)
        {
            var reg = db.Registrations.Find(id);
            if (reg != null)
            {
                reg.RegistrationDate = entity.RegistrationDate;
                reg.Token = entity.Token;
                reg.TokenExpireTime = entity.TokenExpireTime;
                reg.StudentId = entity.StudentId;
                db.SaveChanges();
            }
        }
    }
}