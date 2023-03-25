namespace Dinner.Application.Common.Services
{
    public interface IDateTimeProvider
    {
        DateTime utcNow { get; }
    }
}