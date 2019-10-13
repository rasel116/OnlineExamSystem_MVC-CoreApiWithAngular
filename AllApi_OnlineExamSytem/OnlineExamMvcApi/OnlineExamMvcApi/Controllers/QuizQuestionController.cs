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
    [RoutePrefix("api/QuizQuesMake")]
    public class QuizQuestionController : ApiController
    {
        private IDataAccessRepository<QuizQuestion, int> _repo;

        //Inject the DataAccessReposity using Contruction Injection 
        public QuizQuestionController(IDataAccessRepository<QuizQuestion, int> qq)
        {
            _repo = qq;
        }

        [HttpGet]
        [Route("GetQuizQuesMake", Name = "GetQQ")]
        public IEnumerable<QuizQuestion> GetQuizQuesMake()
        {
            return _repo.Get();
        }

        [HttpGet]
        [Route("GetQuizQuesMakeById/{quizQuesMakeId}")]
        public IHttpActionResult GetQuizQuesMakeById(int quizQuesMakeId)
        {
            return Ok(_repo.Get(quizQuesMakeId));
        }

        [HttpPost]
        [Route("InsertQuizQuesMake")]
        public IHttpActionResult PostQuizQuesMake(QuizQuestion quizQuestion)
        {
            _repo.Post(quizQuestion);
            return Ok(quizQuestion);
        }
        [HttpPut]
        [Route("UpdateQuizQuesMake/{quizQuesMakeId}")]
        public IHttpActionResult PutQuizQuesMake(int quizQuesMakeId, QuizQuestion quizQuestion)
        {
            _repo.Put(quizQuesMakeId, quizQuestion);
            return CreatedAtRoute("GetQQ", new { id = quizQuestion.QuizQuestionID }, quizQuestion);
        }


        [HttpDelete]
        [Route("DeleteQuizQuesMake/{quizQuesMakeId}")]
        public IHttpActionResult DeleteQuizQuesMake(int quizQuesMakeId, QuizQuestion quizQuestion)
        {
            _repo.Delete(quizQuesMakeId);
            return CreatedAtRoute("GetQQ", new { id = quizQuestion.QuizQuestionID }, quizQuestion);
        }
    }
}
