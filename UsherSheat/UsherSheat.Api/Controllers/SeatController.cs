using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UsherSheat.Core;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UsherSheat.Api.Controllers
{
    [Route("api/[controller]")]
    public class SeatController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Seat> Get()
        {
            return new List<Seat>();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }       
    }
}
