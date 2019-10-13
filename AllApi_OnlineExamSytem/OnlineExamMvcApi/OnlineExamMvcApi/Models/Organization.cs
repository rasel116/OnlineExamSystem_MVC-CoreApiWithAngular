using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineExamMvcApi.Models
{
    public class Organization
    {
        public int OrganizationID { get; set; }
        public string OrgName { get; set; }
        public bool IsActive { get; set; }





        public int? AdminPanelId { get; set; }
        public virtual AdminPanel AdminPanel { get; set; }

        public virtual ICollection<Teacher> Teachers { get; set; }
        public virtual ICollection<Student> Students { get; set; }

    }
}