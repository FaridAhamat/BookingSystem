using System;
using System.Collections.Generic;
using System.Text;

namespace BookingSystem.Data
{
    public interface IBookingRepository
    {
        Booking GetBooking(int id);

        IEnumerable<Booking> GetAllBookings();

        bool CreateBooking(Booking booking);
    }
}
