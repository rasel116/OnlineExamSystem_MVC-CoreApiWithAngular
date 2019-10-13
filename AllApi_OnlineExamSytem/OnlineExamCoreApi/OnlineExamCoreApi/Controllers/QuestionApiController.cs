using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

//Add New
using OnlineExamCoreApi.Models;
using OnlineExamCoreApi.Models.Repository;

namespace OnlineExamCoreApi.Controllers
{
    [Route("api/Question")]
    [ApiController]
    public class QuestionApiController : ControllerBase
    {
        private readonly IDataAccessRepository<Question> _dataRepository;
        public QuestionApiController(IDataAccessRepository<Question> dataRepository)
        {
            _dataRepository = dataRepository;
        }
        [HttpGet]
        [Route("GetQuestion")]
        public IActionResult GetQuestion()
        {
            IEnumerable<Question> questions = _dataRepository.GetAll();
            return Ok(questions);
        }


        [HttpGet(Name = "GetQ")]
        [Route("GetQuestionById/{questionId}")]
        public IActionResult GetQuestionById(long questionId)
        {
            Question question = _dataRepository.Get(questionId);
            if (question == null)
            {
                return NotFound("Question record not found !!!");
            }
            return Ok(question);
        }


        [HttpPost]
        [Route("InsertQuestion")]
        public IActionResult PostQuestion([FromBody] Question question)
        {
            if (question == null)
            {
                return BadRequest("Question is null !!!");
            }
            _dataRepository.Add(question);
            return CreatedAtRoute("GetQ", new { Id = question.QuestionId }, question);
        }

        [HttpPut]
        [Route("UpdateQuestion/{questionId}")]
        public IActionResult PutQuestion(long questionId, [FromBody] Question question)
        {
            if (question == null)
            {
                return BadRequest("Question is null !!!");
            }
            Question questionToUpdate = _dataRepository.Get(questionId);
            if (questionToUpdate == null)
            {
                return NotFound("Question record not found !!!");
            }
            _dataRepository.Update(questionToUpdate, question);
            return CreatedAtRoute("GetQ", new { Id = question.QuestionId }, question);
        }

        [HttpDelete]
        [Route("DeleteQuestion/{questionId}")]
        public IActionResult DeleteQuestion(long questionId)
        {
            Question question = _dataRepository.Get(questionId);
            if (question == null)
            {
                return NotFound("Question record not found !!!");
            }
            _dataRepository.Delete(question);
            return GetQuestion();
        }

    }
}