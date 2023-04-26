using Shop.Common.Application_Layer.Services;

namespace Shop.Common.Infrastructure_Layer.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}