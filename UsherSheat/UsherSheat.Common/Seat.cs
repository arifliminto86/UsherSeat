namespace UsherSheat.Common
{
    public enum SeatStatus
    {
        Free = 0,
        Occupied = 1,
        NewPeople =2
    }

    public class Seat
    {
        public int SeatId { get; set; }
        public SeatStatus Status { get; set; }
    }
}
