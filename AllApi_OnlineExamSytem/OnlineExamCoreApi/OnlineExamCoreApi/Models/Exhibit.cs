using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamCoreApi.Models
{
    public class Exhibit
    {
        public int ExhibitId { get; set; }
        public string ExhibitData { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}
