namespace UsherSheat.Core
{
    /// <summary>
    /// The seat class
    /// </summary>
    public class Seat : BaseClass
    {      
        /// <summary>
        /// position of the seat
        /// </summary>
        public Position Position{get ;set; }

        /// <summary>
        /// Column of the seat
        /// </summary>
        public int Column { get; set; }
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
