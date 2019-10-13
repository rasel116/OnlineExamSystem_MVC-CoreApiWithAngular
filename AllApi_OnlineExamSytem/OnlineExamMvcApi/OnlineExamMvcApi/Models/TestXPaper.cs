using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineExamMvcApi.Models
{
    public class TestXPaper
    {
        public int TestXPaperId { get; set; }
        public string Answer { get; set; }
        public Nullable<decimal> MarkScored { get; set; }

        public int ChoiceId { get; set; }
        public virtual Choice Choice { get; set; }

        public int? RegistrationId { get; set; }
        public virtual Registration Registration { get; set; }


    }
}