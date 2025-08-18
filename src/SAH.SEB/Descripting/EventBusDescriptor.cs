using SAH.Descripting.Lazy;
using SDI.Abstraction;
using SEB;
using SEB.Abstraction;

namespace SAH.SEB.Descripting;

/// <summary>
/// Descriptor for the event bus service.
/// </summary>
public sealed class EventBusDescriptor : LazySingletonServiceDescriptorBase<IEventBus>
{
    /// <summary>
    /// Gets the default descriptor instance.
    /// </summary>
    public static EventBusDescriptor Default => field ??= new();

    /// <inheritdoc/>
    protected override IServiceInstanceActivator GetServiceActivator() => new EventBusActivator();

    private class EventBusActivator : IServiceInstanceActivator
    {
        /// <inheritdoc/>
        public object Activate(ServiceId requestedId, IServiceProvider provider) => new EventBus();
    }
}