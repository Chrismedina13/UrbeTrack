using System;
using System.Collections.Generic;
using System.Linq;
using NetChallenge.Abstractions;
using NetChallenge.Domain.Location;
using NetChallenge.Dto.Input;
using NetChallenge.Dto.Output;
using NetChallenge.Exceptions;

namespace NetChallenge
{
    public class OfficeRentalService
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IOfficeRepository _officeRepository;
        private readonly IBookingRepository _bookingRepository;

        public OfficeRentalService(ILocationRepository locationRepository, IOfficeRepository officeRepository, IBookingRepository bookingRepository)
        {
            _locationRepository = locationRepository;
            _officeRepository = officeRepository;
            _bookingRepository = bookingRepository;
        }

        public void AddLocation(AddLocationRequest request)
        {
            var locationNameExists = _locationRepository.AsEnumerable().ToList().Exists(x => x.LocationName.Value == request.Name);
            if (!locationNameExists) { 
            
                Location location = new Location(LocationName.Create(request.Name), NeighborhoodName.Create(request.Neighborhood));
                _locationRepository.Add(location);
            }else
                throw new RepeatedLocationName("Nombre de locación invalido: ya existe una localidad con ese nombre");

        }

        public void AddOffice(AddOfficeRequest request)
        {
            throw new NotImplementedException();
        }

        public void BookOffice(BookOfficeRequest request)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookingDto> GetBookings(string locationName, string officeName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LocationDto> GetLocations()
        {
            var locations = _locationRepository.AsEnumerable();
            return locations.ToList().Select( x => new LocationDto() { Name = x.LocationName.Value, Neighborhood = x.NeighborhoodName.Value });
        }

        public IEnumerable<OfficeDto> GetOffices(string locationName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OfficeDto> GetOfficeSuggestions(SuggestionsRequest request)
        {
            throw new NotImplementedException();
        }
    }
}