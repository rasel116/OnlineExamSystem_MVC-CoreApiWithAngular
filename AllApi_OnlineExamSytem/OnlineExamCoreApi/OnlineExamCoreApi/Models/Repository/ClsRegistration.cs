using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamCoreApi.Models.Repository
{
    public class ClsRegistration : IDataAccessRepository<Registration>
    {
        readonly CrudInCoreWebApiDbContext _registrationContext;
        public ClsRegistration(CrudInCoreWebApiDbContext context)
        {
            _registrationContext = context;
        }

        public void Add(Registration entity)
        {
            _registrationContext.Registrations.Add(entity);
            _registrationContext.SaveChanges();
        }

        public void Delete(Registration entity)
        {
            _registrationContext.Registrations.Remove(entity);
            _registrationContext.SaveChanges();
        }

        public Registration Get(long id)
        {
            return _registrationContext.Registrations.FirstOrDefault(e => e.RegistrationId == id);
        }

        public IEnumerable<Registration> GetAll()
        {
            return _registrationContext.Registrations.ToList();
        }

        public void Update(Registration registration, Registration entity)
        {
            registration.RegistrationDate = entity.RegistrationDate;
            registration.Token = entity.Token;
            registration.TokenExpireTime = entity.TokenExpireTime;
            registration.StudentId = entity.StudentId;

            _registrationContext.SaveChanges();
        }
    }
}
