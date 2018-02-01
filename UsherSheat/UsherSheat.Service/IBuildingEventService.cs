using UsherSheat.Core;

namespace UsherSheat.Service
{
    public interface IBuildingEventService : IBaseInterface<BuildingEvent>
    {
        /// <summary>
        /// Create default event service
        /// will consist of 
        /// </summary>
        /// <returns>a building event object</returns>
        BuildingEvent CreateDefaultEvent();
    }
}
