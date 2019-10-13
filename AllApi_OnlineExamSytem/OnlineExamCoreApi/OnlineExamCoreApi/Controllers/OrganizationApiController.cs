using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExamCoreApi.Models;
using OnlineExamCoreApi.Models.Repository;

namespace OnlineExamCoreApi.Controllers
{
    [Route("api/Organization")]
    [ApiController]
    public class OrganizationApiController : ControllerBase
    {
        private readonly IDataAccessRepository<Organization> _dataRepository;
        public OrganizationApiController(IDataAccessRepository<Organization> dataRepository)
        {
            _dataRepository = dataRepository;
        }


        [HttpGet]
        [Route("GetOrganization")]
        public IActionResult GetOrganization()
        {
            IEnumerable<Organization> organizations = _dataRepository.GetAll();
            return Ok(organizations);
        }


        [HttpGet(Name = "GetOrg")]
        [Route("GetOrganizationById/{organizationId}")]
        public IActionResult GetOrganizationById(long organizationId)
        {
            Organization organization = _dataRepository.Get(organizationId);
            if (organization == null)
            {
                return NotFound("Organization record not found !!!");
            }
            return Ok(organization);
        }


        [HttpPost]
        [Route("InsertOrganization")]
        public IActionResult PostOrganization([FromBody] Organization organization)
        {
            if (organization == null)
            {
                return BadRequest("Organization is null !!!");
            }
            _dataRepository.Add(organization);
            return CreatedAtRoute("GetOrg", new { Id = organization.OrganizationID }, organization);
        }

        [HttpPut]
        [Route("UpdateOrganization/{organizationId}")]
        public IActionResult PutOrganization(long organizationId, [FromBody] Organization organization)
        {
            if (organization == null)
            {
                return BadRequest("Organization is null !!!");
            }
            Organization organizationToUpdate = _dataRepository.Get(organizationId);
            if (organizationToUpdate == null)
            {
                return NotFound("Organization record not found !!!");
            }
            _dataRepository.Update(organizationToUpdate, organization);
            return CreatedAtRoute("GetOrg", new { Id = organization.OrganizationID }, organization);
        }

        [HttpDelete]
        [Route("DeleteOrganization/{organizationId}")]
        public IActionResult DeleteOrganization(long organizationId)
        {
            Organization organization = _dataRepository.Get(organizationId);
            if (organization == null)
            {
                return NotFound("Organization record not found !!!");
            }
            _dataRepository.Delete(organization);
            return GetOrganization();
        }
    }
}