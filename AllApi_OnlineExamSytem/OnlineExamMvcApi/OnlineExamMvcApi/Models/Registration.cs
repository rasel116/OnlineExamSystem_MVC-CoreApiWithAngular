using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineExamMvcApi.Models
{
    public class Registration
    {
        public int RegistrationId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public Guid Token { get; set; }
        public DateTime TokenExpireTime { get; set; }

        public int? TestId { get; set; }
        public virtual Test Test { get; set; }

        public int? StudentId { get; set; }
        public virtual Student Student { get; set; }

        public int? OrganizationID { get; set; }
        public virtual Organization Organization { get; set; }



        //public virtual ICollection<QuestionXDuration> QuestionXDurations { get; set; }
        //public virtual ICollection<TestXPaper> TestXPapers { get; set; }
    }
}