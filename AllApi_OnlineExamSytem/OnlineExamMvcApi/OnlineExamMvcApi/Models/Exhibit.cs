using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineExamMvcApi.Models
{
    public class Exhibit
    {
        public int ExhibitId { get; set; }
        public string ExhibitData { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}