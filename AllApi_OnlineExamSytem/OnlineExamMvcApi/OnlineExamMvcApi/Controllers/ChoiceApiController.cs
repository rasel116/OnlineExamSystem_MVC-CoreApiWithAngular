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
    [RoutePrefix("api/Choice")]
    public class ChoiceApiController : ApiController
    {
        private IDataAccessRepository<Choice, int> _repo;

        //Inject the DataAccessReposity using Contruction Injection 
        public ChoiceApiController(IDataAccessRepository<Choice, int> c)
        {
            _repo = c;
        }

        [HttpGet]
        [Route("GetChoice", Name = "GetC")]
        public IEnumerable<Choice> GetChoice()
        {

            return _repo.Get();


        }

        [HttpGet]
        [Route("GetChoiceById/{choiceId}")]
        public IHttpActionResult GetChoiceById(int choiceId)
        {
            return Ok(_repo.Get(choiceId));
        }

        [HttpPost]
        [Route("InsertChoice")]
        public IHttpActionResult PostChoice(Choice choice)
        {
            _repo.Post(choice);
            return Ok(choice);
        }

        [HttpPut]
        [Route("UpdateChoice/{choiceId}")]
        public IHttpActionResult PutChoice(int choiceId, Choice choice)
        {
            _repo.Put(choiceId, choice);
            return CreatedAtRoute("GetC", new { id = choice.ChoiceId }, choice);
        }


        [HttpDelete]
        [Route("DeleteChoice/{choiceId}")]
        public IHttpActionResult DeleteChoice(int choiceId, Choice choice)
        {

            _repo.Delete(choiceId);
            return CreatedAtRoute("GetC", new { id = choice.ChoiceId }, choice);
        }
    }
}
