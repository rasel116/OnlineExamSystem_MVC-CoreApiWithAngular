using OnlineExamMvcApi.Models;
using OnlineExamMvcApi.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OnlineExamMvcApi.Controllers
{
    [RoutePrefix("api/AdminPanel")]
    public class AdminApiController : ApiController
    {
        private IDataAccessRepository<AdminPanel, int> _repo;

        //Inject the DataAccessReposity using Contruction Injection 
        public AdminApiController(IDataAccessRepository<AdminPanel, int> c)
        {
            _repo = c;
        }

        [HttpGet]
        [Route("GetAdminPanel", Name = "GetAdmin")]
        public IEnumerable<AdminPanel> GetAdminPanel()
        {
            return _repo.Get();
        }

        [HttpGet]
        [Route("GetAdminPanelById/{adminPanelId}")]
        public IHttpActionResult GetAdminPanelById(int adminPanelId)
        {
            return Ok(_repo.Get(adminPanelId));
        }

        [HttpPost]
        [Route("InsertAdminPanel")]
        public IHttpActionResult PostAdminPanel(AdminPanel adminPanel)
        {
            _repo.Post(adminPanel);
            return Ok(adminPanel);
        }

        [HttpPut]
        [Route("UpdateAdminPanel/{adminPanelId}")]
        public IHttpActionResult PutAdminPanel(int adminPanelId, AdminPanel admin)
        {
            _repo.Put(adminPanelId, admin);
            return CreatedAtRoute("GetAdmin", new { id = admin.AdminPanelId }, admin);
        }


        [HttpDelete]
        [Route("DeleteAdminPanel/{adminPanelId}")]
        public IHttpActionResult DeleteChoice(int adminPanelId, AdminPanel admin)
        {
            _repo.Delete(adminPanelId);
            return CreatedAtRoute("GetAdmin", new { id = admin.AdminPanelId }, admin);
        }
    }
}
