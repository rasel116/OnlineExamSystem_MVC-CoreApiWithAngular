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
    [RoutePrefix("api/Test")]
    public class TestApiController : ApiController
    {
        private IDataAccessRepository<Test, int> _repo;

        //Inject the DataAccessReposity using Contruction Injection 
        public TestApiController(IDataAccessRepository<Test, int> t)
        {
            _repo = t;
        }

        [HttpGet]
        [Route("GetTest", Name = "GetT")]
        public IEnumerable<Test> GetTest()
        {
            return _repo.Get();
        }

        [HttpGet]
        [Route("GetTestById/{testId}")]
        public IHttpActionResult GetTestById(int testId)
        {
            return Ok(_repo.Get(testId));
        }

        [HttpPost]
        [Route("InsertTest")]
        public IHttpActionResult PostTest(Test test)
        {
            _repo.Post(test);
            return Ok(test);
        }

        [HttpPut]
        [Route("UpdateTest/{testId}")]
        public IHttpActionResult PutTest(int testId, Test test)
        {
            _repo.Put(testId, test);
            return CreatedAtRoute("GetT", new { id = test.TestId }, test);
        }


        [HttpDelete]
        [Route("DeleteTest/{testId}")]
        public IHttpActionResult DeleteTest(int testId, Test test)
        {
            _repo.Delete(testId);
            return CreatedAtRoute("GetT", new { id = test.TestId }, test);
        }
    }
}
