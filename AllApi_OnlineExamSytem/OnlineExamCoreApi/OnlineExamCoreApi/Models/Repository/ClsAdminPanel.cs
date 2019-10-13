using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamCoreApi.Models.Repository
{
    public class ClsAdminPanel : IDataAccessRepository<AdminPanel>
    {
        readonly CrudInCoreWebApiDbContext _adminContext;
        public ClsAdminPanel(CrudInCoreWebApiDbContext context)
        {
            _adminContext = context;
        }
        public void Add(AdminPanel entity)
        {
            _adminContext.AdminPanels.Add(entity);
            _adminContext.SaveChanges();
        }

        public void Delete(AdminPanel entity)
        {
            _adminContext.AdminPanels.Remove(entity);
            _adminContext.SaveChanges();
        }

        public AdminPanel Get(long id)
        {
            return _adminContext.AdminPanels.FirstOrDefault(e => e.AdminPanelId == id);
        }

        public IEnumerable<AdminPanel> GetAll()
        {
            return _adminContext.AdminPanels.ToList();
        }

        public void Update(AdminPanel admin, AdminPanel entity)
        {
            admin.AdminName = entity.AdminName;
            admin.AdminEmail = entity.AdminEmail;
            admin.IsActive = entity.IsActive;
            _adminContext.SaveChanges();
        }
    }
}
