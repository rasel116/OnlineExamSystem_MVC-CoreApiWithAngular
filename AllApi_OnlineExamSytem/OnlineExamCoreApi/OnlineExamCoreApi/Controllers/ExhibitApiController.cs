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
    [Route("api/Exhibit")]
    [ApiController]
    public class ExhibitApiController : ControllerBase
    {
        private readonly IDataAccessRepository<Exhibit> _dataRepository;
        public ExhibitApiController(IDataAccessRepository<Exhibit> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet]
        [Route("GetExhibit")]
        public IActionResult GetExhibit()
        {
            IEnumerable<Exhibit> exhibits = _dataRepository.GetAll();
            return Ok(exhibits);
        }


        [HttpGet(Name = "GetExh")]
        [Route("GetExhibitById/{exhibitId}")]
        public IActionResult GetExhibitById(long exhibitId)
        {
            Exhibit exhibit = _dataRepository.Get(exhibitId);
            if (exhibit == null)
            {
                return NotFound("Exhibit record not found !!!");
            }
            return Ok(exhibit);
        }


        [HttpPost]
        [Route("InsertExhibit")]
        public IActionResult PostExhibit([FromBody] Exhibit exhibit)
        {
            if (exhibit == null)
            {
                return BadRequest("Exhibit is null !!!");
            }
            _dataRepository.Add(exhibit);
            return CreatedAtRoute("GetExh", new { Id = exhibit.ExhibitId }, exhibit);
        }

        [HttpPut]
        [Route("UpdateExhibit/{exhibitId}")]
        public IActionResult PutExhibit(long exhibitId, [FromBody] Exhibit exhibit)
        {
            if (exhibit == null)
            {
                return BadRequest("Test is null !!!");
            }
            Exhibit exhibitToUpdate = _dataRepository.Get(exhibitId);
            if (exhibitToUpdate == null)
            {
                return NotFound("Exhibit record not found !!!");
            }
            _dataRepository.Update(exhibitToUpdate, exhibit);
            return CreatedAtRoute("GetExh", new { Id = exhibit.ExhibitId }, exhibit);
        }

        [HttpDelete]
        [Route("DeleteExhibit/{exhibitId}")]
        public IActionResult DeleteExhibit(long exhibitId)
        {
            Exhibit exhibit = _dataRepository.Get(exhibitId);
            if (exhibit == null)
            {
                return NotFound("Exhibit record not found !!!");
            }
            _dataRepository.Delete(exhibit);
            return GetExhibit();
        }
    }
}