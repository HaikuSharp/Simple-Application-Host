using SAH.Abstraction;
using System.Reflection;

namespace SAH.Reflection.Extensions;

public static class ApplicationHostExtensions
{
    public static void Load(this IApplicationHost host, Assembly assembly) => host.Load(assembly.GetTypesAsServiceSource());

    public static void UnloadEventBus(this IApplicationHost host, Assembly assembly) => host.Unload(assembly.GetTypesAsServiceSource());
}

