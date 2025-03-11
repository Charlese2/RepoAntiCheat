using HarmonyLib;
using System.Text.RegularExpressions;

namespace RepoAntiCheat.Patches
{
    class PlayerNamePatch
    {
        [HarmonyPatch(typeof(WorldSpaceUIParent), nameof(WorldSpaceUIParent.PlayerName))]
        internal static class SanitizePlayerName
        {
            public static void Prefix(ref PlayerAvatar _player)
            {
                string sanitizedName;
                sanitizedName = Regex.Replace(_player.playerName, @"<(\S+?)>", "");

                if (sanitizedName.Length > 32)
                {
                    sanitizedName = sanitizedName[..32];
                }

                _player.playerName = sanitizedName;
            }
        }
    }
}
