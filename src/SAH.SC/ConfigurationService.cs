using SAH.SC.Abstraction;
using SC;
using SC.Abstraction;
using SC.Extensions;
using System.IO;
using System.Threading.Tasks;

namespace SAH.SC;

/// <summary>
/// Service for managing application configurations.
/// </summary>
public sealed class ConfigurationService(IConfigurationFileResolver resolver, IConfigurationSettings settings) : ApplicationServiceBase, IConfigurationService
{
    private const string CONFUIGURATIONS_PATH = "Configurations";
    private const string ROOT_CONFIGURATION_NAME = "Root";

    private CompositeConfigurationValueSource<IFileConfigurationValueSource> m_ValuesSource;

    /// <inheritdoc/>
    public IConfiguration Root { get; private set; }

    /// <inheritdoc/>
    public override int Order => (int)EServiceOrder.RootService;

    /// <inheritdoc/>
    protected override void OnInitialized()
    {

        if(!Directory.Exists(CONFUIGURATIONS_PATH))
        {
            _ = Directory.CreateDirectory(CONFUIGURATIONS_PATH);
            return;
        }

        var source = m_ValuesSource = new();

        foreach(string filePath in Directory.GetFiles(CONFUIGURATIONS_PATH)) source.AppendSource(resolver.Resolve(filePath, settings));

        Root = new Configuration(ROOT_CONFIGURATION_NAME, settings);

        _ = Task.Run(LoadAsync);
    }

    /// <inheritdoc/>
    protected override void OnDeinitialize() => _ = Task.Run(SaveAsync);

    /// <inheritdoc/>
    public void Load()
    {
        var source = m_ValuesSource;
        source.Load();
        Root.Load(source);
    }

    /// <inheritdoc/>
    public void Save()
    {
        var source = m_ValuesSource;
        Root.Save(source);
        source.Save();
    }

    /// <inheritdoc/>
    public async Task LoadAsync()
    {
        var source = m_ValuesSource;
        await source.LoadAsync();
        Root.Load(source);
    }

    /// <inheritdoc/>
    public Task SaveAsync()
    {
        var source = m_ValuesSource;
        Root.Save(source);
        return source.SaveAsync();
    }
}