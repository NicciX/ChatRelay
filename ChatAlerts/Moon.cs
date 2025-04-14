using Dalamud.Game;
using Dalamud.IoC;
using Dalamud.Plugin;
using Dalamud.Plugin.Services;
using Dalamud.Game.ClientState.Objects;

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Local

namespace ChatAlerts;

public class Moon
{
    public static void Initialize(IDalamudPluginInterface pluginInterface)
        => pluginInterface.Create<Moon>();

    // @formatter:off
        [PluginService] public static ISigScanner Scanner { get; private set; } = null!;
        [PluginService] public static IDalamudPluginInterface PluginInterface { get; private set; } = null!;
        [PluginService] public static ICommandManager        Commands        { get; private set; } = null!;
        [PluginService] public static ISigScanner            SigScanner      { get; private set; } = null!;
        [PluginService] public static IDataManager           GameData        { get; private set; } = null!;
        [PluginService] public static IChatGui               Chat            { get; private set; } = null!;
        [PluginService] public static IPluginLog             Log             { get; private set; } = null!;
        [PluginService] public static IGameInteropProvider   Interop         { get; private set; } = null!;
        

        
    // @formatter:on


}
