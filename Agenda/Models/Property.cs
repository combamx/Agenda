using System;
using System.Collections.Generic;

#nullable disable

namespace Agenda.Models
{
    public partial class Property
    {
        public Property()
        {
            Activities = new HashSet<Activity>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime? DisabledAt { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }
    }
}
