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
    public class QuizController : ApiController
    {
        public ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        [Route("api/QuizQuestions")]
        public HttpResponseMessage GetQuestions()
        {
            var Qns = db.QuizQuestions
                    .Select(x => new { QnID = x.QuizQuestionID, Qn = x.Qn, x.Option1, x.Option2, x.Option3, x.Option4 })
                    .OrderBy(y => Guid.NewGuid())
                    .Take(10)
                    .ToArray();
            var updated = Qns.AsEnumerable()
                .Select(x => new
                {
                    QnID = x.QnID,
                    Qn = x.Qn,
                    Options = new string[] { x.Option1, x.Option2, x.Option3, x.Option4 }
                }).ToList();
            return this.Request.CreateResponse(HttpStatusCode.OK, updated);
        }

        [HttpPost]
        [Route("api/Answers")]
        public HttpResponseMessage GetAnswers(int[] qIDs)
        {
            var result = db.QuizQuestions
                     .AsEnumerable()
                     .Where(y => qIDs.Contains(y.QuizQuestionID))
                     .OrderBy(x => { return Array.IndexOf(qIDs, x.QuizQuestionID); })
                     .Select(z => z.Answer)
                     .ToArray();
            return this.Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}