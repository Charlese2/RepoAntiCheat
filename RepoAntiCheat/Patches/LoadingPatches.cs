using HarmonyLib;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace RepoAntiCheat.Patches
{
    internal class LoadingPatches
    {
        [HarmonyWrapSafe]
        [HarmonyPatch(typeof(NetworkManager), nameof(NetworkManager.Update))]
        internal static class FixInstantiatedPlayerAvatarsComparison
        {
            [HarmonyTranspiler]
            public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                CodeMatcher matcher = new CodeMatcher(instructions)
                    .MatchForward(true,
                    new CodeMatch(instruction => instruction.LoadsField(AccessTools.Field(typeof(NetworkManager), "instantiatedPlayerAvatars"))),
                    new CodeMatch(instruction => instruction.Calls(AccessTools.Method(typeof(PhotonNetwork), "get_CurrentRoom"))),
                    new CodeMatch(instruction => instruction.Calls(AccessTools.Method(typeof(Room), "get_PlayerCount"))),
                    new CodeMatch(instruction => instruction.opcode == OpCodes.Bne_Un)
                    );

                if (!matcher.ReportFailure(MethodBase.GetCurrentMethod(), AntiCheatPlugin.Log.LogInfo))
                {
                    matcher.Instruction.opcode = OpCodes.Blt;
                }

                return matcher.InstructionEnumeration();
            }
        }

        [HarmonyWrapSafe]
        [HarmonyPatch(typeof(ReloadScene), nameof(ReloadScene.Update))]
        internal static class FixPlayersReadyComparison
        {
            [HarmonyTranspiler]
            public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                CodeMatcher matcher = new CodeMatcher(instructions)
                    .MatchForward(true,
                    new CodeMatch(instruction => instruction.LoadsField(AccessTools.Field(typeof(ReloadScene), "PlayersReady"))),
                    new CodeMatch(instruction => instruction.Calls(AccessTools.Method(typeof(PhotonNetwork), "get_CurrentRoom"))),
                    new CodeMatch(instruction => instruction.Calls(AccessTools.Method(typeof(Room), "get_PlayerCount"))),
                    new CodeMatch(instruction => instruction.opcode == OpCodes.Bne_Un)
                    );

                if (!matcher.ReportFailure(MethodBase.GetCurrentMethod(), AntiCheatPlugin.Log.LogInfo))
                {
                    matcher.Instruction.opcode = OpCodes.Blt;
                }

                return matcher.InstructionEnumeration();
            }
        }
    }
}
