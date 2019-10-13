using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineExamMvcApi.Models
{
    public class Choice
    {
        public int ChoiceId { get; set; }
        public string Label { get; set; }
        public decimal Points { get; set; }
        public bool IsActive { get; set; }
        public int UniqueQuestionID { get; set; }

        //public int QuestionId { get; set; }
        //public virtual Question Question { get; set; }

        //public virtual ICollection<TestXPaper> TestXPapers { get; set; }
    }
}