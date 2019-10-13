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
    [Route("api/Teacher")]
    [ApiController]
    public class TeacherApiController : ControllerBase
    {
        private readonly IDataAccessRepository<Teacher> _dataRepository;

        public TeacherApiController(IDataAccessRepository<Teacher> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet]
        [Route("GetTeacher")]
        public IActionResult GetTeacher()
        {
            IEnumerable<Teacher> teacher = _dataRepository.GetAll();
            return Ok(teacher);
        }

        [HttpGet(Name = "GetTeach")]
        [Route("GetTeacherById/{teacherId}")]
        public IActionResult GetTeacherById(long teacherId)
        {
            Teacher teacher = _dataRepository.Get(teacherId);
            if (teacher == null)
            {
                return NotFound("Teacher record not found !!!");
            }
            return Ok(teacher);
        }

        [HttpPost]
        [Route("InsertTeacher")]
        public IActionResult PostTeacher([FromBody] Teacher teacher)
        {
            if (teacher == null)
            {
                return BadRequest("Teacher is null !!!");
            }
            _dataRepository.Add(teacher);
            return CreatedAtRoute("GetTeach", new { Id = teacher.TeacherID }, teacher);
        }

        [HttpPut]
        [Route("UpdateTeacher/{teacherId}")]
        public IActionResult PutTeacher(long teacherId, [FromBody] Teacher teacher)
        {
            if (teacher == null)
            {
                return BadRequest("Teacher is null !!!");
            }
            Teacher teacherToUpdate = _dataRepository.Get(teacherId);
            if (teacherToUpdate == null)
            {
                return NotFound("Teacher record not found !!!");
            }
            _dataRepository.Update(teacherToUpdate, teacher);
            return CreatedAtRoute("GetTeach", new { Id = teacher.TeacherID }, teacher);
        }

        [HttpDelete]
        [Route("DeleteTeacher/{teacherId}")]
        public IActionResult DeleteTeacher(long teacherId)
        {
            Teacher teacher = _dataRepository.Get(teacherId);
            if (teacher == null)
            {
                return NotFound("Student record not found !!!");
            }
            _dataRepository.Delete(teacher);
            return GetTeacher();
        }
    }
}