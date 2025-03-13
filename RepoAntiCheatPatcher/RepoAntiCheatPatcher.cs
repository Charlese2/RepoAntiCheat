
using BepInEx.Logging;
using Mono.Cecil;
using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;
using System.Linq;

public static class RpcPatcher
{
    public static IEnumerable<string> TargetDLLs { get; } = ["Assembly-CSharp.dll"];

    public static void Patch(AssemblyDefinition assembly)
    {
        ManualLogSource Log = Logger.CreateLogSource("RepoAntiCheat");
        Log.LogMessage("Patching RPCs to include PhotonMessageInfo parameter.");

        int rpcsPatched = 0;

        if (!assembly.MainModule.TryGetTypeReference("Photon.Pun.PhotonMessageInfo", out TypeReference photonMessageInfo))
        {
            Log.LogFatal("Photon.Pun.PhotonMessageInfo type not found.");
        }

        List<MethodDefinition> methods = [];
        List<Tuple<TypeDefinition, MethodDefinition>> rpcList = [];

        foreach (TypeDefinition type in assembly.MainModule.GetTypes())
        {
            foreach (MethodDefinition method in type.Methods)
            {
                if (method.HasBody)
                {
                    if (method.HasCustomAttributes && method.CustomAttributes.Any(attribute => attribute.AttributeType.ToString() == "Photon.Pun.PunRPC"))
                    {
                        rpcList.Add(new Tuple<TypeDefinition, MethodDefinition>(type, method));
                    }
                }
            }
        }

        foreach (var rpc in rpcList)
        {
            TypeDefinition type = rpc.Item1;
            MethodDefinition originalMethod = rpc.Item2;
            MethodDefinition newRpcMethod = new(originalMethod.Name, originalMethod.Attributes, originalMethod.ReturnType)
            {
                Attributes = originalMethod.Attributes,
                Body = originalMethod.Body,
                CallingConvention = originalMethod.CallingConvention,
                DebugInformation = originalMethod.DebugInformation,
                DeclaringType = originalMethod.DeclaringType,
                ImplAttributes = originalMethod.ImplAttributes,
                MethodReturnType = originalMethod.MethodReturnType,
                ReturnType = originalMethod.ReturnType,
            };
            foreach (ParameterDefinition parameter in originalMethod.Parameters)
            {
                newRpcMethod.Parameters.Add(parameter);
            }
            foreach (CustomAttribute customAttribute in originalMethod.CustomAttributes)
            {
                newRpcMethod.CustomAttributes.Add(customAttribute);
            }
            foreach (SecurityDeclaration securityDeclaration in originalMethod.SecurityDeclarations)
            {
                newRpcMethod.SecurityDeclarations.Add(securityDeclaration);
            }
            foreach (CustomDebugInformation customDebugInformation in originalMethod.CustomDebugInformations)
            {
                newRpcMethod.CustomDebugInformations.Add(customDebugInformation);
            }

            newRpcMethod.Parameters.Add(new ParameterDefinition("info", ParameterAttributes.Optional, photonMessageInfo));

            // Remove PunRPC attribute from singleplayer RPC function.
            CustomAttribute punRpcAttribute = originalMethod.CustomAttributes.First(attribute => attribute.AttributeType.ToString() == "Photon.Pun.PunRPC");
            originalMethod.CustomAttributes.Remove(punRpcAttribute);

            type.Methods.Add(newRpcMethod);
            rpcsPatched++;
        }

        Log.LogMessage($"Finished Patching {rpcsPatched} RPCs");
    }
}
