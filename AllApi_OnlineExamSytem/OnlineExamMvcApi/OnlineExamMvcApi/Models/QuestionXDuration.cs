using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineExamMvcApi.Models
{
    public class QuestionXDuration
    {
        public int QuestionXDurationId { get; set; }
        public DateTime RequestTime { get; set; }
        public Nullable<DateTime> LeaveTime { get; set; }
        public Nullable<DateTime> AnsweredTime { get; set; }

        public int? RegistrationId { get; set; }
        public virtual Registration Registration { get; set; }

        public int TestXQuestionId { get; set; }
        public virtual TestXQuestion TestXQuestion { get; set; }
    }
}