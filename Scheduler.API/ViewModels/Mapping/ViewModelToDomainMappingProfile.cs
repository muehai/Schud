using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Scheduler.Model.Entities;
using Scheduler.API.ViewModels;


namespace Scheduler.API.ViewModels.Mapping
{
    public class ViewModelToDomainMappingProfile: Profile
    {
        protected void Configure()
        {
            CreateMap<ScheduleViewModel, Schedule>()
               .ForMember(s => s.Creator, map => map.UseValue(new List<Schedule>()))
               .ForMember(s => s.Attendees, map => map.UseValue(new List<Attendee>()));

            CreateMap<UserViewModel, User>();
        }
    }
}
