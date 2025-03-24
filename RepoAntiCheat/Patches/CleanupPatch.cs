using HarmonyLib;
using static RepoAntiCheat.AntiCheatPlugin;

namespace RepoAntiCheat.Patches
{
    internal class CleanupPatch
    {
        [HarmonyPatch(typeof(SteamManager), nameof(SteamManager.LeaveLobby))]
        internal static class CleanupOnLeave
        {
            public static void Prefix()
            {
                playerActorNrToPlayerAvatarMap.Clear();
            }
        }
    }
}
