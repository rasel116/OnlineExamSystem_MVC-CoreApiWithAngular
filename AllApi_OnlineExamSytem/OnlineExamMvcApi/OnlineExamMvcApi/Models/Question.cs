using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineExamMvcApi.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string QuestionType { get; set; }
        public string Question1 { get; set; }
        public int Points { get; set; }
        public bool IsActive { get; set; }
        public int QuestionUniqueID { get; set; }
        public int TestUniqueID { get; set; }

        public int SubjectID { get; set; }
        public virtual Subject Subject { get; set; }

        public int ExhibitId { get; set; }
        public virtual Exhibit Exhibit { get; set; }

        public int QuestionCategoryId { get; set; }   
        public virtual QuestionCategory QuestionCategory { get; set; }

        //public virtual ICollection<TestXQuestion> TestXQuestions { get; set; }
        //public virtual ICollection<Choice> Choices { get; set; }
    }
}