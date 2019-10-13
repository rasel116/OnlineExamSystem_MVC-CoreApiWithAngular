using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamCoreApi.Models
{
    public class Test
    {
        public int TestId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public int DurationInMinute { get; set; }

        public int UniqueID { get; set; }
    }
}
