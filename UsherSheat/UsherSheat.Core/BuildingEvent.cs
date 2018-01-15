using System;
using System.Collections.Generic;

namespace UsherSheat.Core
{
    public class BuildingEvent
    {
        /// <summary>
        /// Datetime when event starts
        /// </summary>
        public DateTime EventTime { get; set; }

        /// <summary>
        /// Collection of seats
        /// </summary>
        public List<Seat> Seats { get; set; }

        /// <summary>
        /// Max columns in one event
        /// </summary>
        public int MaxColumn { get; set; }
    }
}
