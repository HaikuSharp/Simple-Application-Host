namespace SAH.Abstraction;

/// <summary>
/// Represents a builder for service sources.
/// </summary>
public interface IServiceBuilder
{
    /// <summary>
    /// Appends a service source to the builder.
    /// </summary>
    /// <param name="source">The service source to append.</param>
    /// <returns>The service builder for chaining.</returns>
    IServiceBuilder Append(IServiceSource source);

    /// <summary>
    /// Builds a combined service source.
    /// </summary>
    /// <returns>The built service source.</returns>
    IServiceSource Build();
}