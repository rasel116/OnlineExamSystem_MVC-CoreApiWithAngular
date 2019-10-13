using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//Add 
using OnlineExamMvcApi.Models;
using System.Web.Http.Description;
using System.Data.Entity;
namespace OnlineExamMvcApi.Controllers
{
    public class ParticipantController : ApiController
    {
        public ApplicationDbContext db = new ApplicationDbContext();

        [HttpPost]
        [Route("api/InsertParticipant")]
        public Participant Insert(Participant model)
        {
            db.Participants.Add(model);
            db.SaveChanges();
            return model;
        }

        [HttpPost]
        [Route("api/UpdateOutput")]
        public void UpdateOutput(Participant model)
        {
            db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
