using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using Photon.Pun.UtilityScripts;
using System.Collections.Generic;

namespace RepoAntiCheat;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class RepoAntiCheat : BaseUnityPlugin
{
    public static Dictionary<int, PlayerAvatar> playerActorNrToPlayerAvatarMap = [];
    public static RepoAntiCheat Instance { get; private set; } = null!;
    internal static ManualLogSource Log { get; private set; } = null!;
    internal static Harmony? Harmony { get; set; }
    public static ConfigEntry<bool> configLogNonHostRevive = null!;

    private static void PlayerNumberingChanged()
    {
        Log.LogInfo("PlayerNumberingChanged");
        playerActorNrToPlayerAvatarMap.Clear();
    }

    public static PlayerAvatar? GetPlayerAvatarFromActorNumber(int actorNumber)
    {
        if (!playerActorNrToPlayerAvatarMap.TryGetValue(actorNumber, out PlayerAvatar playerAvatar))
        {
            foreach (PlayerAvatar newPlayerAvatar in GameDirector.instance.PlayerList)
            {
                if (newPlayerAvatar.photonView.OwnerActorNr == actorNumber)
                {
                    playerActorNrToPlayerAvatarMap.Add(actorNumber, newPlayerAvatar);
                    return newPlayerAvatar;
                }
            }
        }

        return playerAvatar;
    }

    private void Awake()
    {
        Log = base.Logger;
        Instance = this;

        configLogNonHostRevive = Config.Bind("Logging", "Log non-host revives", false,
            "Logs when clients other than the host revive people");

        Patch();
        PlayerNumbering.OnPlayerNumberingChanged += PlayerNumberingChanged;

        Log.LogInfo($"{MyPluginInfo.PLUGIN_NAME} v{MyPluginInfo.PLUGIN_VERSION} has loaded!");
    }

    private void OnDestroy()
    {
        PlayerNumbering.OnPlayerNumberingChanged -= PlayerNumberingChanged;
        Unpatch();
        Log.LogInfo($"{MyPluginInfo.PLUGIN_NAME} v{MyPluginInfo.PLUGIN_VERSION} has unloaded!");
    }

    internal static void Patch()
    {
        Harmony ??= new Harmony(MyPluginInfo.PLUGIN_GUID);

        Log.LogDebug("Patching...");

        Harmony.PatchAll();

        Log.LogDebug("Finished patching!");
    }

    internal static void Unpatch()
    {
        Log.LogDebug("Unpatching...");

        Harmony?.UnpatchSelf();

        Log.LogDebug("Finished unpatching!");
    }
}
