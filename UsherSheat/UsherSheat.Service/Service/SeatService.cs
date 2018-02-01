using System;
using System.Collections.Generic;
using System.Linq;
using UsherSheat.Core;

namespace UsherSheat.Service.Service
{
    public class SeatService : BaseService, ISeatService
    {            
        public SeatService(DataContext dataContext) : base(dataContext)
        {
            //nothing to do
        }

        public Seat Get(int id)
        {
            return DataContext.Events.First()?.Seats.SingleOrDefault(w=>w.Id == id);
        }

        public List<Seat> Gets()
        {
            return DataContext.Events.First()?.Seats;
        }

        public Seat Update(int id, Seat newObj)
        {
            foreach (var seat in DataContext.Events.First().Seats)
            {
                if (seat.Id == id)
                {
                    seat.Position = newObj.Position;
                    seat.IsOccupied = newObj.IsOccupied;
                    seat.IsDisabled = newObj.IsDisabled;
                    seat.Column = newObj.Column;
                    return seat;
                }
            }
            throw new Exception("Cannot find seat that need to be updated");
        }

        public void Create(Seat newItem)
        {        
            DataContext.Events.First()?.Seats.Add(newItem);
        }

        public List<Seat> CreateDefaultSeats(int maxRow, int maxColumn, int maxSmallColumn)
        {
            int index = 0;

            for (int i = 0; i < maxColumn+1 ; i++)
            {
                for (int j = 0; j < maxRow+1 ; j++)
                {
                    for (int k = 0; k < maxSmallColumn+1; k++)
                    {
                        Create(
                            new Seat
                            {
                                Id = index,
                                IsDisabled = false,
                                IsOccupied = false,
                                Column = i + 1,
                                Position = new Position(j, k)
                            });

                        index++;
                    }
                }
            }
            return DataContext.Events.First().Seats;            
        }
    }
}
