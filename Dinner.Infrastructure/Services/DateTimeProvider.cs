using Dinner.Application.Common.Services;

namespace Dinner.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime utcNow => DateTime.UtcNow;
    }
}