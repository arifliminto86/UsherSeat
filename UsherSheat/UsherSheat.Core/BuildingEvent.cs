using System;
using System.Collections.Generic;
using System.Text;

namespace UsherSheat.Core
{
    public class BuildingEvent
    {
        public DateTime EventTime { get; set; }

        public List<Seat> Seats { get; set; }
    }
}
