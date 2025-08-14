using SAH.Abstraction;

namespace SAH.Extensions;

public static class ApplicationModuleExtensions
{
    public static void IntitializeIfNeeded(this IApplicationService service)
    {
        if(service.IsInitialized) return;
        service.Initialize();
    }

    public static void DeintitializeIfNeeded(this IApplicationService service)
    {
        if(!service.IsInitialized) return;
        service.Deinitialize();
    }
}
