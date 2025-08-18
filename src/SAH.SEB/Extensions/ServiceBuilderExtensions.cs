using SAH.Abstraction;

namespace SAH.SEB.Extensions;

/// <summary>
/// Provides extension methods for service builders to work with event bus services.
/// </summary>
public static class ServiceBuilderExtensions
{
    /// <summary>
    /// Appends the event bus service to the service builder.
    /// </summary>
    /// <param name="builder">The service builder.</param>
    /// <returns>The service builder for chaining.</returns>
    public static IServiceBuilder AppendEventBus(this IServiceBuilder builder) => builder.Append(InternalEventBusExtensions.Source);
}