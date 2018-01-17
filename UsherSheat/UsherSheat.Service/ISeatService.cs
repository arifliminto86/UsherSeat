using System;
using System.Collections.Generic;
using System.Text;
using UsherSheat.Core;

namespace UsherSheat.Service
{
    public interface ISeatService
    {
        /// <summary>
        /// Get a seat based on seat Id
        /// </summary>
        /// <param name="seatId"></param>
        /// <returns></returns>
        Seat GetSeat(int seatId);
    }
}
