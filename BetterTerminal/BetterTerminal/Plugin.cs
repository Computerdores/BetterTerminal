using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace Computerdores.BetterTerminal;

[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
[BepInDependency("AdvancedTerminalAPI")]
[BepInDependency("com.rune580.LethalCompanyInputUtils")]
public class Plugin : BaseUnityPlugin
{
    private static Plugin Instance { get; set; }

    public static ManualLogSource Log => Instance.Logger;

    public static InputHandler InputHandler;

    private readonly Harmony _harmony = new(PluginInfo.PLUGIN_GUID);

    public Plugin() {
        Instance = this;
    }

    public void Awake() {
        InputHandler = new InputHandler();
        AdvancedTerminalAPI.Plugin.ReplaceITerminal(d => new VanillinPlusTerminal(d));
    }
}
