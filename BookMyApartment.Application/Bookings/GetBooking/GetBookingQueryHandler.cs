using BookMyApartment.Application.Abstractions.Data;
using BookMyApartment.Application.Abstractions.Messaging;
using BookMyApartment.Domain.Abstractions;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyApartment.Application.Bookings.GetBooking
{
    internal sealed class GetBookingQueryHandler : IQueryHandler<GetBookingQuery, BookingResponse>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        public GetBookingQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }   
        public async Task<Result<BookingResponse>> Handle(GetBookingQuery request, CancellationToken cancellationToken)
        {
            using var connection = _sqlConnectionFactory.CreateConnection();
            const string sql = "SELECT * FROM bookings WHERE id = @BookingId";
            var booking = await connection.QueryFirstOrDefaultAsync<BookingResponse>(sql, new { request.BookingId });
            return booking;
        }
    }
}
