using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//Add New
using Microsoft.Practices.Unity;
namespace OnlineExamMvcApi.Models.Repository
{
    public class ClsAdminPanel : IDataAccessRepository<AdminPanel, int>
    {
        [Dependency]
        public ApplicationDbContext db { get; set; }
        public void Delete(int id)
        {
            var admin = db.AdminPanels.Find(id);
            if (admin != null)
            {
                db.AdminPanels.Remove(admin);
                db.SaveChanges();
            }
        }

        public IEnumerable<AdminPanel> Get()
        {
            return db.AdminPanels.ToList();
        }

        public AdminPanel Get(int id)
        {
            return db.AdminPanels.Find(id);
        }

        public void Post(AdminPanel entity)
        {
            db.AdminPanels.Add(entity);
            db.SaveChanges();
        }

        public void Put(int id, AdminPanel entity)
        {
            var admin = db.AdminPanels.Find(id);
            if (admin != null)
            {
                admin.AdminName = entity.AdminName;
                admin.AdminEmail = entity.AdminEmail;
                admin.IsActive = entity.IsActive;
                db.SaveChanges();
            }
        }
    }
}