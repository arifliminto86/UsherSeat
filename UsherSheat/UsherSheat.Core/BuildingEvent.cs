using System;
using System.Collections.Generic;

namespace UsherSheat.Core
{
    /// <summary>
    /// The building event class
    /// represeents one service that consist all of the avaiable seats
    /// </summary>
    public class BuildingEvent
    {
        /// <summary>
        /// Building Event Id
        /// </summary>
        public int BuildingEventId { get; set; }

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

        /// <summary>
        /// Max row in one event
        /// </summary>
        public int MaxRow { get; set; }
    }
}
