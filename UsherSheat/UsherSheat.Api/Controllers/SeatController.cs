using System;
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
        private readonly IDataContext _dataContext;

        /// <summary>
        /// Default ctor
        /// </summary>
        /// <param name="dataContext">data context that we inject</param>
        public SeatController(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        // GET: api/get/<controller>
        [HttpGet]
        public IEnumerable<Seat> Get()
        {
            return _dataContext.SeatService.Gets();            
        }

        /// <summary>
        /// Get seat based on Position
        /// url will be : http://localhost:54392/api/seat/GetByPosition/2/1 which x:2 and y:1
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [HttpGet("GetByPosition/{x:int}/{y:int}")]
        public IEnumerable<Seat> GetByPosition(int x, int y)
        {
            throw new NotImplementedException();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Seat Get(int id)
        {
            return _dataContext.SeatService.Get(id);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]Seat value)
        {
            _dataContext.SeatService.Create(value);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Seat value)
        {
            _dataContext.SeatService.Update(id, value);
        }       
    }
}
