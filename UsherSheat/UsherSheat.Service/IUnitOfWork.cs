namespace UsherSheat.Service
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Data Context that represents seat database
        /// </summary>
        DataContext Context { get; set; }

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
        /// Load all building event from a file and save it to context
        /// </summary>
        /// <param name="fileName">the fileName</param>
        /// <returns></returns>
        void Load(string fileName);        
    }
}
