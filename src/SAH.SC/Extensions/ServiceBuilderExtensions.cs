using SAH.Abstraction;

namespace SAH.SC.Extensions;

/// <summary>
/// Provides extension methods for service builders to work with configuration services.
/// </summary>
public static class ServiceBuilderExtensions
{
    /// <summary>
    /// Appends the default configuration services to the service builder.
    /// </summary>
    /// <param name="builder">The service builder.</param>
    /// <returns>The service builder for chaining.</returns>
    public static IServiceBuilder AppendConfiguration(this IServiceBuilder builder) => builder.Append(InternalConfigurationExtensions.Source);
}