using HarmonyLib;
using Photon.Pun;
using System.Text.RegularExpressions;
using UnityEngine;

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
                RepoAntiCheat.Logger.LogInfo($"ChatMessage ({_message}) owner ({info.photonView.Owner}) does not match sender ({info.Sender}).");
                return false;
            }

            string sanitizedChatMessage;
            sanitizedChatMessage = Regex.Replace(_message, @"<(\S+?)>", "($+)");

            if (sanitizedChatMessage.Length > 50)
            {
                sanitizedChatMessage = sanitizedChatMessage[..50];
            }

            if (string.IsNullOrWhiteSpace(sanitizedChatMessage))
            {
                RepoAntiCheat.Logger.LogInfo($"{info.Sender} Chat message was empty after sanitization. Original Message: ({_message})");
                return false;
            }

            _message = sanitizedChatMessage;

            return true;
        }
    }

    [HarmonyPatch(typeof(ExtractionPoint), nameof(ExtractionPoint.HaulGoalSetRPC))]
    internal static class HaulGoalSet
    {
        public static void Prefix(int value, ref PhotonMessageInfo info)
        {
            if (info.Sender == null)
            {
                return;
            }

            if (info.Sender != PhotonNetwork.MasterClient)
            {
                RepoAntiCheat.Logger.LogInfo($"Non-Master client ({info.Sender}) sent HaulGoalSetRPC with value of ({value}).");
            }
        }
    }

    [HarmonyPatch(typeof(RoundDirector), nameof(RoundDirector.ExtractionPointActivateRPC))]
    internal static class ExtractionPointActivate
    {
        public static void Prefix(ref PhotonMessageInfo info)
        {
            if (info.Sender == null)
            {
                return;
            }

            if (info.Sender != PhotonNetwork.MasterClient)
            {
                RepoAntiCheat.Logger.LogInfo($"Player ({info.Sender}) tried to call ExtractionPointActivateRPC " +
                    $"while not the master client ({PhotonNetwork.MasterClient}) ");
            }
        }
    }

    [HarmonyPatch(typeof(PlayerHealth), nameof(PlayerHealth.HurtOtherRPC))]
    internal static class HurtOther
    {
        public static bool Prefix(PlayerHealth __instance, int damage, ref PhotonMessageInfo info)
        {
            int senderActorNumber = info.Sender.ActorNumber;
            if (!RepoAntiCheat.playerActorNrToPlayerAvatarMap.TryGetValue(senderActorNumber, out PlayerAvatar sendingPlayer)) {
                foreach (PlayerAvatar playerAvatar in GameDirector.instance.PlayerList)
                {
                    if (playerAvatar.photonView.OwnerActorNr == senderActorNumber)
                    {
                        RepoAntiCheat.playerActorNrToPlayerAvatarMap.Add(senderActorNumber, playerAvatar);
                        sendingPlayer = playerAvatar;
                        break;
                    }
                }
            }

            if (sendingPlayer != null && Vector3.Distance(sendingPlayer.transform.position, __instance.transform.position) > 2f)
            {
                RepoAntiCheat.Logger.LogInfo($"{info.Sender} sent HurtOtherRPC with damage ({damage}) from too far away " +
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
                RepoAntiCheat.Logger.LogInfo($"Player ({info.Sender}) tried to call OutroStartRPC " +
                    $"for ({__instance.photonView.Owner}) while not the master client ({PhotonNetwork.MasterClient}) ");
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(TruckScreenText), nameof (TruckScreenText.SelfDestructPlayersOutsideTruckRPC))]
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
                RepoAntiCheat.Logger.LogInfo($"Player ({info.Sender}) tried to call SelfDestructPlayersOutsideTruckRPC " +
                    $"while not the master client ({PhotonNetwork.MasterClient}) ");
                return false;
            }

            return true;
        } 
    }
}
