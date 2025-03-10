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



            if (_message.Length > 50)
            {
                _message = _message[..50];
            }

            string sanitizedChatMessage;
            sanitizedChatMessage = Regex.Replace(_message, @"<(\S+?)>", "($+)");

            if (string.IsNullOrWhiteSpace(sanitizedChatMessage))
            {
                Log.LogInfo($"{info.Sender} Chat message was empty. Original Message: ({_message})");
                return false;
            }

            _message = sanitizedChatMessage;

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
                    $"while not the master client ({PhotonNetwork.MasterClient}) ");
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
                    $"while not the master client ({PhotonNetwork.MasterClient}) ");
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(PlayerHealth), nameof(PlayerHealth.HurtOtherRPC))]
    internal static class HurtOther
    {
        public static bool Prefix(PlayerHealth __instance, int damage, ref PhotonMessageInfo info)
        {
            PlayerAvatar? sendingPlayer = GetPlayerAvatarFromActorNumber(info.Sender.ActorNumber);

            if (sendingPlayer != null && Vector3.Distance(sendingPlayer.transform.position, __instance.transform.position) > 2f)
            {
                Log.LogInfo($"{info.Sender} sent HurtOtherRPC with damage ({damage}) from too far away " +
                    $"({Vector3.Distance(sendingPlayer.transform.position, __instance.transform.position)})");
                return false;
            }

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
                    $"for ({__instance.photonView.Owner}) while not the master client ({PhotonNetwork.MasterClient}) ");
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
                    $"while not the master client ({PhotonNetwork.MasterClient}) ");
                return false;
            }

            return true;
        }
    }
}
