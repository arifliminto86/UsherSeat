namespace UsherSheat.Core
{
    public class Seat
    {
        public int SeatId { get; set; }

        /// <summary>
        /// position of the seat
        /// </summary>
        public Position Position{get ;set; }

        /// <summary>
        /// Indicate  this seat is already occupied
        /// </summary>
        public bool IsOccupied { get; set; }

        /// <summary>
        /// Indicate if this seat is already disabled
        /// </summary>
        public bool IsDisabled { get; set; }

    }
}
