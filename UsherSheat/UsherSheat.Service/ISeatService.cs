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

        /// <summary>
        /// Get Seat number based on position
        /// </summary>
        /// <param name="x">x position</param>
        /// <param name="y">y position</param>
        /// <returns></returns>
        Seat GetByPosition(int x, int y);
    }
}
