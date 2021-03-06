using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Models.Request
{
    public class ActivityRequest
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public DateTime Schedule { get; set; }
        public string DateActivity { get; set; }
        public string TimeBegin { get; set; }
        public string TimeEnd { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public int? Survey { get; set; }
    }
}
