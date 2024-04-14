using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace Computerdores.BetterTerminal;

[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
public class BetterTerminal : BaseUnityPlugin
{
    private static BetterTerminal Instance { get; set; }

    public static ManualLogSource Log => Instance.Logger;

    private readonly Harmony _harmony = new(PluginInfo.PLUGIN_GUID);

    public BetterTerminal() {
        Instance = this;
    }
}
