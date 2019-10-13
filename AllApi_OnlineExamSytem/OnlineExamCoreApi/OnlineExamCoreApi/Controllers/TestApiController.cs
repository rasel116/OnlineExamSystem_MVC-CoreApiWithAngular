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
    [Route("api/Test")]
    [ApiController]
    public class TestApiController : ControllerBase
    {
        private readonly IDataAccessRepository<Test> _dataRepository;
        public TestApiController(IDataAccessRepository<Test> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet]
        [Route("GetTest")]
        public IActionResult GetTest()
        {
            IEnumerable<Test> registration = _dataRepository.GetAll();
            return Ok(registration);
        }


        [HttpGet(Name = "GetT")]
        [Route("GetTestById/{testId}")]
        public IActionResult GetTestById(long testId)
        {
            Test test = _dataRepository.Get(testId);
            if (test == null)
            {
                return NotFound("Test record not found !!!");
            }
            return Ok(test);
        }


        [HttpPost]
        [Route("InsertTest")]
        public IActionResult PostTest([FromBody] Test test)
        {
            if (test == null)
            {
                return BadRequest("Test is null !!!");
            }
            _dataRepository.Add(test);
            return CreatedAtRoute("GetT", new { Id = test.TestId }, test);
        }

        [HttpPut]
        [Route("UpdateTest/{testId}")]
        public IActionResult PutTest(long testId, [FromBody] Test test)
        {
            if (test == null)
            {
                return BadRequest("Test is null !!!");
            }
            Test testToUpdate = _dataRepository.Get(testId);
            if (testToUpdate == null)
            {
                return NotFound("Test record not found !!!");
            }
            _dataRepository.Update(testToUpdate, test);
            return CreatedAtRoute("GetT", new { Id = test.TestId }, test);
        }

        [HttpDelete]
        [Route("DeleteTest/{testId}")]
        public IActionResult DeleteTest(long testId)
        {
            Test test = _dataRepository.Get(testId);
            if (test == null)
            {
                return NotFound("Test record not found !!!");
            }
            _dataRepository.Delete(test);
            return GetTest();
        }
    }
}