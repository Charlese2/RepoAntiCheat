using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RepoAntiCheat;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class AntiCheatPlugin : BaseUnityPlugin
{
    public static Dictionary<int, PlayerAvatar> playerActorNrToPlayerAvatarMap = [];
    public static AntiCheatPlugin Instance { get; private set; } = null!;
    internal static ManualLogSource Log { get; private set; } = null!;
    internal static Harmony? Harmony { get; set; }
    public static ConfigEntry<bool> configLogNonHostRevive = null!;

    internal static bool itemSetupOnCooldown;
    internal static bool navMeshSetupOnCooldown;


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
        // Create separate GameObject to be the plugin Instance so Coroutines can be run.
        // It avoids destruction if the BepInEx Manager gets destroyed.
        // Needs to check the current game object as the plugin would end up recursivly adding it's self.
        if (GameObject.Find("RepoAntiCheat") == null && name != "RepoAntiCheat")
        {
            GameObject RepoAntiCheat = new("RepoAntiCheat") { hideFlags = HideFlags.HideAndDontSave };
            DontDestroyOnLoad(RepoAntiCheat);
            Instance = RepoAntiCheat.AddComponent<AntiCheatPlugin>();
            return;
        }

        Log = base.Logger;

        configLogNonHostRevive = Config.Bind("Logging", "Log non-host revives", false,
            "Logs when clients other than the host revive people");

        Patch();

        Log.LogInfo($"{MyPluginInfo.PLUGIN_NAME} v{MyPluginInfo.PLUGIN_VERSION} has loaded!");
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

    internal static IEnumerator ItemSetupCooldown()
    {
        itemSetupOnCooldown = true;
        yield return new WaitForSeconds(1.0f);
        itemSetupOnCooldown = false;
    }

    internal static IEnumerator NavMeshSetupCooldown()
    {
        navMeshSetupOnCooldown = true;
        yield return new WaitForSeconds(1.0f);
        navMeshSetupOnCooldown = false;
    }
}
