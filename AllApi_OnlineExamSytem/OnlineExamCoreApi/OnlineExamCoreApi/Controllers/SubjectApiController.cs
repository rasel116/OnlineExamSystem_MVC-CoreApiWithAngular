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
    [Route("api/Subject")]
    [ApiController]
    public class SubjectApiController : ControllerBase
    {
        private readonly IDataAccessRepository<Subject> _dataRepository;
        public SubjectApiController(IDataAccessRepository<Subject> dataRepository)
        {
            _dataRepository = dataRepository;
        }


        [HttpGet]
        [Route("GetSubject")]
        public IActionResult GetSubject()
        {
            IEnumerable<Subject> subjects = _dataRepository.GetAll();
            return Ok(subjects);
        }


        [HttpGet(Name = "GetSub")]
        [Route("GetSubjectById/{subjectId}")]
        public IActionResult GetSubjectById(long subjectId)
        {
            Subject subject = _dataRepository.Get(subjectId);
            if (subject == null)
            {
                return NotFound("Subject record not found !!!");
            }
            return Ok(subject);
        }


        [HttpPost]
        [Route("InsertSubject")]
        public IActionResult PostSubject([FromBody] Subject subject)
        {
            if (subject == null)
            {
                return BadRequest("Subject is null !!!");
            }
            _dataRepository.Add(subject);
            return CreatedAtRoute("GetSub", new { Id = subject.SubjectID }, subject);
        }

        [HttpPut]
        [Route("UpdateSubject/{subjectId}")]
        public IActionResult PutSubject(long subjectId, [FromBody] Subject subject)
        {
            if (subject == null)
            {
                return BadRequest("Subject is null !!!");
            }
            Subject subjectToUpdate = _dataRepository.Get(subjectId);
            if (subjectToUpdate == null)
            {
                return NotFound("Subject record not found !!!");
            }
            _dataRepository.Update(subjectToUpdate, subject);
            return CreatedAtRoute("GetSub", new { Id = subject.SubjectID }, subject);
        }

        [HttpDelete]
        [Route("DeleteSubject/{subjectId}")]
        public IActionResult DeleteSubject(long subjectId)
        {
            Subject subject = _dataRepository.Get(subjectId);
            if (subject == null)
            {
                return NotFound("Subject record not found !!!");
            }
            _dataRepository.Delete(subject);
            return GetSubject();
        }
    }
}