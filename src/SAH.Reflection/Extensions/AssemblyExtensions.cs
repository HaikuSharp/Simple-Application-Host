using SAH.Abstraction;
using System.Reflection;

namespace SAH.Reflection.Extensions;

public static class AssemblyExtensions
{
    public static IServiceSource GetTypesAsServiceSource(this Assembly assembly) => new AssemblyDescriptorTypeServiceSource(assembly);
}
