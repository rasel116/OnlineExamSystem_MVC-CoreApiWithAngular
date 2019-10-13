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
    [RoutePrefix("api/Exhibit")]
    public class ExhibitApiController : ApiController
    {
        private IDataAccessRepository<Exhibit, int> _repo;

        //Inject the DataAccessReposity using Contruction Injection 
        public ExhibitApiController(IDataAccessRepository<Exhibit, int> s)
        {
            _repo = s;
        }

        [HttpGet]
        [Route("GetExhibit", Name = "GetE")]
        public IEnumerable<Exhibit> GetExhibit()
        {
            return _repo.Get();
        }

        [HttpGet]
        [Route("GetExhibitById/{exhibitId}")]
        public IHttpActionResult GetExhibitById(int exhibitId)
        {
            return Ok(_repo.Get(exhibitId));
        }

        [HttpPost]
        [Route("InsertExhibit")]
        public IHttpActionResult PostExhibit(Exhibit exhibit)
        {
            _repo.Post(exhibit);
            return Ok(exhibit);
        }
        [HttpPut]
        [Route("UpdateExhibit/{exhibitId}")]
        public IHttpActionResult PutExhibit(int exhibitId, Exhibit exhibit)
        {
            _repo.Put(exhibitId, exhibit);
            return CreatedAtRoute("GetE", new { id = exhibit.ExhibitId }, exhibit);
        }


        [HttpDelete]
        [Route("DeleteExhibit/{exhibitId}")]
        public IHttpActionResult DeleteExhibit(int exhibitId, Exhibit exhibit)
        {
            _repo.Delete(exhibitId);
            return CreatedAtRoute("GetE", new { id = exhibit.ExhibitId }, exhibit);
        }
    }
}
