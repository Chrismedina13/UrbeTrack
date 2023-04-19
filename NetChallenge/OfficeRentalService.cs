using System;
using System.Collections.Generic;
using System.Linq;
using NetChallenge.Abstractions;
using NetChallenge.Domain.Booking;
using NetChallenge.Domain.Location;
using NetChallenge.Domain.Office;
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
            if (ValidateLocation(request.LocationName) && ValidateOfficeInLocation(request.LocationName, request.Name)) { 
            
                List<AvailableResource> resources = request.AvailableResources.ToList().Select(x => AvailableResource.Create(x)).ToList();
                Office office = new Office(LocationName.Create(request.LocationName), OfficeName.Create(request.Name), MaxCapacity.Create(request.MaxCapacity), resources);
                _officeRepository.Add(office);
            
            }
        }

        public void BookOffice(BookOfficeRequest request)
        {
            Booking booking = new Booking(LocationName.Create(request.LocationName), OfficeName.Create(request.OfficeName), BookingDatetime.Create(request.DateTime), BookingDuration.Create(request.Duration), UserName.Create(request.UserName));
            _bookingRepository.Add(booking);
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
            var offices = _officeRepository.AsEnumerable().ToList().Where(x => x.LocationName.Value == locationName).ToList();
            return offices.Select(x => new OfficeDto() { LocationName = x.LocationName.Value, Name = x.OfficeName.Value, MaxCapacity = x.MaxCapacity.Value, AvailableResources = x.AvailableResource.Select(y => y.Value).ToArray()});
        }

        public IEnumerable<OfficeDto> GetOfficeSuggestions(SuggestionsRequest request)
        {
            throw new NotImplementedException();
        }



        #region Private Methods
        
        private bool ValidateLocation(string localName)
        {
            var locations = GetLocations().ToList();
            if (!locations.Exists(x => x.Name == localName))
                throw new LocalNonExists("Local invalido: El local " + localName.ToUpper() + " ingresado no esta dado de alta");

            return true;
        }

        private bool ValidateOfficeInLocation(string localName, string officeName)
        {
            var offices = GetOffices(localName).ToList();
            if (offices.Exists(x => x.Name == officeName))
                throw new ExistingOfficeInLocality("Oficina invalida: La nombre de oficina " + officeName.ToUpper() + " ya existe en el local " + localName.ToUpper());

            return true;
        } 

        #endregion
    }
}