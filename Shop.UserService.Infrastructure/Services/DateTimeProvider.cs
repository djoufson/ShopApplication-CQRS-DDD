using Shop.UserService.Application.Common.Interfaces;

namespace Shop.UserService.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
