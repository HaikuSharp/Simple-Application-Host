using SAH.SC.Abstraction;
using SC.Abstraction;
using SC.Newtonsoft.JSON;

namespace SAH.SC;

public class JsonConfigurationFileResolver : IConfigurationFileResolver
{
    public static JsonConfigurationFileResolver Default => field ??= new();

    public IConfigurationSource Resolve(string path) => new JsonFileConfigurationSource(path);
}
