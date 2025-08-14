using SAH.Abstraction;
using SAH.Extensions;
using SDI;
using SDI.Abstraction;
using System.Collections.Generic;
using System.Linq;

namespace SAH;

public sealed class ApplicationHost<TCotroller> : InitializableBase, IApplicationHost where TCotroller : ServiceControllerBase, new()
{
    public TCotroller Controller { get; } = ServiceControllerBase.Create<TCotroller>();

    public IServiceProvider RootScope { get; private set; }

    IServiceController IApplicationHost.Controller => Controller;

    protected override void OnInitialized() => RootScope = Controller.CreateScope(ScopeId.Default);

    protected override void OnDeinitialize() => RootScope?.Dispose();

    public void Load(IServiceSource source)
    {
        var scope = RootScope;
        var descriptors = source.Resolve();

        foreach(var serviceDescriptor in descriptors) Controller.RegisterService(serviceDescriptor);
        if(scope is not null) foreach(var service in GetOrderedServices(scope, descriptors)) service.IntitializeIfNeeded();
    }

    public void Unload(IServiceSource source)
    {
        var scope = RootScope;
        var descriptors = source.Resolve();

        if(scope is not null) foreach(var service in GetOrderedServices(scope, descriptors)) service.DeintitializeIfNeeded();
        foreach(var serviceDescriptor in descriptors) Controller.UnregisterService(ServiceId.FromDescriptor(serviceDescriptor));
    }

    private static IEnumerable<IApplicationService> GetOrderedServices(IServiceProvider scope, IEnumerable<IServiceDescriptor> descriptors) => descriptors.Select(d => scope.GetService(ServiceId.FromDescriptor(d))).OfType<IApplicationService>().OrderBy(s => s.Order);
}
