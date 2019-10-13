using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


//Add New
using OnlineExamCoreApi.Models;
using OnlineExamCoreApi.Models.Repository;

namespace OnlineExamCoreApi.Controllers
{
    [Route("api/Registration")]
    [ApiController]
    public class RegistrationApiController : ControllerBase
    {
        private readonly IDataAccessRepository<Registration> _dataRepository;

        public RegistrationApiController(IDataAccessRepository<Registration> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet]
        [Route("GetRegistration")]
        public IActionResult GetRegistration()
        {
            IEnumerable<Registration> registration = _dataRepository.GetAll();
            return Ok(registration);
        }


        [HttpGet(Name = "GetR")]
        [Route("GetRegistrationById/{registrationId}")]
        public IActionResult GetRegistrationById(long registrationId)
        {
            Registration registration = _dataRepository.Get(registrationId);
            if (registration == null)
            {
                return NotFound("Registration record not found !!!");
            }
            return Ok(registration);
        }


        [HttpPost]
        [Route("InsertRegistration")]
        public IActionResult PostRegistration([FromBody] Registration registration)
        {
            if (registration == null)
            {
                return BadRequest("Registration is null !!!");
            }
            _dataRepository.Add(registration);
            return CreatedAtRoute("GetR", new { Id = registration.RegistrationId }, registration);
        }

        [HttpPut]
        [Route("UpdateRegistration/{registrationId}")]
        public IActionResult PutRegistration(long registrationId, [FromBody] Registration registration)
        {
            if (registration == null)
            {
                return BadRequest("Registration is null !!!");
            }
            Registration registrationToUpdate = _dataRepository.Get(registrationId);
            if (registrationToUpdate == null)
            {
                return NotFound("Registration record not found !!!");
            }
            _dataRepository.Update(registrationToUpdate, registration);
            return CreatedAtRoute("GetR", new { Id = registration.RegistrationId }, registration);
        }

        [HttpDelete]
        [Route("DeleteRegistration/{registrationId}")]
        public IActionResult DeleteRegistration(long registrationId)
        {
            Registration registration = _dataRepository.Get(registrationId);
            if (registration == null)
            {
                return NotFound("Registration record not found !!!");
            }
            _dataRepository.Delete(registration);
            return GetRegistration();
        }
    }
}