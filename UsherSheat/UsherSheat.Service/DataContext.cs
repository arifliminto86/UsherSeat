using System.Collections.Generic;
using UsherSheat.Core;
using UsherSheat.Service.Service;

namespace UsherSheat.Service
{
    /// <summary>
    /// Data context for an events
    /// </summary>
    public class DataContext :IDataContext
    {
        #region Interface Property
        public List<BuildingEvent> Events { get; set; }

        public IBuildingEventService BuildingEventService { get; set; }
        public ISeatService SeatService { get; set; }
        #endregion

        public DataContext()
        {
            Events = new List<BuildingEvent>();
            BuildingEventService = new BuildingEventService(this);        
            SeatService = new SeatService(this);
        }

        public void Save(string fileName)
        {
            throw new System.NotImplementedException();
        }

        public List<BuildingEvent> Load(string fileName)
        {
            throw new System.NotImplementedException();
        }       
    }
}
