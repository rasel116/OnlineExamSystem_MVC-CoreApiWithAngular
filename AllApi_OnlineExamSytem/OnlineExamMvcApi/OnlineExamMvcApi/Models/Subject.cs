using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineExamMvcApi.Models
{
    public class Subject
    {
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }

        //public ICollection<Question> Questions { get; set; }
    }
}