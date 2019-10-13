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
    [Route("api/TestXPaper")]
    [ApiController]
    public class TestXPaperController : ControllerBase
    {
        private readonly IDataAccessRepository<TestXPaper> _dataRepository;
        public TestXPaperController(IDataAccessRepository<TestXPaper> dataRepository)
        {
            _dataRepository = dataRepository;
        }
        [HttpGet]
        [Route("GetTestXPaper")]
        public IActionResult GetTestXPaper()
        {
            IEnumerable<TestXPaper> testXPapers = _dataRepository.GetAll();
            return Ok(testXPapers);
        }

        [HttpGet(Name = "GetTestX")]
        [Route("GetTestXPaperById/{testXPaperId}")]
        public IActionResult GetTestXPaperById(long testXPaperId)
        {
            TestXPaper testXPaper = _dataRepository.Get(testXPaperId);
            if (testXPaper == null)
            {
                return NotFound("TestXPaper record not found !!!");
            }
            return Ok(testXPaper);
        }
        [HttpPost]
        [Route("InsertTestXPaper")]
        public IActionResult PostTestXPaper([FromBody] TestXPaper testXPaper)
        {
            if (testXPaper == null)
            {
                return BadRequest("TestXPaper is null !!!");
            }
            _dataRepository.Add(testXPaper);
            return CreatedAtRoute("GetTestX", new { Id = testXPaper.TestXPaperId }, testXPaper);
        }

        [HttpPut]
        [Route("UpdateTestXPaper/{testXPaperId}")]
        public IActionResult PutTestXPaper(long testXPaperId, [FromBody] TestXPaper testXPaper)
        {
            if (testXPaper == null)
            {
                return BadRequest("TestXPaper is null !!!");
            }
            TestXPaper testXPaperToUpdate = _dataRepository.Get(testXPaperId);
            if (testXPaperToUpdate == null)
            {
                return NotFound("QuestionCategory record not found !!!");
            }
            _dataRepository.Update(testXPaperToUpdate, testXPaper);
            return CreatedAtRoute("GetTestX", new { Id = testXPaper.TestXPaperId }, testXPaper);
        }


        [HttpDelete]
        [Route("DeleteTestXPaper/{testXPaperId}")]
        public IActionResult DeleteTestXPaper(long testXPaperId)
        {
            TestXPaper testXPaper = _dataRepository.Get(testXPaperId);
            if (testXPaper == null)
            {
                return NotFound("TestXPaper record not found !!!");
            }
            _dataRepository.Delete(testXPaper);
            return GetTestXPaper();
        }
    }
}