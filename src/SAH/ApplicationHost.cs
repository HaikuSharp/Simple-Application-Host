using SAH.Abstraction;
using SAH.Extensions;
using SDI;
using SDI.Abstraction;
using System.Collections.Generic;
using System.Linq;

namespace SAH;

/// <summary>
/// Host for application services with lifecycle management.
/// </summary>
/// <typeparam name="TCotroller">The type of service controller.</typeparam>
public sealed class ApplicationHost<TCotroller> : InitializableBase, IApplicationHost where TCotroller : ServiceControllerBase, new()
{
    /// <summary>
    /// Gets the service controller.
    /// </summary>
    public TCotroller Controller { get; } = ServiceControllerBase.Create<TCotroller>();

    /// <inheritdoc/>
    public IServiceProvider RootScope { get; private set; }

    /// <inheritdoc/>
    IServiceController IApplicationHost.Controller => Controller;

    /// <inheritdoc/>
    protected override void OnInitialized() => RootScope = Controller.CreateScope(ScopeId.Default);

    /// <inheritdoc/>
    protected override void OnDeinitialize() => RootScope?.Dispose();

    /// <inheritdoc/>
    public void Load(IServiceSource source)
    {
        var scope = RootScope;
        var descriptors = source.Resolve();

        foreach(var serviceDescriptor in descriptors) Controller.RegisterService(serviceDescriptor);
        if(scope is not null) foreach(var service in GetServices(scope, descriptors)) service.IntitializeIfNeeded();
    }

    /// <inheritdoc/>
    public void Unload(IServiceSource source)
    {
        var scope = RootScope;
        var descriptors = source.Resolve();

        if(scope is not null) foreach(var service in GetServices(scope, descriptors)) service.DeintitializeIfNeeded();
        foreach(var serviceDescriptor in descriptors) Controller.UnregisterService(ServiceId.FromDescriptor(serviceDescriptor));
    }

    private static IEnumerable<IApplicationService> GetServices(IServiceProvider scope, IEnumerable<IServiceDescriptor> descriptors) => descriptors.Select(d => scope.GetService(ServiceId.FromDescriptor(d))).OfType<IApplicationService>().OrderBy(s => s.Order);
}