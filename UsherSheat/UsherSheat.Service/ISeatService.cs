using System.Collections.Generic;
using UsherSheat.Core;

namespace UsherSheat.Service
{
    public interface ISeatService : IBaseInterface<Seat>
    {
        /// <summary>
        /// Create default seats based on max row and max columns
        /// </summary>
        /// <param name="maxRow">maximum row perevent</param>
        /// <param name="maxColumn">maximum column perevent</param>
        /// <param name="maxSmallColumn">maximum column per row</param>
        /// <returns>list of seats</returns>
        List<Seat> CreateDefaultSeats(int maxRow, int maxColumn, int maxSmallColumn);
    }
}
