using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineExamMvcApi.Models
{
    public class Test
    {
        public int TestId { get; set; }
        public string TeacherName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public int DurationInMinute { get; set; }

        public int UniqueID { get; set; }

        //public virtual ICollection<Registration> Registrations { get; set; }
        //public virtual ICollection<TestXQuestion> TestXQuestions { get; set; }
    }
}