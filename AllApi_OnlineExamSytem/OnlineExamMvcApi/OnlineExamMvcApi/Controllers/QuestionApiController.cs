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
    [RoutePrefix("api/Question")]
    public class QuestionApiController : ApiController
    {
        private IDataAccessRepository<Question, int> _repo;

        //Inject the DataAccessReposity using Contruction Injection 

        public QuestionApiController(IDataAccessRepository<Question, int> q)
        {
            _repo = q;
        }


        [HttpGet]
        [Route("GetQuestion", Name = "GetQ")]
        public IEnumerable<Question> GetQuestion()
        {
            return _repo.Get();
        }

        [HttpGet]
        [Route("GetQuestionById/{questionId}")]
        public IHttpActionResult GetQuestionById(int questionId)
        {
            return Ok(_repo.Get(questionId));
        }

        [HttpPost]
        [Route("InsertQuestion")]
        public IHttpActionResult PostQuestion(Question question)
        {
            _repo.Post(question);
            return Ok(question);
        }

        [HttpPut]
        [Route("UpdateQuestion/{questionId}")]
        public IHttpActionResult PutQuestion(int questionId, Question question)
        {
            _repo.Put(questionId, question);
            return CreatedAtRoute("GetQ", new { id = question.QuestionId }, question);
        }


        [HttpDelete]
        [Route("DeleteQuestion/{questionId}")]
        public IHttpActionResult DeleteQuestion(int questionId, Question question)
        {
            _repo.Delete(questionId);
            return CreatedAtRoute("GetQ", new { id = question.QuestionId }, question);
        }
    }
}
