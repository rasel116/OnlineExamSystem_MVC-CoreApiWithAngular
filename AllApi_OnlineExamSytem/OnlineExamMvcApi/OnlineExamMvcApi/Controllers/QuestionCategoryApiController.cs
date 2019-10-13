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
    [RoutePrefix("api/QuestionCategory")]
    public class QuestionCategoryApiController : ApiController
    {
        private IDataAccessRepository<QuestionCategory, int> _repo;

        //Inject the DataAccessReposity using Contruction Injection 
        public QuestionCategoryApiController(IDataAccessRepository<QuestionCategory, int> s)
        {
            _repo = s;
        }

        [HttpGet]
        [Route("GetQuestionCategory", Name = "GetQC")]
        public IEnumerable<QuestionCategory> GetQuestionCategory()
        {
            return _repo.Get();
        }

        [HttpGet]
        [Route("GetQuestionCategoryById/{questionCategoryId}")]
        public IHttpActionResult GetQuestionCategoryById(int questionCategoryId)
        {
            return Ok(_repo.Get(questionCategoryId));
        }

        [HttpPost]
        [Route("InsertQuestionCategory")]
        public IHttpActionResult PostQuestionCategory(QuestionCategory questionCategory)
        {
            _repo.Post(questionCategory);
            return Ok(questionCategory);
        }
        [HttpPut]
        [Route("UpdateQuestionCategory/{questionCategoryId}")]
        public IHttpActionResult PutQuestionCategory(int questionCategoryId, QuestionCategory questionCategory)
        {
            _repo.Put(questionCategoryId, questionCategory);
            return CreatedAtRoute("GetQC", new { id = questionCategory.QuestionCategoryId }, questionCategory);
        }


        [HttpDelete]
        [Route("DeleteQuestionCategory/{questionCategoryId}")]
        public IHttpActionResult DeleteQuestionCategory(int questionCategoryId, QuestionCategory questionCategory)
        {
            _repo.Delete(questionCategoryId);
            return CreatedAtRoute("GetQC", new { id = questionCategory.QuestionCategoryId }, questionCategory);
        }
    }
}
