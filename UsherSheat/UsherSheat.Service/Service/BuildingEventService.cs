using System;
using System.Collections.Generic;
using System.Linq;
using UsherSheat.Core;

namespace UsherSheat.Service.Service
{
    public class BuildingEventService : BaseService, IBuildingEventService
    {        
        private const int MaxColumn = 5;
        private const int MaxRow = 4;
        private const int SmallColumn = 5;        

        public BuildingEventService(IDataContext dataContext) : base(dataContext)
        {
            //nothing to do
        }

        public BuildingEvent Get(int id)
        {
            return DataContext.Events.SingleOrDefault(w => w.Id == id);            
        }

        public List<BuildingEvent> Gets()
        {
            //nothing to do
            throw new NotImplementedException();
        }

        public BuildingEvent Update(int id, BuildingEvent newObj)
        {
            throw new NotImplementedException();
        }

        public void Create(BuildingEvent newItem)
        {
            throw new NotImplementedException();
        }

        public BuildingEvent CreateDefaultEvent()
        {
            var building = new BuildingEvent
            {
                Id = 1,
                EventTime = DateTime.Now,
                MaxColumn = MaxColumn,
                MaxRow = MaxRow,
                Seats =  DataContext.SeatService.CreateDefaultSeats(MaxRow, MaxColumn, SmallColumn)
            };
            
            DataContext.Events.Add(building);
            return building;
        }
    }
}
