using HarmonyLib;
using RimWorld;
using Verse;

namespace VetFoodRestriction.HarmonyPatches;

[HarmonyPatch(typeof(FoodRestrictionDatabase), nameof(FoodRestrictionDatabase.TryDelete))]
internal class FoodRestrictionDatabase_TryDelete
{
    [HarmonyPrefix]
    public static bool PreserveFoodRestriction(FoodPolicy foodPolicy, ref AcceptanceReport __result)
    {
        if (foodPolicy != FoodRestrictionDatabase_ExposeData.Instance.FoodRestiction)
        {
            return true;
        }

        __result = new AcceptanceReport("VFR.cantDelete".Translate());
        return false;
    }
}