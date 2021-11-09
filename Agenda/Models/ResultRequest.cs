using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Models
{
    public class ResultRequest
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public string Function { get; set; }
        public object Parameters { get; set; }

    }
}
