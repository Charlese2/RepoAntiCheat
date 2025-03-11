using HarmonyLib;
using System.Text.RegularExpressions;
using Unity.VisualScripting;

namespace RepoAntiCheat.Patches
{
    class PlayerNamePatch
    {
        [HarmonyPatch(typeof(WorldSpaceUIParent), nameof(WorldSpaceUIParent.PlayerName))]
        internal static class AddToStatsManager
        {
            public static void Prefix(ref PlayerAvatar _player)
            {
                string sanitizedName;
                sanitizedName = Regex.Replace(_player.playerName, @"<(\S+?)>", "");

                _player.playerName = sanitizedName.ToShortString(32);
            }
        }
    }
}
