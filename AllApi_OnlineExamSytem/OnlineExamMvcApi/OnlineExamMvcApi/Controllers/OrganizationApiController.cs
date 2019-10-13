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
    [RoutePrefix("api/Organization")]
    public class OrganizationApiController : ApiController
    {
        private IDataAccessRepository<Organization, int> _repo;


        //Inject the DataAccessReposity using Contruction Injection 
        public OrganizationApiController(IDataAccessRepository<Organization, int> c)
        {
            _repo = c;
        }

        [HttpGet]
        [Route("GetOrganization", Name = "GetOrganization")]
        public IEnumerable<Organization> GetOrganization()
        {
            return _repo.Get();
        }

        [HttpGet]
        [Route("GetOrganizationById/{organizationId}")]
        public IHttpActionResult GetOrganizationById(int organizationId)
        {
            return Ok(_repo.Get(organizationId));
        }

        [HttpPost]
        [Route("InsertOrganization")]
        public IHttpActionResult PostOrganization(Organization organization)
        {
            _repo.Post(organization);
            return Ok(organization);
        }

        [HttpPut]
        [Route("UpdateOrganization/{organizationId}")]
        public IHttpActionResult PutAdminPanel(int organizationId, Organization organization)
        {
            _repo.Put(organizationId, organization);
            return CreatedAtRoute("GetOrganization", new { id = organization.OrganizationID }, organization);
        }


        [HttpDelete]
        [Route("DeleteOrganization/{organizationId}")]
        public IHttpActionResult DeleteChoice(int organizationId, Organization organization)
        {
            _repo.Delete(organizationId);
            return CreatedAtRoute("GetOrganization", new { id = organization.OrganizationID }, organization);
        }
    }
}
