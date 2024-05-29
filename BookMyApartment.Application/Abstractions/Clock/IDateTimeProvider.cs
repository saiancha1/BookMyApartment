using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyApartment.Application.Abstractions.Clock
{
    interface IDateTimeProvider
    {
        DateTime UtcNow { get; }
    }
}
