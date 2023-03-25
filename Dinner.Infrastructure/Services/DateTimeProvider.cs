namespace Dinner.Infrastructure.Services
{
    using Dinner.Application.Common.Services;

    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}