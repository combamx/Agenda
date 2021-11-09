using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Models.Request
{
    public class SurveyRequest
    {
        public int Id { get; set; }
        public int ActivityId { get; set; }
        public string Answers { get; set; }
    }
}
