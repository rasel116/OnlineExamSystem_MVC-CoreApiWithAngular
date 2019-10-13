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
    [RoutePrefix("api/TestXQuestion")]
    public class TestXQuestionApiController : ApiController
    {
        private IDataAccessRepository<TestXQuestion, int> _repo;

        //Inject the DataAccessReposity using Contruction Injection 
        public TestXQuestionApiController(IDataAccessRepository<TestXQuestion, int> tq)
        {
            _repo = tq;
        }

        [HttpGet]
        [Route("GetTestXQuestion", Name = "GetTQ")]
        public IEnumerable<TestXQuestion> GetTestXQuestion()
        {
            return _repo.Get();
        }

        [HttpGet]
        [Route("GetTestXQuestionById/{testXQuestionId}")]
        public IHttpActionResult GetTestXQuestionById(int testXQuestionId)
        {
            return Ok(_repo.Get(testXQuestionId));
        }

        [HttpPost]
        [Route("InsertTestXQuestion")]
        public IHttpActionResult PostTestXQuestion(TestXQuestion testXQuestion)
        {
            _repo.Post(testXQuestion);
            return Ok(testXQuestion);
        }

        [HttpPut]
        [Route("UpdateTestXQuestion/{testXQuestionId}")]
        public IHttpActionResult PutTestXQuestion(int testXQuestionId, TestXQuestion testXQuestion)
        {
            _repo.Put(testXQuestionId, testXQuestion);
            return CreatedAtRoute("GetTQ", new { id = testXQuestion.TestXQuestionId }, testXQuestion);
        }


        [HttpDelete]
        [Route("DeleteTestXQuestion/{testXQuestionId}")]
        public IHttpActionResult DeleteTestXQuestion(int testXQuestionId, TestXQuestion testXQuestion)
        {
            _repo.Delete(testXQuestionId);
            return CreatedAtRoute("GetTQ", new { id = testXQuestion.TestXQuestionId }, testXQuestion);
        }
    }
}
