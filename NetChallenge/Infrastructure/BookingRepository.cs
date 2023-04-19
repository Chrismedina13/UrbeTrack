using System.Collections.Generic;
using NetChallenge.Abstractions;
using NetChallenge.Domain;
using NetChallenge.Domain.Booking;

namespace NetChallenge.Infrastructure
{
    public class BookingRepository : IBookingRepository
    {
        private List<Booking> bookingList = new List<Booking>();

        public IEnumerable<Booking> AsEnumerable()
        {
            return bookingList;
        }

        public void Add(Booking item)
        {
            bookingList.Add(item);
        }
    }
}