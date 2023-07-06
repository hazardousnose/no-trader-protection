using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;

namespace NoTraderProtection
{
    [HarmonyPatch(typeof(TraderArea), MethodType.Constructor)]
    [HarmonyPatch(new System.Type[] { typeof(Vector3i), typeof(Vector3i), typeof(Vector3i), typeof(List<Prefab.PrefabTeleportVolume>) })]
    internal class NTP_TraderArea_Constructor
    {
        public static void Prefix(ref Vector3i _size, ref Vector3i _protectSize)
        {
            _protectSize = Vector3i.zero;
        }
    }

    [HarmonyPatch(typeof(TraderArea), nameof(TraderArea.IsWithin))]
    internal class NTP_TraderArea_IsWithin
    {
        public static void Postfix(ref bool __result)
        {
            __result = false;
        }
    }

    [HarmonyPatch(typeof(World), nameof(World.IsWithinTraderArea))]
    internal class NTP_World_IsWithinTraderArea
    {
        public static void Postfix(ref bool __result)
        {
            __result = false;
        }
    }
}
