using SC.Abstraction;

namespace SAH.SC.Abstraction;

public interface IConfigurationFileResolver
{
    IConfigurationSource Resolve(string path);
}