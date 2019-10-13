using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamCoreApi.Models.Repository
{
    public class ClsOrganization : IDataAccessRepository<Organization>
    {
        readonly CrudInCoreWebApiDbContext _organizationContext;
        public ClsOrganization(CrudInCoreWebApiDbContext context)
        {
            _organizationContext = context;
        }
        public void Add(Organization entity)
        {
            _organizationContext.Organizations.Add(entity);
            _organizationContext.SaveChanges();
        }

        public void Delete(Organization entity)
        {
            _organizationContext.Organizations.Remove(entity);
            _organizationContext.SaveChanges();
        }

        public Organization Get(long id)
        {
            return _organizationContext.Organizations.FirstOrDefault(e => e.OrganizationID == id);
        }

        public IEnumerable<Organization> GetAll()
        {
            return _organizationContext.Organizations.ToList();
        }

        public void Update(Organization org, Organization entity)
        {
            org.OrgName = entity.OrgName;
            org.IsActive = entity.IsActive;
            org.AdminPanelId = entity.AdminPanelId;
            _organizationContext.SaveChanges();
        }
    }
}
