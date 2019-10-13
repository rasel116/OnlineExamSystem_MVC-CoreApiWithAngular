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
    [RoutePrefix("api/TestXPaper")]
    public class TestXPaperApiController : ApiController
    {
        private IDataAccessRepository<TestXPaper, int> _repo;

        //Inject the DataAccessReposity using Contruction Injection 
        public TestXPaperApiController(IDataAccessRepository<TestXPaper, int> tp)
        {
            _repo = tp;
        }

        [HttpGet]
        [Route("GetTestXPaper", Name = "GetTp")]
        public IEnumerable<TestXPaper> GetTestXPaper()
        {
            return _repo.Get();
        }

        [HttpGet]
        [Route("GetTestXPaperById/{testXPaperId}")]
        public IHttpActionResult GetTestXPaperById(int testXPaperId)
        {
            return Ok(_repo.Get(testXPaperId));
        }

        [HttpPost]
        [Route("InsertTestXPaper")]
        public IHttpActionResult PostTestXPaper(TestXPaper testXPaper)
        {
            _repo.Post(testXPaper);
            return Ok(testXPaper);
        }

        [HttpPut]
        [Route("UpdateTestXPaper/{testXPaperId}")]
        public IHttpActionResult PutTestXPaper(int testXPaperId, TestXPaper testXPaper)
        {
            _repo.Put(testXPaperId, testXPaper);
            return CreatedAtRoute("GetT", new { id = testXPaper.TestXPaperId }, testXPaper);
        }


        [HttpDelete]
        [Route("DeleteTestXPaper/{testXPaperId}")]
        public IHttpActionResult DeleteTestXPaper(int testXPaperId, TestXPaper testXPaper)
        {
            _repo.Delete(testXPaperId);
            return CreatedAtRoute("GetT", new { id = testXPaper.TestXPaperId }, testXPaper);
        }
    }
}
