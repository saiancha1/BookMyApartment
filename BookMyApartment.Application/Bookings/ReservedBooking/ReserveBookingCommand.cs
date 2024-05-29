using BookMyApartment.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyApartment.Application.Bookings.ReservedBooking
{
    public record ReserveBookingCommand(
        Guid ApartmentID,
        Guid UserID,
        DateOnly StartDate,
        DateOnly EndDate): ICommand<Guid>
    {

    }
}
