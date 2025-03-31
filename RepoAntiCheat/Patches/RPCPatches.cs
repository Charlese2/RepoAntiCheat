using HarmonyLib;
using Photon.Pun;
using System;
using System.Text.RegularExpressions;
using UnityEngine;
using static RepoAntiCheat.AntiCheatPlugin;

namespace RepoAntiCheat.Patches;

internal class RPCPatches
{
    [HarmonyPatch(typeof(Arena), nameof(Arena.CrownGrabRPC))]
    internal static class CrownGrab
    {
        public static bool Prefix(ref PhotonMessageInfo info)
        {
            if (info.Sender == null)
            {
                return true;
            }

            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call CrownGrabRPC " +
                    $"while not the master client ({PhotonNetwork.MasterClient}).");
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(Arena), nameof(Arena.PlayerKilledRPC))]
    internal static class PlayerKilled
    {
        public static bool Prefix(ref PhotonMessageInfo info)
        {
            if (info.Sender == null)
            {
                return true;
            }

            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call PlayerKilledRPC " +
                    $"while not the master client ({PhotonNetwork.MasterClient}).");
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(Arena), nameof(Arena.DestroyCrownCageRPC))]
    internal static class DestroyCrownCage
    {
        public static bool Prefix(ref PhotonMessageInfo info)
        {
            if (info.Sender == null)
            {
                return true;
            }

            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call DestroyCrownCageRPC " +
                    $"while not the master client ({PhotonNetwork.MasterClient}).");
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(EnemyParent), nameof(EnemyParent.DespawnRPC))]
    internal static class EnemyParent_Despawn
    {
        public static bool Prefix(ref PhotonMessageInfo info)
        {
            if (info.Sender == null)
            {
                return true;
            }

            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call EnemyParent.DespawnRPC " +
                    $"while not the master client ({PhotonNetwork.MasterClient}).");
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(EnemyRigidbody), nameof(EnemyRigidbody.GrabbedSetRPC))]
    internal static class EnemyRigidbody_GrabbedSet
    {
        public static bool Prefix(ref PhotonMessageInfo info)
        {
            if (info.Sender == null)
            {
                return true;
            }

            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call EnemyRigidbody.GrabbedSetRPC " +
                    $"while not the master client ({PhotonNetwork.MasterClient}).");
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(EnemyStateInvestigate), nameof(EnemyStateInvestigate.SetRPC))]
    internal static class EnemyStateInvestigate_Set
    {
        public static bool Prefix(ref PhotonMessageInfo info)
        {
            if (info.Sender == null)
            {
                return true;
            }

            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call EnemyStateInvestigate.SetRPC " +
                    $"while not the master client ({PhotonNetwork.MasterClient}).");
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(EnemyBang), nameof(EnemyBang.ExplodeRPC))]
    internal static class EnemyBang_Explode
    {
        public static bool Prefix(ref PhotonMessageInfo info)
        {
            if (info.Sender == null)
            {
                return true;
            }

            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call EnemyBang.ExplodeRPC " +
                    $"while not the master client ({PhotonNetwork.MasterClient}).");
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(EnemyCeilingEye), nameof(EnemyCeilingEye.UpdatePositionRPC))]
    internal static class EnemyCeilingEye_UpdatePosition
    {
        public static bool Prefix(ref PhotonMessageInfo info)
        {
            if (info.Sender == null)
            {
                return true;
            }

            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call EnemyCeilingEye.UpdatePositionRPC " +
                    $"while not the master client ({PhotonNetwork.MasterClient}).");
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(EnemyDuck), nameof(EnemyDuck.UpdatePlayerTargetRPC))]
    internal static class EnemyDuck_UpdatePlayerTarget
    {
        public static bool Prefix(ref PhotonMessageInfo info)
        {
            if (info.Sender == null)
            {
                return true;
            }

            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call EnemyDuck.UpdatePlayerTargetRPC " +
                    $"while not the master client ({PhotonNetwork.MasterClient}).");
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(EnemyFloater), nameof(EnemyFloater.NoticeRPC))]
    internal static class EnemyFloater_Notice
    {
        public static bool Prefix(ref PhotonMessageInfo info)
        {
            if (info.Sender == null)
            {
                return true;
            }

            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call EnemyFloater.NoticeRPC " +
                    $"while not the master client ({PhotonNetwork.MasterClient}).");
                return false;
            }

            return true;
        }
    }



    [HarmonyPatch(typeof(EnemyHidden), nameof(EnemyHidden.UpdatePlayerTargetRPC))]
    internal static class EnemyHidden_UpdatePlayerTarget
    {
        public static bool Prefix(ref PhotonMessageInfo info)
        {
            if (info.Sender == null)
            {
                return true;
            }

            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call EnemyHidden.UpdatePlayerTargetRPC " +
                    $"while not the master client ({PhotonNetwork.MasterClient}).");
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(EnemyHunter), nameof(EnemyHunter.UpdateInvestigationPoint))]
    internal static class EnemyHunter_UpdateInvestigationPoint
    {
        public static bool Prefix(ref PhotonMessageInfo info)
        {
            if (info.Sender == null)
            {
                return true;
            }

            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call EnemyHunter.UpdateInvestigationPoint " +
                    $"while not the master client ({PhotonNetwork.MasterClient}).");
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(EnemyJump), nameof(EnemyJump.JumpingSetRPC))]
    internal static class EnemyJump_JumpingSet
    {
        public static bool Prefix(ref PhotonMessageInfo info)
        {
            if (info.Sender == null)
            {
                return true;
            }

            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call EnemyJump.JumpingSetRPC " +
                    $"while not the master client ({PhotonNetwork.MasterClient}).");
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(EnemyJump), nameof(EnemyJump.JumpingDelaySetRPC))]
    internal static class EnemyJump_JumpingDelaySet
    {
        public static bool Prefix(ref PhotonMessageInfo info)
        {
            if (info.Sender == null)
            {
                return true;
            }

            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call EnemyJump.JumpingDelaySetRPC " +
                    $"while not the master client ({PhotonNetwork.MasterClient}).");
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(EnemyJump), nameof(EnemyJump.LandDelaySetRPC))]
    internal static class EnemyJump_LandDelaySet
    {
        public static bool Prefix(ref PhotonMessageInfo info)
        {
            if (info.Sender == null)
            {
                return true;
            }

            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call EnemyJump.LandDelaySetRPC " +
                    $"while not the master client ({PhotonNetwork.MasterClient}).");
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(EnemyRobe), nameof(EnemyRobe.TargetPlayerRPC))]
    internal static class EnemyRobe_TargetPlayer
    {
        public static bool Prefix(ref PhotonMessageInfo info)
        {
            if (info.Sender == null)
            {
                return true;
            }

            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call EnemyRobe.TargetPlayerRPC " +
                    $"while not the master client ({PhotonNetwork.MasterClient}).");
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(EnemyRobe), nameof(EnemyRobe.UpdateStateRPC))]
    internal static class EnemyRobe_UpdateState
    {
        public static bool Prefix(ref PhotonMessageInfo info)
        {
            if (info.Sender == null)
            {
                return true;
            }

            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call EnemyRobe.UpdateStateRPC " +
                    $"while not the master client ({PhotonNetwork.MasterClient}).");
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(EnemyRunner), nameof(EnemyRunner.TargetPlayerRPC))]
    internal static class EnemyRunner_TargetPlayer
    {
        public static bool Prefix(ref PhotonMessageInfo info)
        {
            if (info.Sender == null)
            {
                return true;
            }

            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call EnemyRunner.TargetPlayerRPC " +
                    $"while not the master client ({PhotonNetwork.MasterClient}).");
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(EnemySlowMouth), nameof(EnemySlowMouth.IdleBreakerVORPC))]
    internal static class EnemySlowMouth_IdleBreakerVO
    {
        public static bool Prefix(ref PhotonMessageInfo info)
        {
            if (info.Sender == null)
            {
                return true;
            }

            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call EnemySlowMouth.IdleBreakerVORPC " +
                    $"while not the master client ({PhotonNetwork.MasterClient}).");
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(EnemyTumbler), nameof(EnemyTumbler.TargetPlayerRPC))]
    internal static class EnemyTumbler_TargetPlayer
    {
        public static bool Prefix(ref PhotonMessageInfo info)
        {
            if (info.Sender == null)
            {
                return true;
            }

            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call EnemyTumbler.IdleBreakerVORPC " +
                    $"while not the master client ({PhotonNetwork.MasterClient}).");
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(EnemyTumbler), nameof(EnemyTumbler.OnHurtColliderImpactAnyRPC))]
    internal static class EnemyTumbler_OnHurtColliderImpactAny
    {
        public static bool Prefix(ref PhotonMessageInfo info)
        {
            if (info.Sender == null)
            {
                return true;
            }

            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call EnemyTumbler.OnHurtColliderImpactAnyRPC " +
                    $"while not the master client ({PhotonNetwork.MasterClient}).");
                return false;
            }

            return true;
        }
    }

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
                Log.LogInfo($"Player ({info.Sender}) tried to call SpawnRPC with a position of {position}" +
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
        public static void Prefix(PlayerAvatar __instance, ref PhotonMessageInfo info)
        {
            if (configLogNonHostRevive.Value && info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) revived ({__instance.playerName})");
            }
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
                Log.LogInfo($"Player ({info.Sender}) tried to call HaulGoalSetRPC with a value of ({value}) " +
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

    [HarmonyPatch(typeof(ExtractionPoint), nameof(ExtractionPoint.StateSetRPC))]
    internal static class StateSet
    {
        public static bool Prefix(ref PhotonMessageInfo info)
        {
            if (info.Sender == null)
            {
                return true;
            }

            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call StateSetRPC " +
                    $"while not the master client ({PhotonNetwork.MasterClient}).");
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(LevelMusic), nameof(LevelMusic.PlayTrack))]
    internal static class PlayTrack
    {
        public static bool Prefix(ref PhotonMessageInfo info)
        {
            if (info.Sender == null)
            {
                return true;
            }

            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call PlayTrack " +
                    $"while not the master client ({PhotonNetwork.MasterClient}).");
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(ItemAttributes), nameof(ItemAttributes.GetValueRPC))]
    internal static class GetValue
    {
        public static bool Prefix(ItemAttributes __instance, int _value, ref PhotonMessageInfo info)
        {
            if (info.Sender == null)
            {
                return true;
            }

            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call GetValueRPC " +
                    $"on ({__instance.gameObject.name}) with a value of ({_value})" +
                    $"while not the master client ({PhotonNetwork.MasterClient}).");
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(ItemGun), nameof(ItemGun.ShootBulletRPC))]
    internal static class ShootBullet
    {
        public static bool Prefix(ref PhotonMessageInfo info)
        {
            if (info.Sender == null)
            {
                return true;
            }

            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call ShootBulletRPC " +
                    $"while not the master client ({PhotonNetwork.MasterClient}).");
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(MapToolController), nameof(MapToolController.SetActiveRPC))]
    internal static class SetActive
    {
        public static bool Prefix(MapToolController __instance, ref PhotonMessageInfo info)
        {
            if (info.Sender == null)
            {
                return true;
            }

            if (info.Sender != __instance.photonView.Owner)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call SetActiveRPC " +
                    $"for another client ({__instance.photonView.Owner}).");
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

    [HarmonyPatch(typeof(RoundDirector), nameof(RoundDirector.ExtractionPointsUnlockRPC))]
    internal static class ExtractionPointsUnlock
    {
        public static bool Prefix(ref PhotonMessageInfo info)
        {
            if (info.Sender == null)
            {
                return true;
            }

            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call ExtractionPointsUnlockRPC " +
                    $"while not the master client ({PhotonNetwork.MasterClient}).");
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(PlayerHealth), nameof(PlayerHealth.UpdateHealthRPC))]
    internal static class UpdateHealth
    {
        public static bool Prefix(PlayerHealth __instance, ref PhotonMessageInfo info)
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

    [HarmonyPatch(typeof(PlayerTumble), nameof(PlayerTumble.TumbleSetRPC))]
    internal static class TumbleSet
    {
        public static bool Prefix(ref PhotonMessageInfo info)
        {
            if (info.Sender == null)
            {
                return true;
            }

            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call TumbleSetRPC " +
                    $"while not the master client ({PhotonNetwork.MasterClient}).");
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(PunManager), nameof(PunManager.SetItemNameRPC))]
    internal static class SetItemName
    {
        public static bool Prefix(string name, int photonViewID, ref PhotonMessageInfo info)
        {
            if (info.Sender != PhotonNetwork.MasterClient)
            {
                PhotonView photonView = PhotonView.Find(photonViewID);

                if (photonView == null || !photonView.TryGetComponent(out ItemAttributes itemAttributes))
                {
                    Log.LogInfo($"Player ({info.Sender}) tried to call SetItemNameRPC with an invalid photonViewID ({photonViewID}).");
                    return false;
                }

                Log.LogInfo($"Player ({info.Sender}) tried to call SetItemNameRPC " +
                    $"with a name of ({itemAttributes.instanceName}) to new name ({name}) " +
                    $"while not the master client ({PhotonNetwork.MasterClient}).");
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(PunManager), nameof(PunManager.SetRunStatRPC))]
    internal static class SetRunStat
    {
        public static bool Prefix(string statName, int value, ref PhotonMessageInfo info)
        {
            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call SetRunStatRPC " +
                    $"to set stat ({statName}) with a value of ({value})" +
                    $"while not the master client ({PhotonNetwork.MasterClient}).");
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(PunManager), nameof(PunManager.ReceiveSyncData))]
    internal static class ReceiveSyncData
    {
        public static bool Prefix(ref PhotonMessageInfo info)
        {
            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call ReceiveSyncData" +
                    $"while not the master client ({PhotonNetwork.MasterClient}).");
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(PunManager), nameof(PunManager.UpdateStatRPC))]
    internal static class UpdateStat
    {
        public static bool Prefix(string dictionaryName, string key, int value, ref PhotonMessageInfo info)
        {
            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call UpdateStatRPC " +
                    $"with input of [({dictionaryName}), ({key}), ({value})]" +
                    $"while not the master client ({PhotonNetwork.MasterClient}).");
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(PunManager), nameof(PunManager.UpdateShoppingCostRPC))]
    internal static class UpdateShoppingCost
    {
        public static bool Prefix(int value, ref PhotonMessageInfo info)
        {
            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call UpdateShoppingCostRPC with a value of ({value})" +
                    $"while not the master client ({PhotonNetwork.MasterClient}).");
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(PunManager), nameof(PunManager.SyncHaul))]
    internal static class SyncHaul
    {
        public static bool Prefix(int value, ref PhotonMessageInfo info)
        {
            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call SyncHaul with a value of ({value})" +
                    $"while not the master client ({PhotonNetwork.MasterClient}).");
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(PunManager), nameof(PunManager.UpgradeItemBatteryRPC))]
    internal static class UpgradeItemBattery
    {
        public static bool Prefix(string itemName, int value, ref PhotonMessageInfo info)
        {
            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call UpgradeItemBatteryRPC " +
                    $"with item name of ({itemName}) and a value of ({value}) " +
                    $"while not the master client ({PhotonNetwork.MasterClient}).");
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(PunManager), nameof(PunManager.UpgradePlayerEnergyRPC))]
    internal static class UpgradePlayerEnergy
    {
        public static bool Prefix(int value, ref PhotonMessageInfo info)
        {
            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call UpgradePlayerEnergyRPC with a value of ({value}) " +
                    $"while not the master client ({PhotonNetwork.MasterClient}).");
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(PunManager), nameof(PunManager.UpgradePlayerExtraJumpRPC))]
    internal static class UpgradePlayerExtraJump
    {
        public static bool Prefix(int value, ref PhotonMessageInfo info)
        {
            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call UpgradePlayerExtraJumpRPC with a value of ({value}) " +
                    $"while not the master client ({PhotonNetwork.MasterClient}).");
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(PunManager), nameof(PunManager.UpgradePlayerGrabRangeRPC))]
    internal static class UpgradePlayerGrabRange
    {
        public static bool Prefix(int value, ref PhotonMessageInfo info)
        {
            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call UpgradePlayerGrabRangeRPC with a value of ({value}) " +
                    $"while not the master client ({PhotonNetwork.MasterClient}).");
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(PunManager), nameof(PunManager.UpgradePlayerGrabStrengthRPC))]
    internal static class UpgradePlayerGrabStrength
    {
        public static bool Prefix(int value, ref PhotonMessageInfo info)
        {
            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call UpgradePlayerGrabStrengthRPC with a value of ({value}) " +
                    $"while not the master client ({PhotonNetwork.MasterClient}).");
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(PunManager), nameof(PunManager.UpgradePlayerHealthRPC))]
    internal static class UpgradePlayerHealth
    {
        public static bool Prefix(int value, ref PhotonMessageInfo info)
        {
            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call UpgradePlayerHealthRPC with a value of ({value}) " +
                    $"while not the master client ({PhotonNetwork.MasterClient}).");
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(PunManager), nameof(PunManager.UpgradePlayerSprintSpeedRPC))]
    internal static class UpgradePlayerSprintSpeed
    {
        public static bool Prefix(int value, ref PhotonMessageInfo info)
        {
            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call UpgradePlayerSprintSpeedRPC with a value of ({value}) " +
                    $"while not the master client ({PhotonNetwork.MasterClient}).");
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(PunManager), nameof(PunManager.UpgradePlayerThrowStrengthRPC))]
    internal static class UpgradePlayerThrowStrength
    {
        public static bool Prefix(int value, ref PhotonMessageInfo info)
        {
            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call UpgradePlayerThrowStrengthRPC with a value of ({value}) " +
                    $"while not the master client ({PhotonNetwork.MasterClient}).");
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(PunManager), nameof(PunManager.UpgradePlayerTumbleLaunchRPC))]
    internal static class UpgradePlayerTumbleLaunch
    {
        public static bool Prefix(int value, ref PhotonMessageInfo info)
        {
            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call UpgradePlayerTumbleLaunchRPC with a value of ({value}) " +
                    $"while not the master client ({PhotonNetwork.MasterClient}).");
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(RoundDirector), nameof(RoundDirector.ExtractionCompletedAllRPC))]
    internal static class ExtractionCompleteAll
    {
        public static bool Prefix(ref PhotonMessageInfo info)
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

    [HarmonyPatch(typeof(TruckScreenText), nameof(TruckScreenText.GotoPageRPC))]
    internal static class GotoPage
    {
        public static bool Prefix(ref PhotonMessageInfo info)
        {
            if (info.Sender == null)
            {
                return true;
            }

            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call GotoPageRPC " +
                    $"while not the master client ({PhotonNetwork.MasterClient}).");
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(StaticGrabObject), nameof(StaticGrabObject.DestroyPhysGrabObjectRPC))]
    internal static class DestroyPhysGrabObject
    {
        public static bool Prefix(ref PhotonMessageInfo info)
        {
            if (info.Sender == null)
            {
                return true;
            }

            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call DestroyPhysGrabObjectRPC " +
                    $"while not the master client ({PhotonNetwork.MasterClient}).");
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(LevelGenerator), nameof(LevelGenerator.EnemySpawnTargetRPC))]
    internal static class EnemySpawnTarget
    {
        public static bool Prefix(int _amount, ref PhotonMessageInfo info)
        {
            if (info.Sender == null)
            {
                return true;
            }

            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call EnemySpawnTargetRPC with an amount of ({_amount})" +
                    $"while not the master client ({PhotonNetwork.MasterClient}).");
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(LevelGenerator), nameof(LevelGenerator.GenerateDone))]
    internal static class GenerateDone
    {
        public static bool Prefix(ref PhotonMessageInfo info)
        {
            if (info.Sender == null)
            {
                return true;
            }

            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call GenerateDone " +
                    $"while not the master client ({PhotonNetwork.MasterClient}).");
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(LevelGenerator), nameof(LevelGenerator.ItemSetup))]
    internal static class ItemSetup
    {
        public static bool Prefix(ref PhotonMessageInfo info)
        {
            if (info.Sender == null)
            {
                return true;
            }

            if (itemSetupOnCooldown)
            {
                return false;
            }

            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call ItemSetup " +
                    $"while not the master client ({PhotonNetwork.MasterClient}).");
                return false;
            }

            Instance.StartCoroutine(ItemSetupCooldown());

            return true;
        }
    }

    [HarmonyPatch(typeof(LevelGenerator), nameof(LevelGenerator.NavMeshSetupRPC))]
    internal static class NavMeshSetup
    {
        public static bool Prefix(ref PhotonMessageInfo info)
        {
            if (info.Sender == null)
            {
                return true;
            }

            if (navMeshSetupOnCooldown)
            {
                return false;
            }

            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call NavMeshSetupRPC " +
                    $"while not the master client ({PhotonNetwork.MasterClient}).");
                return false;
            }

            Instance.StartCoroutine(NavMeshSetupCooldown());

            return true;
        }
    }

    [HarmonyPatch(typeof(RunManagerPUN), nameof(RunManagerPUN.UpdateLevelRPC))]
    internal static class UpdateLevel
    {
        public static bool Prefix(ref PhotonMessageInfo info)
        {
            if (info.Sender == null)
            {
                return true;
            }

            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call UpdateLevelRPC " +
                    $"while not the master client ({PhotonNetwork.MasterClient}).");
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(ValuableDirector), nameof(ValuableDirector.ValuablesTargetSetRPC))]
    internal static class ValuablesTargetSet
    {
        public static bool Prefix(int _amount, ref PhotonMessageInfo info)
        {
            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call ValuablesTargetSetRPC with an amount of ({_amount})" +
                    $"while not the master client ({PhotonNetwork.MasterClient}).");
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(ValuableDirector), nameof(ValuableDirector.VolumesAndSwitchSetupRPC))]
    internal static class VolumesAndSwitchSetup
    {
        public static bool Prefix(ref PhotonMessageInfo info)
        {
            if (info.Sender == null)
            {
                return true;
            }

            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call VolumesAndSwitchSetupRPC " +
                    $"while not the master client ({PhotonNetwork.MasterClient}).");
                return false;
            }

            return true;
        }
    }
    
    [HarmonyPatch(typeof(ValuableObject), nameof(ValuableObject.DollarValueSetRPC))]
    internal static class DollarValueSet
    {
        public static bool Prefix(float value, ref PhotonMessageInfo info)
        {
            if (info.Sender != PhotonNetwork.MasterClient)
            {
                Log.LogInfo($"Player ({info.Sender}) tried to call DollarValueSetRPC with a value of ({value})" +
                    $"while not the master client ({PhotonNetwork.MasterClient}).");
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(ValuableObject), nameof(ValuableObject.DiscoverRPC))]
    internal static class Discover
    {
        public static bool Prefix(ValuableObject __instance)
        {
            if (__instance.discovered == true)
            {
                return false;
            }

            return true;
        }
    }
}
