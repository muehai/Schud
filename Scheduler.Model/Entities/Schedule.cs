using Scheduler.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduler.Model.Entities
{
   public class Schedule : IEntityBase
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public string Location { get; set; }
        //create sType
        public ScheduleType Type { get; set; }
        //Create schedule status 
        public ScheduleStatus Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public User Creator { get; set; }
        public int CreatorId { get; set; }
        public ICollection<Attendee> Attendees { get; set; }
    }
}
