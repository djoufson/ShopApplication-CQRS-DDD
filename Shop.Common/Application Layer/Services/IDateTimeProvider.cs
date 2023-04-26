namespace Shop.Common.Application_Layer.Services;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}
