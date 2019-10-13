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
    [Route("api/QuestionXDuration")]
    [ApiController]
    public class QuestionXDurationaApiController : ControllerBase
    {
        private readonly IDataAccessRepository<QuestionXDuration> _dataRepository;
        public QuestionXDurationaApiController(IDataAccessRepository<QuestionXDuration> dataRepository)
        {
            _dataRepository = dataRepository;
        }
        [HttpGet]
        [Route("GetQuestionXDuration")]
        public IActionResult GetQuestionXDuration()
        {
            IEnumerable<QuestionXDuration> questionXDurations = _dataRepository.GetAll();
            return Ok(questionXDurations);
        }

        [HttpGet(Name = "GetQxD")]
        [Route("GetQuestionXDurationById/{questionXDurationId}")]
        public IActionResult GetQuestionXDurationById(long questionXDurationId)
        {
            QuestionXDuration questionX = _dataRepository.Get(questionXDurationId);
            if (questionX == null)
            {
                return NotFound("QuestionXDuration record not found !!!");
            }
            return Ok(questionX);
        }
        [HttpPost]
        [Route("InsertQuestionXDuration")]
        public IActionResult PostQuestionXDuration([FromBody] QuestionXDuration questionX)
        {
            if (questionX == null)
            {
                return BadRequest("QuestionXDuration is null !!!");
            }
            _dataRepository.Add(questionX);
            return CreatedAtRoute("GetQxD", new { Id = questionX.QuestionXDurationId }, questionX);
        }

        [HttpPut]
        [Route("UpdateQuestionCategory/{questionXDurationId}")]
        public IActionResult PutQuestionCategory(long questionXDurationId, [FromBody] QuestionXDuration questionX)
        {
            if (questionX == null)
            {
                return BadRequest("QuestionXDuration is null !!!");
            }
            QuestionXDuration questionXDurationToUpdate = _dataRepository.Get(questionXDurationId);
            if (questionXDurationToUpdate == null)
            {
                return NotFound("QuestionCategory record not found !!!");
            }
            _dataRepository.Update(questionXDurationToUpdate, questionX);
            return CreatedAtRoute("GetQxD", new { Id = questionX.QuestionXDurationId }, questionX);
        }


        [HttpDelete]
        [Route("DeleteQuestionXDuration/{questionXDurationId}")]
        public IActionResult DeleteQuestionXDuration(long questionXDurationId)
        {
            QuestionXDuration questionX = _dataRepository.Get(questionXDurationId);
            if (questionX == null)
            {
                return NotFound("QuestionXDuration record not found !!!");
            }
            _dataRepository.Delete(questionX);
            return GetQuestionXDuration();
        }
    }
}