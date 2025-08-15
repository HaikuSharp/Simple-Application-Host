using SC.Abstraction;

namespace SAH.SC.Abstraction;

public delegate void ConfigurationRootSaveHandler(IConfigurationRoot root);
public delegate void ConfigurationRootLoadHandler(IConfigurationRoot root);

public interface IConfigurationService
{
    event ConfigurationRootSaveHandler OnRootSaved;
    event ConfigurationRootLoadHandler OnRootLoaded;

    IConfigurationRoot Root { get; }

    bool IsLoaded { get; }
}
