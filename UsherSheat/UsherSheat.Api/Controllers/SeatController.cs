using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UsherSheat.Core;
using UsherSheat.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UsherSheat.Api.Controllers
{
    [Route("api/[controller]")]
    public class SeatController : Controller
    {
        private readonly ISeatService _seatService;

        /// <summary>
        /// Default ctor
        /// </summary>
        /// <param name="seatService">seat service that we inject</param>
        public SeatController(ISeatService seatService)
        {
            _seatService = seatService;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Seat> Get()
        {
            return _seatService.Gets();            
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Seat Get(int id)
        {
            return _seatService.Get(id);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]Seat value)
        {
            _seatService.Create(value);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Seat value)
        {
            _seatService.Update(id, value);
        }       
    }
}
