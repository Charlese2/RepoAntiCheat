using HarmonyLib;
using Photon.Pun;
using System.Text.RegularExpressions;
using UnityEngine;
using static RepoAntiCheat.AntiCheatPlugin;

namespace RepoAntiCheat.Patches;

internal class RPCPatches
{
    //[HarmonyPatch(typeof(EnemyJump), nameof(EnemyJump.JumpingSetRPC))]
    //internal static class EnemyJump_JumpingSet
    //{
    //    public static bool Prefix(ref PhotonMessageInfo _info)
    //    {
    //        if (_info.Sender == null)
    //        {
    //            return true;
    //        }

    //        if (_info.Sender != PhotonNetwork.MasterClient)
    //        {
    //            Log.LogInfo($"Player ({_info.Sender}) tried to call EnemyJump.JumpingSetRPC " +
    //                $"while not the master client ({PhotonNetwork.MasterClient}).");
    //            return false;
    //        }

    //        return true;
    //    }
    //}

    //[HarmonyPatch(typeof(EnemyJump), nameof(EnemyJump.JumpingDelaySetRPC))]
    //internal static class EnemyJump_JumpingDelaySet
    //{
    //    public static bool Prefix(ref PhotonMessageInfo _info)
    //    {
    //        if (_info.Sender == null)
    //        {
    //            return true;
    //        }

    //        if (_info.Sender != PhotonNetwork.MasterClient)
    //        {
    //            Log.LogInfo($"Player ({_info.Sender}) tried to call EnemyJump.JumpingDelaySetRPC " +
    //                $"while not the master client ({PhotonNetwork.MasterClient}).");
    //            return false;
    //        }

    //        return true;
    //    }
    //}

    //[HarmonyPatch(typeof(EnemyJump), nameof(EnemyJump.LandDelaySetRPC))]
    //internal static class EnemyJump_LandDelaySet
    //{
    //    public static bool Prefix(ref PhotonMessageInfo _info)
    //    {
    //        if (_info.Sender == null)
    //        {
    //            return true;
    //        }

    //        if (_info.Sender != PhotonNetwork.MasterClient)
    //        {
    //            Log.LogInfo($"Player ({_info.Sender}) tried to call EnemyJump.LandDelaySetRPC " +
    //                $"while not the master client ({PhotonNetwork.MasterClient}).");
    //            return false;
    //        }

    //        return true;
    //    }
    //}

    //[HarmonyPatch(typeof(ItemAttributes), nameof(ItemAttributes.GetValueRPC))]
    //internal static class GetValue
    //{
    //    public static bool Prefix(ItemAttributes __instance, int _value, ref PhotonMessageInfo _info)
    //    {
    //        if (_info.Sender == null)
    //        {
    //            return true;
    //        }

    //        if (_info.Sender != PhotonNetwork.MasterClient)
    //        {
    //            Log.LogInfo($"Player ({_info.Sender}) tried to call GetValueRPC " +
    //                $"on ({__instance.gameObject.name}) with a value of ({_value})" +
    //                $"while not the master client ({PhotonNetwork.MasterClient}).");
    //            return false;
    //        }

    //        return true;
    //    }
    //}

    //[HarmonyPatch(typeof(MapToolController), nameof(MapToolController.SetActiveRPC))]
    //internal static class SetActive
    //{
    //    public static bool Prefix(MapToolController __instance, ref PhotonMessageInfo _info)
    //    {
    //        if (_info.Sender == null)
    //        {
    //            return true;
    //        }

    //        if (_info.Sender != __instance.photonView.Owner)
    //        {
    //            Log.LogInfo($"Player ({_info.Sender}) tried to call SetActiveRPC " +
    //                $"for another client ({__instance.photonView.Owner}).");
    //            return false;
    //        }

    //        return true;
    //    }
    //}

    [HarmonyPatch(typeof(PlayerHealth), nameof(PlayerHealth.HurtOtherRPC))]
    internal static class HurtOther
    {
        public static bool Prefix(PlayerHealth __instance, int damage, ref PhotonMessageInfo _info)
        {
            PlayerAvatar? sendingPlayer = GetPlayerAvatarFromActorNumber(_info.Sender.ActorNumber);

            if (sendingPlayer != null && Vector3.Distance(sendingPlayer.transform.position, __instance.transform.position) > 2f)
            {
                Log.LogInfo($"{_info.Sender} sent HurtOtherRPC with damage ({damage}) from too far away " +
                    $"({Vector3.Distance(sendingPlayer.transform.position, __instance.transform.position)}).");
                return false;
            }

            return true;
        }
    }

    //[HarmonyPatch(typeof(PhysGrabObject), nameof(PhysGrabObject.DestroyPhysGrabObjectRPC))]
    //internal static class PhysGrabObject_DestroyPhysGrabObject
    //{
    //    public static bool Prefix(ref PhotonMessageInfo _info)
    //    {
    //        if (_info.Sender == null)
    //        {
    //            return true;
    //        }

    //        if (_info.Sender != PhotonNetwork.MasterClient)
    //        {
    //            Log.LogInfo($"Player ({_info.Sender}) tried to call PhysGrabObject.DestroyPhysGrabObjectRPC " +
    //                $"while not the master client ({PhotonNetwork.MasterClient}).");
    //            return false;
    //        }

    //        return true;
    //    }
    //}

    //[HarmonyPatch(typeof(TruckScreenText), nameof(TruckScreenText.GotoPageRPC))]
    //internal static class GotoPage
    //{
    //    public static bool Prefix(ref PhotonMessageInfo _info)
    //    {
    //        if (_info.Sender == null)
    //        {
    //            return true;
    //        }

    //        if (_info.Sender != PhotonNetwork.MasterClient)
    //        {
    //            Log.LogInfo($"Player ({_info.Sender}) tried to call GotoPageRPC " +
    //                $"while not the master client ({PhotonNetwork.MasterClient}).");
    //            return false;
    //        }

    //        return true;
    //    }
    //}

    //[HarmonyPatch(typeof(StaticGrabObject), nameof(StaticGrabObject.DestroyPhysGrabObjectRPC))]
    //internal static class StaticGrabObject_DestroyPhysGrabObject
    //{
    //    public static bool Prefix(ref PhotonMessageInfo _info)
    //    {
    //        if (_info.Sender == null)
    //        {
    //            return true;
    //        }

    //        if (_info.Sender != PhotonNetwork.MasterClient)
    //        {
    //            Log.LogInfo($"Player ({_info.Sender}) tried to call StaticGrabObject.DestroyPhysGrabObjectRPC " +
    //                $"while not the master client ({PhotonNetwork.MasterClient}).");
    //            return false;
    //        }

    //        return true;
    //    }
    //}

    [HarmonyPatch(typeof(LevelGenerator), nameof(LevelGenerator.ItemSetup))]
    internal static class ItemSetup
    {
        public static bool Prefix()
        {
            if (itemSetupOnCooldown)
            {
                return false;
            }

            Instance.StartCoroutine(ItemSetupCooldown());

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
