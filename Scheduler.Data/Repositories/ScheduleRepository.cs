using System;
using System.Collections.Generic;
using System.Text;
using Scheduler.Model;
using Scheduler.Model.Entities;
using Scheduler.Data.Abstract;

namespace Scheduler.Data.Repositories
{
    public class ScheduleRepository : EntityBaseRepository<Schedule>, IScheduleRepository
    {
        public ScheduleRepository(SchedulerContext context)
           : base(context)
        { }
    }
}
