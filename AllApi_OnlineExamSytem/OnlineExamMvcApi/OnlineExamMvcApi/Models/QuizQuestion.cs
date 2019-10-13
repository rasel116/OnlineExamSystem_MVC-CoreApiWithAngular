using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineExamMvcApi.Models
{
    public class QuizQuestion
    {
        public int QuizQuestionID { get; set; }

        public int? SubjectID { get; set; }
        public virtual Subject Subject { get; set; }

        public int? QuestionCategoryId { get; set; }
        public virtual QuestionCategory QuestionCategory { get; set; }

        public int? ExhibitId { get; set; }
        public virtual Exhibit Exhibit { get; set; }

        public string Qn { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public Nullable<int> Answer { get; set; }
    }
}