
using BepInEx.Logging;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Cecil.Rocks;
using MonoMod.Cil;
using System.Collections.Generic;
using System.Linq;
using OpCodes = Mono.Cecil.Cil.OpCodes;

public static class RpcPatcher
{
    public static IEnumerable<string> TargetDLLs { get; } = ["Assembly-CSharp.dll"];

    public static void Patch(AssemblyDefinition assembly)
    {
        ManualLogSource Log = Logger.CreateLogSource("RepoAntiCheat");
        Log.LogMessage("Patching RPCs to include PhotonMessageInfo parameter.");

        int rpcsPatched = 0;
        int localRpcCallsPatched = 0;

        if (!assembly.MainModule.TryGetTypeReference("Photon.Pun.PhotonMessageInfo", out TypeReference photonMessageInfo))
        {
            Log.LogFatal("Photon.Pun.PhotonMessageInfo type not found.");
        }

        List<MethodDefinition> methods = [];
        List<MethodDefinition> rpcMethods = [];

        foreach (TypeDefinition type in assembly.MainModule.GetTypes())
        {
            foreach (MethodDefinition method in type.Methods)
            {
                if (method.HasBody)
                {
                    methods.Add(method);
                    if (method.HasCustomAttributes && method.CustomAttributes.Any(attribute => attribute.AttributeType.ToString() == "Photon.Pun.PunRPC"))
                    {
                        method.Parameters.Add(new ParameterDefinition("info", ParameterAttributes.Optional, photonMessageInfo));
                        rpcMethods.Add(method);
                        rpcsPatched++;
                    }
                }
            }
        }

        SortedList<int, Instruction> calls = [];

        foreach (MethodDefinition method in methods)
        {
            ILProcessor iLProcessor = method.Body.GetILProcessor();
            method.Body.SimplifyMacros();

            foreach (MethodDefinition rpcMethod in rpcMethods)
            {
                foreach (Instruction instruction in method.Body.Instructions)
                {
                    if (instruction.MatchCallOrCallvirt(rpcMethod))
                    {
                        calls.Add(instruction.Offset, instruction);
                    }
                }
            }

            if (calls.Count > 0)
            {
                method.Body.Variables.Add(new VariableDefinition(photonMessageInfo));
            }

            foreach (Instruction instruction in calls.Values)
            {
                
                iLProcessor.InsertBefore(instruction, iLProcessor.Create(OpCodes.Ldloca_S, method.Body.Variables.Last()));
                iLProcessor.InsertBefore(instruction, iLProcessor.Create(OpCodes.Initobj, photonMessageInfo));
                iLProcessor.InsertBefore(instruction, iLProcessor.Create(OpCodes.Ldloc_S, method.Body.Variables.Last()));

                localRpcCallsPatched++;
            }

            method.Body.OptimizeMacros();
            calls.Clear();
        }

        Log.LogMessage($"Finished Patching {rpcsPatched} RPCs and {localRpcCallsPatched} local RPC calls");
    }
}
