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
    [Route("api/QuestionCategory")]
    [ApiController]
    public class QuestionCategoryApiController : ControllerBase
    {
        private readonly IDataAccessRepository<QuestionCategory> _dataRepository;
        public QuestionCategoryApiController(IDataAccessRepository<QuestionCategory> dataRepository)
        {
            _dataRepository = dataRepository;
        }
        [HttpGet]
        [Route("GetQuestionCategory")]
        public IActionResult GetQuestionCategory()
        {
            IEnumerable<QuestionCategory> questionCategories = _dataRepository.GetAll();
            return Ok(questionCategories);
        }

        [HttpGet(Name = "GetQCat")]
        [Route("GetQuestionCategoryById/{questionCategoryId}")]
        public IActionResult GetQuestionCategoryById(long questionCategoryId)
        {
            QuestionCategory questionCategory = _dataRepository.Get(questionCategoryId);
            if (questionCategory == null)
            {
                return NotFound("QuestionCategory record not found !!!");
            }
            return Ok(questionCategory);
        }
        [HttpPost]
        [Route("InsertQuestionCategory")]
        public IActionResult PostQuestionCategory([FromBody] QuestionCategory questionCategory)
        {
            if (questionCategory == null)
            {
                return BadRequest("QuestionCategory is null !!!");
            }
            _dataRepository.Add(questionCategory);
            return CreatedAtRoute("GetQCat", new { Id = questionCategory.QuestionCategoryId }, questionCategory);
        }

        [HttpPut]
        [Route("UpdateQuestionCategory/{questionCategoryId}")]
        public IActionResult PutQuestionCategory(long questionCategoryId, [FromBody] QuestionCategory questionCategory)
        {
            if (questionCategory == null)
            {
                return BadRequest("QuestionCategory is null !!!");
            }
            QuestionCategory questionCategoryToUpdate = _dataRepository.Get(questionCategoryId);
            if (questionCategoryToUpdate == null)
            {
                return NotFound("QuestionCategory record not found !!!");
            }
            _dataRepository.Update(questionCategoryToUpdate, questionCategory);
            return CreatedAtRoute("GetQCat", new { Id = questionCategory.QuestionCategoryId }, questionCategory);
        }


        [HttpDelete]
        [Route("DeleteQuestionCategory/{questionCategoryId}")]
        public IActionResult DeleteQuestionCategory(long questionCategoryId)
        {
            QuestionCategory questionCategory = _dataRepository.Get(questionCategoryId);
            if (questionCategory == null)
            {
                return NotFound("QuestionCategory record not found !!!");
            }
            _dataRepository.Delete(questionCategory);
            return GetQuestionCategory();
        }
    }
}