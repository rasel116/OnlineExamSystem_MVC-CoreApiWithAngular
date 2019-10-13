using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineExamMvcApi.Models
{
    public class QuestionCategory
    {
        public int QuestionCategoryId { get; set; }
        public string Category { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}