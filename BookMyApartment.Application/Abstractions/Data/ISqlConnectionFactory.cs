using System.Data;
using System.Data.Common;



namespace BookMyApartment.Application.Abstractions.Data
{
    public interface ISqlConnectionFactory
    {
        DbConnection CreateConnection();
    }
}
