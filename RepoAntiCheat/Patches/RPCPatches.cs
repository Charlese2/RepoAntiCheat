using HarmonyLib;
using Photon.Pun;
using System.Text.RegularExpressions;
using UnityEngine;
using static RepoAntiCheat.RepoAntiCheat;

namespace RepoAntiCheat.Patches;

internal class RPCPatches
{
    [HarmonyPatch(typeof(PlayerAvatar), nameof(PlayerAvatar.ChatMessageSendRPC))]
    internal static class ChatMesageSend
    {
        public static bool Prefix(PlayerAvatar __instance, ref string _message, ref PhotonMessageInfo info)
        {
            if (__instance.photonView.Owner != info.Sender)
            {
                Log.LogInfo($"ChatMessage ({_message}) owner ({info.photonView.Owner}) does not match sender ({info.Sender}).");
                return false;
            }

            string sanitizedChatMessage;
            sanitizedChatMessage = Regex.Replace(_message, @"<(\S+?)>", "");

            if (sanitizedChatMessage.Length > 50)
            {
                sanitizedChatMessage = sanitizedChatMessage[..50];
            }

            if (string.IsNullOrWhiteSpace(sanitizedChatMessage))
            {
                Log.LogInfo($"{info.Sender} Chat message was empty. Original Message: ({_message})");
                return false;
            }

            _message = sanitizedChatMessage;

            return true;
        }
    }

    [HarmonyPatch(typeof(PlayerAvatar), nameof(PlayerAvatar.AddToStatsManagerRPC))]
    internal static class AddToStatsManager
    {
        public static bool Prefix(PlayerAvatar __instance, ref string _playerName, ref PhotonMessageInfo info)
        {
            if (info.Sender == null)
            {
                return true;
            }

            if (__instance.photonView.Owner != info.Sender)
            {
                return false;
            }

            string sanitizedName;
            sanitizedName = Regex.Replace(_playerName, @"<(\S+?)>", "");

            if (sanitizedName.Length > 32)
            {
                sanitizedName = sanitizedName[..32];
            }

            _playerName = sanitizedName;

            return true;
        }
    }

    [HarmonyPatch(typeof(PlayerAvatar), nameof(PlayerAvatar.SpawnRPC))]
    internal static class SpawnPlayer
    {
        public static bool Prefix(PlayerAvatar __instance, Vector3 position, ref PhotonMessageInfo info)
        {
            if (info.Sender == null)
            {
                return true;
            }

            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call SpawnRPC " +
                    $"for ({__instance.photonView.Owner}) while not the master client ({PhotonNetwork.MasterClient}).");
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(PlayerAvatar), nameof(PlayerAvatar.PlayerDeathRPC))]
    internal static class PlayerDeath
    {
        public static bool Prefix(PlayerAvatar __instance, ref PhotonMessageInfo info)
        {
            if (info.Sender == null)
            {
                return true;
            }

            if (info.Sender != PhotonNetwork.MasterClient && info.Sender != __instance.photonView.Owner)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call PlayerDeathRPC " +
                    $"while not the master client ({PhotonNetwork.MasterClient}) " +
                    $"or the the owner ({__instance.photonView.Owner}).");
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(PlayerAvatar), nameof(PlayerAvatar.ReviveRPC))]
    internal static class Revive
    {
        public static bool Prefix(PlayerAvatar __instance, bool _revivedByTruck, ref PhotonMessageInfo info)
        {
            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"[ReviveRPC] STOPPED Player: ({__instance}) Sender: ({info.Sender}) _revivedByTruck: ({_revivedByTruck})");
                return false;
            }
            Log.LogInfo($"[ReviveRPC] Player: ({__instance}) Sender: ({info.Sender}) _revivedByTruck: ({_revivedByTruck})");

            return true;
        }
    }

    [HarmonyPatch(typeof(PlayerAvatar), nameof(PlayerAvatar.OutroStartRPC))]
    internal static class OutroStart
    {
        public static bool Prefix(PlayerAvatar __instance, ref PhotonMessageInfo info)
        {
            if (info.Sender == null)
            {
                return true;
            }

            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call OutroStartRPC " +
                    $"for ({__instance.photonView.Owner}) while not the master client ({PhotonNetwork.MasterClient}).");
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(ExtractionPoint), nameof(ExtractionPoint.HaulGoalSetRPC))]
    internal static class HaulGoalSet
    {
        public static bool Prefix(int value, ref PhotonMessageInfo info)
        {
            if (info.Sender == null)
            {
                return true;
            }

            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call HaulGoalSetRPC " +
                    $"while not the master client ({PhotonNetwork.MasterClient}).");
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(ExtractionPoint), nameof(ExtractionPoint.ExtractionPointSurplusRPC))]
    internal static class ExtractionPointSurplus
    {
        public static bool Prefix(int surplus, ref PhotonMessageInfo info)
        {
            if (info.Sender == null)
            {
                return true;
            }

            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call ExtractionPointSurplusRPC " +
                    $"while not the master client ({PhotonNetwork.MasterClient})" +
                    $"with a surplus of ({surplus})");
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(RoundDirector), nameof(RoundDirector.ExtractionPointActivateRPC))]
    internal static class ExtractionPointActivate
    {
        public static bool Prefix(ref PhotonMessageInfo info)
        {
            if (info.Sender == null)
            {
                return true;
            }

            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call ExtractionPointActivateRPC " +
                    $"while not the master client ({PhotonNetwork.MasterClient}).");
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(PlayerHealth), nameof(PlayerHealth.UpdateHealthRPC))]
    internal static class UpdateHealth
    {
        public static bool Prefix(PlayerHealth __instance, int healthNew, int healthMax, ref PhotonMessageInfo info)
        {
            if (info.Sender == null)
            {
                return true;
            }

            if (info.Sender != __instance.photonView.Owner)
            {
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(PlayerHealth), nameof(PlayerHealth.HealOtherRPC))]
    internal static class HealOther
    {
        public static bool Prefix(PlayerHealth __instance, int healAmount, ref PhotonMessageInfo info)
        {
            Log.LogInfo($"[HealOtherRPC] __instance.photonView.Owner ({__instance.photonView.Owner}) info.Sender: ({info.Sender})" +
                $"healAmount: ({healAmount}).");

            if (info.Sender == null)
            {
                return true;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(PlayerHealth), nameof(PlayerHealth.HurtOtherRPC))]
    internal static class HurtOther
    {
        public static bool Prefix(PlayerHealth __instance, int damage, ref PhotonMessageInfo info)
        {
            if (info.Sender == PhotonNetwork.MasterClient)
            {
                return true;
            }

            PlayerAvatar? sendingPlayer = GetPlayerAvatarFromActorNumber(info.Sender.ActorNumber);

            if (sendingPlayer != null && Vector3.Distance(sendingPlayer.transform.position, __instance.transform.position) > 2f)
            {
                Log.LogInfo($"{info.Sender} sent HurtOtherRPC with damage ({damage}) from too far away " +
                    $"({Vector3.Distance(sendingPlayer.transform.position, __instance.transform.position)}).");
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(RoundDirector), nameof(RoundDirector.ExtractionCompletedAllRPC))]
    internal static class ExtractionCompleteAll
    {
        public static bool Prefix(RoundDirector __instance, ref PhotonMessageInfo info)
        {
            if (info.Sender == null)
            {
                return true;
            }

            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call ExtractionCompletedAllRPC " +
                    $"while not the master client ({PhotonNetwork.MasterClient}).");
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(TruckScreenText), nameof(TruckScreenText.SelfDestructPlayersOutsideTruckRPC))]
    internal static class SelfDestructPlayersOutsideTruck
    {
        public static bool Prefix(ref PhotonMessageInfo info)
        {
            if (info.Sender == null)
            {
                return true;
            }

            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call SelfDestructPlayersOutsideTruckRPC " +
                    $"while not the master client ({PhotonNetwork.MasterClient}).");
                return false;
            }

            return true;
        }
    }
}
