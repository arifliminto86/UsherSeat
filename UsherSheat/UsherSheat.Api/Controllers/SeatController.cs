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
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Default ctor
        /// </summary>
        /// <param name="unitOfWork">data context that we inject</param>
        public SeatController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/get/<controller>
        [HttpGet]
        public IEnumerable<Seat> Get()
        {
            return _unitOfWork.SeatService.Gets();            
        }

        /// <summary>
        /// Get seat based on Position
        /// url will be : http://localhost:54392/api/seat/GetByPosition/2/1 which x:2 and y:1
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [HttpGet("GetByPosition/{x:int}/{y:int}")]
        public Seat GetByPosition(int x, int y)
        {
            var seat = _unitOfWork.SeatService.GetByPosition(x, y);

            return seat;
        }

        /// <summary>
        /// Get Empty Seat so ushers can assign people to the empty seat
        /// </summary>
        /// <returns>List of empty seat</returns>
        [HttpGet("GetEmptySeat")]
        public Seat GetEmptySeat()
        {
            throw new NotImplementedException();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Seat Get(int id)
        {
            return _unitOfWork.SeatService.Get(id);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]Seat value)
        {
            _unitOfWork.SeatService.Create(value);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Seat value)
        {
            _unitOfWork.SeatService.Update(id, value);
        }       
    }
}
