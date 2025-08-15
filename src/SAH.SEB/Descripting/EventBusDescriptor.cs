using SAH.Descripting.Lazy;
using SDI.Abstraction;
using SEB;
using SEB.Abstraction;

namespace SAH.SEB.Descripting;

public sealed class EventBusDescriptor : LazySingletonServiceDescriptorBase<IEventBus>
{
    public static EventBusDescriptor Default => field ??= new();

    protected override IServiceInstanceActivator GetServiceActivator() => new EventBusActivator();

    private class EventBusActivator : IServiceInstanceActivator
    {
        public object Activate(ServiceId requestedId, IServiceProvider provider) => new EventBus();
    }
}
