using System;
using System.Collections.Generic;
using System.Text;

namespace BookingSystem.Data.Data
{
    // Store all the data into the memory. In reality, there should be a SQL db + an ORM that the repository uses to work with the db
    // The intention to make it really, really simple
    public static class Data
    {
        public static List<Booking> Bookings = new List<Booking>
        {
            new Booking { Id = 1, CustomerId = 1, BookingStatus = BookingStatus.New },
            new Booking { Id = 2, CustomerId = 2, BookingStatus = BookingStatus.New },
            new Booking { Id = 3, CustomerId = 3, BookingStatus = BookingStatus.CheckedIn },
            new Booking { Id = 4, CustomerId = 4, BookingStatus = BookingStatus.CheckedIn },
        };

        public static List<Customer> Customers = new List<Customer>
        {
            new Customer { Id = 1, Name = "Ali" },
            new Customer { Id = 2, Name = "Muthu" },
            new Customer { Id = 3, Name = "Ah Chong" },
            new Customer { Id = 4, Name = "John" },
        };
    }
}
