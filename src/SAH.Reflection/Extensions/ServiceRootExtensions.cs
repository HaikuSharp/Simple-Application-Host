using SAH.Abstraction;
using System.Reflection;

namespace SAH.Reflection.Extensions;

public static class ServiceRootExtensions
{
    public static IServiceRoot Append(this IServiceRoot root, Assembly assembly) => root.Append(assembly.GetTypesAsServiceSource());
}

