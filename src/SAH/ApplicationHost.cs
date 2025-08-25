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
    public TCotroller Controller { get; private set; }

    /// <inheritdoc/>
    IServiceController IApplicationHost.Controller => Controller;

    /// <inheritdoc/>
    protected override void OnInitialized() => Controller = ServiceControllerBase.Create<TCotroller>();

    /// <inheritdoc/>
    protected override void OnDeinitialize()
    {
        if(Controller is null) return;
        Controller.Dispose();
        Controller = null;
    }

    /// <inheritdoc/>
    public void Load(IServiceSource source)
    {
        var controller = Controller;
        var descriptors = source.Resolve();

        foreach(var serviceDescriptor in descriptors) Controller.RegisterService(serviceDescriptor);
        if(controller is not null) foreach(var service in GetServices(controller, descriptors)) service.IntitializeIfNeeded();
    }

    /// <inheritdoc/>
    public void Unload(IServiceSource source)
    {
        var controller = Controller;
        var descriptors = source.Resolve();

        if(controller is not null) foreach(var service in GetServices(controller, descriptors)) service.DeintitializeIfNeeded();
        foreach(var serviceDescriptor in descriptors) Controller.UnregisterService(ServiceId.FromDescriptor(serviceDescriptor));
    }

    private static IEnumerable<IApplicationService> GetServices(TCotroller controller, IEnumerable<IServiceDescriptor> descriptors) => descriptors.Select(d => controller.GetService(ServiceId.FromDescriptor(d))).OfType<IApplicationService>().OrderBy(s => s.Order);
}