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
    [RoutePrefix("api/Student")]
    public class StudentApiController : ApiController
    {
        private IDataAccessRepository<Student, int> _repo;

        //Inject the DataAccessReposity using Contruction Injection 
        public StudentApiController(IDataAccessRepository<Student, int> s)
        {
            _repo = s;
        }

        [HttpGet]
        [Route("GetStudent", Name = "Get")]
        public IEnumerable<Student> GetStudent()
        {
            return _repo.Get();
        }

        [HttpGet]
        [Route("GetStudentById/{studentId}")]
        public IHttpActionResult GetStudentById(int studentId)
        {
            return Ok(_repo.Get(studentId));
        }

        [HttpPost]
        [Route("InsertStudent")]
        public IHttpActionResult PostStudent(Student student)
        {
            _repo.Post(student);
            return Ok(student);
        }
        [HttpPut]
        [Route("UpdateStudent/{studentId}")]
        public IHttpActionResult PutStudent(int studentId, Student student)
        {
            _repo.Put(studentId, student);
            return CreatedAtRoute("Get", new { id = student.StudentId }, student);
        }


        [HttpDelete]
        [Route("DeleteStudent/{studentId}")]
        public IHttpActionResult DeleteStudent(int studentId, Student student)
        {
            _repo.Delete(studentId);
            return CreatedAtRoute("Get", new { id = student.StudentId }, student);
        }
    }
}
