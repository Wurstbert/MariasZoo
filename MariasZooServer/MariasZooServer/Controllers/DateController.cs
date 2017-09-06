using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MariasZooServer.Models;

namespace MariasZooServer.Controllers
{
    [Route("api/[controller]")]
    public class DateController : Controller
    {
        // GET api/date/2017-9-6
        [HttpGet("{dateString}")]
        public bool IsNewerImageAvailable(string dateString)
        {
            DateTime date; 
            if (DateTime.TryParse(dateString, out date))
            {
                return AnimalModel.Instance.IsNewerImageAvailable(date);
            }

            return false;
        }

        /*
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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
        */
    }
}
