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
            if (ValidateOfficeInBooking(request.LocationName, request.OfficeName)) { 
            
                Booking booking = new Booking(LocationName.Create(request.LocationName), OfficeName.Create(request.OfficeName), BookingDatetime.Create(request.DateTime), BookingDuration.Create(request.Duration), UserName.Create(request.UserName));
                _bookingRepository.Add(booking);       
            }
        }

        public IEnumerable<BookingDto> GetBookings(string locationName, string officeName)
        {
            List<Booking> bookings = new List<Booking>();
            bookings = _bookingRepository.AsEnumerable().ToList().Where(x => x.LocationName.Value == locationName && x.OfficeName.Value == officeName).ToList();
            if (bookings.Count() > 0)
                return bookings.ToList().Select(x => new BookingDto() { LocationName = x.LocationName.Value, OfficeName = x.OfficeName.Value, DateTime = x.BookingDatetime.Value, Duration = x.BookingDuration.Value, UserName = x.UserName.Value });
            else
                return new List<BookingDto>();
        }

        public IEnumerable<LocationDto> GetLocations()
        {
            List<Location> locations = new List<Location>();
            locations = _locationRepository.AsEnumerable().ToList();
            if (locations.Count() > 0)
                return locations.ToList().Select(x => new LocationDto() { Name = x.LocationName.Value, Neighborhood = x.NeighborhoodName.Value });
            else
                return new List<LocationDto>();
        }

        public IEnumerable<OfficeDto> GetOffices(string locationName)
        {
            List<Office> offices = new List<Office>();
            offices = _officeRepository.AsEnumerable().ToList().Where(x => x.LocationName.Value == locationName).ToList();
            if (offices.Count() > 0)
                return offices.Select(x => new OfficeDto() { LocationName = x.LocationName.Value, Name = x.OfficeName.Value, MaxCapacity = x.MaxCapacity.Value, AvailableResources = x.AvailableResource.Select(y => y.Value).ToArray() });
            else
                return new List<OfficeDto>();
        }

        public IEnumerable<OfficeDto> GetOfficeSuggestions(SuggestionsRequest request)
        {
            throw new NotImplementedException();
        }



        #region Private Methods
        
        private bool ValidateLocation(string localName)
        {
            List<LocationDto> locations = new List<LocationDto>();
            locations = GetLocations().ToList();
            if (!locations.Exists(x => x.Name == localName))
                throw new LocalNonExists("Locación invalido: La locación " + localName.ToUpper() + " ingresado no esta dado de alta");

            return true;
        }

        private bool ValidateOfficeInLocation(string locationName, string officeName)
        {
            List<OfficeDto> offices = new List<OfficeDto>();
            offices = GetOffices(locationName).ToList();
            if (offices.Exists(x => x.Name == officeName))
                throw new ExistingOfficeInLocality("Oficina invalida: La nombre de oficina " + officeName.ToUpper() + " ya existe en el locación " + locationName.ToUpper());

            return true;
        }

        private bool ValidateOfficeInBooking(string locationName, string officeName) 
        {
            List<OfficeDto> offices = new List<OfficeDto>();
            if (ValidateLocation(locationName)) {
                offices = GetOffices(locationName).ToList();
                if(!offices.Exists(x => x.Name == officeName))
                    throw new InvalidOffice("Oficina invalida: La oficina " + officeName.ToUpper() + " ,no se encuentra dada de alta en la locación " + locationName.ToUpper());
            }

            return true;
        }

        #endregion
    }
}