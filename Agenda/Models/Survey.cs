using System;
using System.Collections.Generic;

#nullable disable

namespace Agenda.Models
{
    public partial class Survey
    {
        public int Id { get; set; }
        public int ActivityId { get; set; }
        public string Answers { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Activity Activity { get; set; }
    }
}
