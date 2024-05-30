using BookMyApartment.Application.Abstractions.Email;
using BookMyApartment.Domain.Bookings;
using BookMyApartment.Domain.Bookings.Events;
using BookMyApartment.Domain.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyApartment.Application.Bookings.ReservedBooking
{
    internal sealed class BookingReservedDomainEventHandler : INotificationHandler<BookingReservedDomainEvent>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IUserRepository _userRepository;
        private readonly IEmailService emailService;
        public BookingReservedDomainEventHandler(IBookingRepository bookingRepository, IUserRepository userRepository, IEmailService emailService)
        {
            _bookingRepository = bookingRepository;
            _userRepository = userRepository;
            this.emailService = emailService;
        }
        public async Task Handle(BookingReservedDomainEvent notification, CancellationToken cancellationToken)
        {
            var booking = await _bookingRepository.GetByIdAsync(notification.BookingId, cancellationToken);
            if(booking is null)
            {
                return;
            }
             var user = await _userRepository.GetByIdAsync(booking.UserId, cancellationToken);
            if(user is null)
            {
                return;
            }
            await emailService.SendAsync(user.Email, "Booking Reserved", $"Your booking for apartment {booking.ApartmentId} has been reserved." +
                $"You have 10 minutes to confirm this booking");
        }
    }
}
