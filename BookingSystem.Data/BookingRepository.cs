using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingSystem.Data
{
    public class BookingRepository : IBookingRepository
    {
        /// <summary>
        /// Create booking
        /// </summary>
        /// <param name="booking">Booking to be created</param>
        /// <returns>True if creation succeed, else false</returns>
        public bool CreateBooking(Booking booking)
        {
            var customer = (from c in Data.Data.Customers
                            where c.Id == booking.CustomerId
                            select c).FirstOrDefault();

            if (customer == null) return false;

            var lastBookingId = Data.Data.Bookings[Data.Data.Bookings.Count - 1].Id;

            Data.Data.Bookings.Add(new Booking
            {
                Id = lastBookingId + 1,
                CustomerId = booking.CustomerId,
                BookingStatus = BookingStatus.New,
            });

            return true;
        }

        /// <summary>
        /// Get booking based on booking Id
        /// </summary>
        /// <param name="id">The booking ID</param>
        /// <returns>The booking</returns>
        public Booking GetBooking(int id)
        {
            return (from b in Data.Data.Bookings
                    where b.Id == id
                    select b).FirstOrDefault();
        }

        /// <summary>
        /// Get all bookings
        /// </summary>
        /// <returns>All bookings on record</returns>
        public IEnumerable<Booking> GetAllBookings()
        {
            return Data.Data.Bookings;
        }
    }
}
