namespace NetChallenge.Domain.Location
{
    public class Location
    {
        public LocationName LocationName { get; private set; }

        public NeighborhoodName NeighborhoodName { get; private set; }

        public Location(LocationName name, NeighborhoodName neighborhoodName)
        {
            this.NeighborhoodName = neighborhoodName;
            this.LocationName = name;
        }

        public void SetLocationName(LocationName name) {

            LocationName = name;
        }

        public void SetNeighborhoodName(NeighborhoodName name)
        {

            NeighborhoodName = name;
        }
    }
}