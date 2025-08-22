using SAH.SC.Abstraction;
using SC;
using SC.Abstraction;
using SC.Extensions;
using Sugar.Object.Extensions;
using System.Collections.Generic;
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

    /// <inheritdoc/>
    public IConfigurationRoot Root { get; private set; }

    /// <inheritdoc/>
    public override int Order => (int)EServiceOrder.RootService;

    /// <inheritdoc/>
    public IEnumerable<IConfigurationOption> LoadedOptions => Root.LoadedOptions;

    /// <inheritdoc/>
    public IConfigurationSettings Settings => Root.Settings;

    IEnumerable<IReadOnlyConfigurationOption> IReadOnlyConfiguration.LoadedOptions => LoadedOptions;

    /// <inheritdoc/>
    public IEnumerable<IConfiguration> LoadedConfigurations => Root.LoadedConfigurations;

    /// <inheritdoc/>
    protected override void OnInitialized()
    {
        ConfigurationBuilder builder = new();

        if(!Directory.Exists(CONFUIGURATIONS_PATH))
        {
            Directory.CreateDirectory(CONFUIGURATIONS_PATH).Forget();
            return;
        }

        foreach(string filePath in Directory.GetFiles(CONFUIGURATIONS_PATH)) builder.Append(resolver.Resolve(filePath)).Forget();

        Root = builder.Build(ROOT_CONFIGURATION_NAME, settings);

        Task.Run(this.LoadAsync).Forget();
    }

    /// <inheritdoc/>
    protected override void OnDeinitialize() => Task.Run(this.SaveAsync).Forget();

    /// <inheritdoc/>
    public bool HasOption(string path) => Root.HasOption(path);

    /// <inheritdoc/>
    public IEnumerable<string> GetOptionsNames(string path) => Root.GetOptionsNames(path);

    /// <inheritdoc/>
    public IConfigurationOption<T> GetOption<T>(string path) => Root.GetOption<T>(path);

    /// <inheritdoc/>
    public IConfigurationOption<T> AddOption<T>(string path, T value) => Root.AddOption(path, value);

    /// <inheritdoc/>
    public void RemoveOption(string path) => Root.RemoveOption(path);

    /// <inheritdoc/>
    public bool HasConfiguration(string name) => Root.HasConfiguration(name);

    /// <inheritdoc/>
    public IConfiguration GetConfiguration(string name) => Root.GetConfiguration(name);

    /// <inheritdoc/>
    public void AddConfiguration(IConfiguration configuration) => Root.AddConfiguration(configuration);

    /// <inheritdoc/>
    public void RemoveConfiguration(string name) => Root.RemoveConfiguration(name);

    /// <inheritdoc/>
    public void Save(string path) => Root.Save(path);

    /// <inheritdoc/>
    public void Load(string path) => Root.Load(path);

    /// <inheritdoc/>
    public async Task SaveAsync(string path) => await Root.SaveAsync(path);

    /// <inheritdoc/>
    public async Task LoadAsync(string path) => await Root.LoadAsync(path);

    IReadOnlyConfigurationOption<T> IReadOnlyConfiguration.GetOption<T>(string path) => GetOption<T>(path);
}