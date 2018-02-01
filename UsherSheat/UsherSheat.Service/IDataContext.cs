using System.Collections.Generic;
using UsherSheat.Core;

namespace UsherSheat.Service
{
    public interface IDataContext
    {
        /// <summary>
        /// list of Event Building
        /// </summary>
        List<BuildingEvent> Events { get; set; }

        /// <summary>
        /// Building Event Service
        /// </summary>
        IBuildingEventService BuildingEventService { get; set; }

        /// <summary>
        /// Seat Service
        /// </summary>
        ISeatService SeatService { get; set; }

        /// <summary>
        /// Save existing building event with seats in a file
        /// </summary>
        /// <param name="fileName">filename</param>
        void Save(string fileName);

        /// <summary>
        /// Load all building event from a file
        /// </summary>
        /// <param name="fileName">the fileName</param>
        /// <returns></returns>
        List<BuildingEvent> Load(string fileName);        
    }
}
