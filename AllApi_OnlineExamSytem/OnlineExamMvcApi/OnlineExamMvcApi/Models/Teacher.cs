using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineExamMvcApi.Models
{
    public class Teacher
    {
        public int TeacherID { get; set; }
        public string TeacherName { get; set; }
        public DateTime? EntryDate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public int OrganizationID { get; set; }
        public virtual Organization Organization { get; set; }
    }
}