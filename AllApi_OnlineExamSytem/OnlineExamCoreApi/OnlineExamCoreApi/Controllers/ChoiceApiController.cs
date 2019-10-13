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
    [Route("api/Choice")]
    [ApiController]
    public class ChoiceApiController : ControllerBase
    {
        private readonly IDataAccessRepository<Choice> _dataRepository;
        public ChoiceApiController(IDataAccessRepository<Choice> dataRepository)
        {
            _dataRepository = dataRepository;
        }


        [HttpGet]
        [Route("GetChoice")]
        public IActionResult GetChoice()
        {
            IEnumerable<Choice> choices = _dataRepository.GetAll();
            return Ok(choices);
        }


        [HttpGet(Name = "GetC")]
        [Route("GetChoiceById/{choiceId}")]
        public IActionResult GetChoiceById(long choiceId)
        {
            Choice choice = _dataRepository.Get(choiceId);
            if (choice == null)
            {
                return NotFound("Choice record not found !!!");
            }
            return Ok(choice);
        }


        [HttpPost]
        [Route("InsertChoice")]
        public IActionResult PostChoice([FromBody] Choice choice)
        {
            if (choice == null)
            {
                return BadRequest("Choice is null !!!");
            }
            _dataRepository.Add(choice);
            return CreatedAtRoute("GetC", new { Id = choice.ChoiceId }, choice);
        }

        [HttpPut]
        [Route("UpdateChoice/{choiceId}")]
        public IActionResult PutChoice(long choiceId, [FromBody] Choice choice)
        {
            if (choice == null)
            {
                return BadRequest("Choice is null !!!");
            }
            Choice choiceToUpdate = _dataRepository.Get(choiceId);
            if (choiceToUpdate == null)
            {
                return NotFound("Choice record not found !!!");
            }
            _dataRepository.Update(choiceToUpdate, choice);
            return CreatedAtRoute("GetC", new { Id = choice.ChoiceId }, choice);
        }

        [HttpDelete]
        [Route("DeleteChoice/{choiceId}")]
        public IActionResult DeleteChoice(long choiceId)
        {
            Choice choice = _dataRepository.Get(choiceId);
            if (choice == null)
            {
                return NotFound("Choice record not found !!!");
            }
            _dataRepository.Delete(choice);
            return GetChoice();
        }


    }
}