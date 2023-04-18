using System.Collections.Generic;
using NetChallenge.Abstractions;
using NetChallenge.Domain;
using NetChallenge.Domain.Location;

namespace NetChallenge.Infrastructure
{
    public class LocationRepository : ILocationRepository
    {
        List<Location> locationList = new List<Location>();

        public IEnumerable<Location> AsEnumerable()
        {
            return locationList;
        }

        public void Add(Location item)
        {
            locationList.Add(item);
        }
    }
}