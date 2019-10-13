using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamCoreApi.Models
{
    public class AdminPanel
    {
        public int AdminPanelId { get; set; }
        public string AdminName { get; set; }
        public string AdminEmail { get; set; }
        public bool IsActive { get; set; }
    }
}
