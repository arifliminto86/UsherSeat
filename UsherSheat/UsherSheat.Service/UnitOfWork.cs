using UsherSheat.Service.Service;

namespace UsherSheat.Service
{
    /// <summary>
    /// Data context for an events
    /// </summary>
    public class UnitOfWork :IUnitOfWork
    {
        #region Interface Property
        public DataContext Context{ get; set; }

        public IBuildingEventService BuildingEventService { get; set; }
        public ISeatService SeatService { get; set; }
        #endregion

        public UnitOfWork()
        {
            Context = new DataContext();
            BuildingEventService = new BuildingEventService(this);        
            SeatService = new SeatService(this);
        }

        public void Save(string fileName)
        {
            throw new System.NotImplementedException();
        }

        public void Load(string fileName)
        {
            throw new System.NotImplementedException();
        }       
    }
}
