using System.Collections.Generic;
using UsherSheat.Core;

namespace UsherSheat.Service
{
    public class DataContext
    {
        /// <summary>
        /// list of Event Building
        /// </summary>
        internal List<BuildingEvent> Events { get; set; }

        internal DataContext()
        {
            Events = new List<BuildingEvent>();
        }
    }
}
