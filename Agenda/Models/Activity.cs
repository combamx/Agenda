using System;
using System.Collections.Generic;

#nullable disable

namespace Agenda.Models
{
    public partial class Activity
    {
        public Activity()
        {
            Surveys = new HashSet<Survey>();
        }

        public int Id { get; set; }
        public int PropertyId { get; set; }
        public DateTime Schedule { get; set; }
        public string Title { get; set; }
        public DateTime? DateActivity { get; set; }
        public TimeSpan? TimeBegin { get; set; }
        public TimeSpan? TimeEnd { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public string Status { get; set; }

        public virtual Property Property { get; set; }
        public virtual ICollection<Survey> Surveys { get; set; }
    }
}
