using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

//Add 
using OnlineExamMvcApi.Models;
using OnlineExamMvcApi.Models.Repository;
using System.Web.Http.Description;

namespace OnlineExamMvcApi.Controllers
{
    [RoutePrefix("api/Registration")]
    public class RegistrationApiController : ApiController
    {
        private IDataAccessRepository<Registration, int> _repo;

        //Inject the DataAccessReposity using Contruction Injection 
        public RegistrationApiController(IDataAccessRepository<Registration, int> r)
        {
            _repo = r;
        }

        [HttpGet]
        [Route("GetRegistration", Name = "GetR")]
        public IEnumerable<Registration> GetRegistration()
        {
            return _repo.Get();
        }

        [HttpGet]
        [Route("GetRegistrationById/{registrationId}")]
        public IHttpActionResult GetRegistrationById(int registrationId)
        {
            return Ok(_repo.Get(registrationId));
        }

        [HttpPost]
        [Route("InsertRegistration")]
        public IHttpActionResult PostRegistration(Registration registration)
        {
            _repo.Post(registration);
            return Ok(registration);
        }
        [HttpPut]
        [Route("UpdateRegistration/{registrationId}")]
        public IHttpActionResult PutRegistration(int registrationId, Registration registration)
        {
            _repo.Put(registrationId, registration);
            return CreatedAtRoute("GetR", new { id = registration.RegistrationId }, registration);
        }


        [HttpDelete]
        [Route("DeleteRegistration/{registrationId}")]
        public IHttpActionResult DeleteRegistration(int registrationId, Registration registration)
        {
            _repo.Delete(registrationId);
            return CreatedAtRoute("GetR", new { id = registration.RegistrationId }, registration);
        }
    }
}
