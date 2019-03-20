using System;

namespace BookingSystem.Data
{
    public class Booking
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public BookingStatus BookingStatus { get; set; }
    }

    public enum BookingStatus
    {
        New = 0,
        CheckedIn = 1,
        CheckedOut = 2,
    }
}
