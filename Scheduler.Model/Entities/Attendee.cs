﻿using System;
using System.Collections.Generic;
using System.Text;
using Scheduler.Data;
using Scheduler.Model;

namespace Scheduler.Model.Entities
{
    public class Attendee : IEntityBase
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }
    }
}
