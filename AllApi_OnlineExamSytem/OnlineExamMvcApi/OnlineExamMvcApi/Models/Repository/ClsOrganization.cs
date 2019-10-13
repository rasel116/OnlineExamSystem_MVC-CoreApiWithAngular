using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineExamMvcApi.Models.Repository
{
    public class ClsOrganization : IDataAccessRepository<Organization, int>
    {
         [Dependency]
        public ApplicationDbContext db { get; set; }
        public void Delete(int id)
        {
            var org = db.Organizations.Find(id);
            if (org != null)
            {
                db.Organizations.Remove(org);
                db.SaveChanges();
            }
        }    




        public IEnumerable<Organization> Get()
        {
            return db.Organizations.ToList();
        }

        public Organization Get(int id)
        {
            return db.Organizations.Find(id);
        }

        public void Post(Organization entity)
        {
            db.Organizations.Add(entity);
            db.SaveChanges();
        }

        public void Put(int id, Organization entity)
        {
            var org = db.Organizations.Find(id);
            if (org != null)
            {
                org.OrgName = entity.OrgName;
                org.AdminPanelId = entity.AdminPanelId;
                org.IsActive = entity.IsActive;
                db.SaveChanges();
            }
        }
    }
}