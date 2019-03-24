using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace BookingSystem.Data.UnitTest
{
    [TestClass]
    public class BookingRepositoryTest
    {
        public readonly IBookingRepository bookingRepository;

        public BookingRepositoryTest()
        {
            IList<Booking> bookings = new List<Booking>
            {
                new Booking { Id = 200, CustomerId = 300, BookingStatus = BookingStatus.New },
                new Booking { Id = 300, CustomerId = 500, BookingStatus = BookingStatus.CheckedIn },
                new Booking { Id = 400, CustomerId = 700, BookingStatus = BookingStatus.CheckedOut },
            };

            Mock<IBookingRepository> mockBookingRepo = new Mock<IBookingRepository>();

            mockBookingRepo.Setup(mock => mock.GetAllBookings()).Returns(bookings);

            mockBookingRepo
                .Setup(mock => mock.GetBooking(It.IsAny<int>()))
                .Returns((int id) => bookings.Where(x => x.Id == id).Single());

            mockBookingRepo
                .Setup(mock => mock.CreateBooking(It.IsAny<Booking>()))
                .Returns((Booking booking) =>
                {
                    if (booking.CustomerId == 100) return true;

                    return false;
                });

            bookingRepository = mockBookingRepo.Object;
        }

        [TestMethod]
        public void GetAllBookingsTest()
        {
            var bookings = bookingRepository.GetAllBookings();

            Assert.IsNotNull(bookings);
            Assert.AreEqual(3, bookings.Count());
            Assert.AreEqual(300, bookings.ToList()[1].Id);
        }

        [TestMethod]
        public void GetBookingTest()
        {
            var booking = bookingRepository.GetBooking(400);

            Assert.IsNotNull(booking);
            Assert.AreEqual(2, (short)booking.BookingStatus);
        }

        [TestMethod]
        public void CreateBookingValidBookingTest()
        {
            var result = bookingRepository.CreateBooking(new Booking { CustomerId = 100, });

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CreateBookingInvalidBookingTest()
        {
            var result = bookingRepository.CreateBooking(new Booking { CustomerId = 150, });

            Assert.IsFalse(result);
        }
    }
}
