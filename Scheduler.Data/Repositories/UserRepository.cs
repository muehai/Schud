using System;
using System.Collections.Generic;
using System.Text;
using Scheduler.Model.Entities;
using Scheduler.Data.Abstract;

namespace Scheduler.Data.Repositories
{
   public class UserRepository : EntityBaseRepository<User>, IUserRepository
    {
        public UserRepository(SchedulerContext context)
            : base(context)
        { }
    }
}
