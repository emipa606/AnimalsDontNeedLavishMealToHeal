using System.Reflection;
using HarmonyLib;
using Verse;

namespace VetFoodRestriction;

[StaticConstructorOnStartup]
public static class VFRPatch
{
    static VFRPatch()
    {
        new Harmony("Sielfyr.VetFoodRestriction").PatchAll(Assembly.GetExecutingAssembly());
    }
}