using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineExamMvcApi.Models
{
    public class Participant
    {
        public int ParticipantID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Nullable<int> Score { get; set; }
        public Nullable<int> TimeSpent { get; set; }
    }
}