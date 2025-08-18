using SAH.Abstraction;

namespace SAH;

/// <summary>
/// Base class for application services.
/// </summary>
public abstract class ApplicationServiceBase : InitializableBase, IApplicationService
{
    /// <inheritdoc/>
    public virtual string Name => GetType().Name;

    /// <inheritdoc/>
    public virtual int Order => (int)EServiceOrder.Default;
}