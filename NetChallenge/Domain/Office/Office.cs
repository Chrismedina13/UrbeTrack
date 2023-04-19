using NetChallenge.Domain.Location;
using System.Collections.Generic;

namespace NetChallenge.Domain.Office
{
    public class Office
    {
        public Office(LocationName location, OfficeName officeName, MaxCapacity maxCapacity, List<AvailableResource> availableResources)
        {
            LocationName = location;
            OfficeName = officeName;
            MaxCapacity = maxCapacity;
            AvailableResource = availableResources;
        }

        public LocationName LocationName { get; private set; }

        public OfficeName OfficeName { get; private set; }

        public MaxCapacity MaxCapacity { get; private set; }

        public List<AvailableResource> AvailableResource { get; private set; }


        public void SetLocationName(LocationName name)
        {
            LocationName = name;
        }

        public void SetOfficeName(OfficeName name)
        {
            OfficeName = name;
        }

        public void SetMaxCapacity(MaxCapacity maxCapacity)
        {
            MaxCapacity = maxCapacity;
        }

        public void SetMaxCapacity(List<AvailableResource> availableResources)
        {
            AvailableResource = availableResources;
        }
    }
}