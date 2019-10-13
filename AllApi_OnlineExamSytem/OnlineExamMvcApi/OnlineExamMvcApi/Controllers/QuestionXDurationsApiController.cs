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
    [RoutePrefix("api/QuestionXDuration")]
    public class QuestionXDurationsApiController : ApiController
    {
        private IDataAccessRepository<QuestionXDuration, int> _repo;

        //Inject the DataAccessReposity using Contruction Injection 
        public QuestionXDurationsApiController(IDataAccessRepository<QuestionXDuration, int> qd)
        {
            _repo = qd;
        }

        [HttpGet]
        [Route("GetQuestionXDuration", Name = "GetQD")]
        public IEnumerable<QuestionXDuration> GetQuestionXDuration()
        {
            return _repo.Get();
        }

        [HttpGet]
        [Route("GetQuestionXDurationById/{questionXDurationId}")]
        public IHttpActionResult GetQuestionXDurationById(int questionXDurationId)
        {
            return Ok(_repo.Get(questionXDurationId));
        }

        [HttpPost]
        [Route("InsertQuestionXDuration")]
        public IHttpActionResult PostQuestionXDuration(QuestionXDuration questionXDuration)
        {
            _repo.Post(questionXDuration);
            return Ok(questionXDuration);
        }

        [HttpPut]
        [Route("UpdateQuestionXDuration/{questionXDurationId}")]
        public IHttpActionResult PutQuestionXDuration(int questionXDurationId, QuestionXDuration questionXDuration)
        {
            _repo.Put(questionXDurationId, questionXDuration);
            return CreatedAtRoute("GetQD", new { id = questionXDuration.QuestionXDurationId }, questionXDuration);
        }

        [HttpDelete]
        [Route("DeleteQuestionXDuration/{questionXDurationId}")]
        public IHttpActionResult DeleteQuestionXDuration(int questionXDurationId, QuestionXDuration questionXDuration)
        {
            _repo.Delete(questionXDurationId);
            return CreatedAtRoute("GetQD", new { id = questionXDuration.QuestionXDurationId }, questionXDuration);
        }
    }
}
