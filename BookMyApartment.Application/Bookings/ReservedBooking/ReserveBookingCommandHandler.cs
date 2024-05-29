using BookMyApartment.Application.Abstractions.Clock;
using BookMyApartment.Application.Abstractions.Messaging;
using BookMyApartment.Domain.Abstractions;
using BookMyApartment.Domain.Apartments;
using BookMyApartment.Domain.Bookings;
using BookMyApartment.Domain.Users;

namespace BookMyApartment.Application.Bookings.ReservedBooking
{
    internal sealed class ReserveBookingCommandHandler : ICommandHandler<ReserveBookingCommand, Guid>
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly PricingService _pricingService;
        private readonly IDateTimeProvider _dateTimeProvider;

        public ReserveBookingCommandHandler(
                       IApartmentRepository apartmentRepository,
                                  IUserRepository userRepository,
                                             IBookingRepository bookingRepository,
                                                        IUnitOfWork unitOfWork,
                                                                   PricingService pricingService,
                                                                        IDateTimeProvider dateTimeProvider)
        {
            _apartmentRepository = apartmentRepository;
            _userRepository = userRepository;
            _bookingRepository = bookingRepository;
            _unitOfWork = unitOfWork;
            _pricingService = pricingService;
            _dateTimeProvider = dateTimeProvider;
        }
        public async Task<Result<Guid>> Handle(ReserveBookingCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserID, cancellationToken);
            if (user is null)
            {
                return Result.Failure<Guid>(UserErrors.NotFound);
            }
            var apartment = await _apartmentRepository.GetByIdAsync(request.ApartmentID, cancellationToken);
            if (apartment is null)
            {
                return Result.Failure<Guid>(ApartmentErrors.NotFound);
            }
            var duration = DateRange.Create(request.StartDate, request.EndDate);
            if(await _bookingRepository.IsOverlappingAsync(apartment, duration, cancellationToken))
            {
                return Result.Failure<Guid>(BookingErrors.Overlap);
            }   
            var booking = Booking.Reserve(apartment,
                user.Id, 
                duration,
                _dateTimeProvider.UtcNow, 
                _pricingService);
            _bookingRepository.Add(booking);

            //Potential race condition. Will need to fix later.
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return booking.Id;
        }
    }
}
