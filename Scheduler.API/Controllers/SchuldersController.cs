using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Scheduler.Model.Entities;
using Scheduler.Data.Abstract;
using Scheduler.API;

namespace Scheduler.API.Controllers
{
    [Route("api/[controller]")]
    public class SchuldlersController : Controller
    {

        //Add the repositories 
        private IScheduleRepository _scheduleRepository;
        private IAttendeeRepository _attendeeRepository;
        private IUserRepository _userRepository;

        public SchuldlersController(IScheduleRepository scheduleRepository, 
                                    IAttendeeRepository attendeeRepository,
                                    IUserRepository userRepository)
        {
            _scheduleRepository = scheduleRepository;
            _attendeeRepository = attendeeRepository;
            _userRepository = userRepository;

        }


        public IActionResult Get()
        {

        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
