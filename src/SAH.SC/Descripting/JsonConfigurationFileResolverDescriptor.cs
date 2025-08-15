using SAH.Descripting;
using SAH.SC.Abstraction;

namespace SAH.SC.Descripting;

public sealed class JsonConfigurationFileResolverDescriptor : SingletonServiceDescriptorBase<IConfigurationFileResolver, JsonConfigurationFileResolver>
{
    public static JsonConfigurationFileResolverDescriptor Default => field ??= new();

    protected override JsonConfigurationFileResolver GetServiceInstance() => JsonConfigurationFileResolver.Default;
}
