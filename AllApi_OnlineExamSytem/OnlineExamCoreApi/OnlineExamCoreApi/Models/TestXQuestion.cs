using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamCoreApi.Models
{
    public class TestXQuestion
    {
        public int TestXQuestionId { get; set; }
        public string Label { get; set; }
        public int QuestionNumber { get; set; }
        public int UniqueQuestionID { get; set; }
        public bool IsActive { get; set; }

        public int UniqueTestID { get; set; }


        //public int? QuestionId { get; set; }
        //public virtual Question Question { get; set; }

        //public int? TestId { get; set; }
        //public virtual Test Test { get; set; }

    }
}
