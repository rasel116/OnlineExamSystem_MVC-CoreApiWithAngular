using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


//Add New
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace OnlineExamCoreApi.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int AccessLevel { get; set; }
        public DateTime EntryDate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PassHash { get; set; }

        public int OrganizationID { get; set; }
        public virtual Organization Organization { get; set; }
    }
}
