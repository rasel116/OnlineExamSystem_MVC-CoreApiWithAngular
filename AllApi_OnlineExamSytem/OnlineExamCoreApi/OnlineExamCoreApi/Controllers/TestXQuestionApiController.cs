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
    [Route("api/TestXQuestion")]
    [ApiController]
    public class TestXQuestionApiController : ControllerBase
    {
        private readonly IDataAccessRepository<TestXQuestion> _dataRepository;
        public TestXQuestionApiController(IDataAccessRepository<TestXQuestion> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet]
        [Route("GetTestXQuestion")]
        public IActionResult GetTestXQuestion()
        {
            IEnumerable<TestXQuestion> testXPapers = _dataRepository.GetAll();
            return Ok(testXPapers);
        }

        [HttpGet(Name = "GetTxQ")]
        [Route("GetTestXQuestionById/{testXQuestionId}")]
        public IActionResult GetTestXQuestionById(long testXQuestionId)
        {
            TestXQuestion testXQuestion = _dataRepository.Get(testXQuestionId);
            if (testXQuestion == null)
            {
                return NotFound("TestXQuestion record not found !!!");
            }
            return Ok(testXQuestion);
        }
        [HttpPost]
        [Route("InsertTestXQuestion")]
        public IActionResult PostTestXQuestion([FromBody] TestXQuestion testXQuestion)
        {
            if (testXQuestion == null)
            {
                return BadRequest("TestXQuestion is null !!!");
            }
            _dataRepository.Add(testXQuestion);
            return CreatedAtRoute("GetTxQ", new { Id = testXQuestion.TestXQuestionId }, testXQuestion);
        }

        [HttpPut]
        [Route("UpdateTestXQuestion/{testXQuestionId}")]
        public IActionResult PutTestXQuestion(long testXQuestionId, [FromBody] TestXQuestion testXQuestion)
        {
            if (testXQuestion == null)
            {
                return BadRequest("TestXQuestion is null !!!");
            }
            TestXQuestion testXQuestionToUpdate = _dataRepository.Get(testXQuestionId);
            if (testXQuestionToUpdate == null)
            {
                return NotFound("TestXQuestion record not found !!!");
            }
            _dataRepository.Update(testXQuestionToUpdate, testXQuestion);
            return CreatedAtRoute("GetTxQ", new { Id = testXQuestion.TestXQuestionId }, testXQuestion);
        }


        [HttpDelete]
        [Route("DeleteTestXQuestion/{testXQuestionId}")]
        public IActionResult DeleteQuestionXDuration(long testXQuestionId)
        {
            TestXQuestion testXQuestion = _dataRepository.Get(testXQuestionId);
            if (testXQuestion == null)
            {
                return NotFound("TestXQuestion record not found !!!");
            }
            _dataRepository.Delete(testXQuestion);
            return GetTestXQuestion();
        }
    }
}