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
    [Route("api/Student")]
    [ApiController]
    public class StudentApiController : ControllerBase
    {
        private readonly IDataAccessRepository<Student> _dataRepository;

        public StudentApiController(IDataAccessRepository<Student> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet]
        [Route("GetStudent")]
        public IActionResult GetStudent()
        {
            IEnumerable<Student> trainees = _dataRepository.GetAll();
            return Ok(trainees);
        }


        [HttpGet(Name = "GetS")]
        [Route("GetStudentById/{studentId}")]
        public IActionResult GetStudentById(long studentId)
        {
            Student student = _dataRepository.Get(studentId);
            if (student == null)
            {
                return NotFound("Student record not found !!!");
            }
            return Ok(student);
        }


        [HttpPost]
        [Route("InsertStudent")]
        public IActionResult PostStudent([FromBody] Student student)
        {
            if (student == null)
            {
                return BadRequest("Student is null !!!");
            }
            _dataRepository.Add(student);
            return CreatedAtRoute("GetS", new { Id = student.StudentId }, student);
        }

        [HttpPut]
        [Route("UpdateStudent/{studentId}")]
        public IActionResult PutStudent(long studentId, [FromBody] Student student)
        {
            if (student == null)
            {
                return BadRequest("Trainee is null !!!");
            }
            Student studentToUpdate = _dataRepository.Get(studentId);
            if (studentToUpdate == null)
            {
                return NotFound("Student record not found !!!");
            }
            _dataRepository.Update(studentToUpdate, student);
            return CreatedAtRoute("GetS", new { Id = student.StudentId }, student);
        }

        [HttpDelete]
        [Route("DeleteStudent/{studentId}")]
        public IActionResult DeleteStudent(long studentId)
        {
            Student student = _dataRepository.Get(studentId);
            if (student == null)
            {
                return NotFound("Student record not found !!!");
            }
            _dataRepository.Delete(student);
            return GetStudent();
        }
    }
}