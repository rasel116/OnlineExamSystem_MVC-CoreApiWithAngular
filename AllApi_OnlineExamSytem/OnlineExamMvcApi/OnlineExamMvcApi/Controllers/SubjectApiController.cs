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
    [RoutePrefix("api/Subject")]
    public class SubjectApiController : ApiController
    {
        private IDataAccessRepository<Subject, int> _repo;

        //Inject the DataAccessReposity using Contruction Injection 
        public SubjectApiController(IDataAccessRepository<Subject, int> s)
        {
            _repo = s;
        }

        [HttpGet]
        [Route("GetSubject", Name = "GetS")]
        public IEnumerable<Subject> GetSubject()
        {
            return _repo.Get();
        }

        [HttpGet]
        [Route("GetSubjectById/{subjectId}")]
        public IHttpActionResult GetSubjectById(int subjectId)
        {
            return Ok(_repo.Get(subjectId));
        }

        [HttpPost]
        [Route("InsertSubject")]
        public IHttpActionResult PostSubject(Subject subject)
        {
            _repo.Post(subject);
            return Ok(subject);
        }
        [HttpPut]
        [Route("UpdateSubject/{subjectId}")]
        public IHttpActionResult PutExhibit(int subjectId, Subject subject)
        {
            _repo.Put(subjectId, subject);
            return CreatedAtRoute("GetS", new { id = subject.SubjectID }, subject);
        }


        [HttpDelete]
        [Route("DeleteSubject/{subjectId}")]
        public IHttpActionResult DeleteSubject(int subjectId, Subject subject)
        {
            _repo.Delete(subjectId);
            return CreatedAtRoute("GetS", new { id = subject.SubjectID }, subject);
        }
    }
}
