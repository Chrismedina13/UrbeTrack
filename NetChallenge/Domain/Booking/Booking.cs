﻿using NetChallenge.Domain.Location;
using NetChallenge.Domain.Office;

namespace NetChallenge.Domain.Booking
{
    public class Booking
    {
        public LocationName LocationName { get; private set; }

        public OfficeName OfficeName { get; private set; }

        public BookingDatetime BookingDatetime { get; private set; }

        public UserName UserName { get; private set; }



        public void SetLocationName(LocationName name)
        {
            LocationName = name;
        }

        public void SetOfficeName(OfficeName name)
        {
            OfficeName = name;
        }

        public void SetBookingDatetime(BookingDatetime datetime)
        {
            BookingDatetime = datetime;
        }

        public void SetUserName(UserName userName)
        {
            UserName = userName;
        }

    }
}