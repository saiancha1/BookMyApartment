using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyApartment.Application.Bookings.GetBooking
{
    public sealed class BookingResponse
    {
        public Guid Id { get; set; }
        public Guid ApartmentID { get; set; }
        public Guid UserID { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int Status { get; set; }
        public decimal Price { get; set; }
        public string PriceCurrency { get; set; }
        public decimal CleaningFeeAmount { get; set; }
        public string CleaningFeeCurrency { get; set; }
        public decimal AmenitiesUpChargeAmount { get; set; }
        public decimal TotalPriceAmount { get; set; }
    }
}
