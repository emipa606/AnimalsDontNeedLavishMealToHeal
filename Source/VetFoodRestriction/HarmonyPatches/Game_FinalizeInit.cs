using HarmonyLib;
using Verse;

namespace VetFoodRestriction.HarmonyPatches;

[HarmonyPatch(typeof(Game), nameof(Game.FinalizeInit))]
internal class Game_FinalizeInit
{
    public static void Postfix(ref Game __instance)
    {
        Log.Message(RestrictionUtility.MakeFoodRestriction(__instance.foodRestrictionDatabase)
            ? "VFR.added".Translate(FoodRestrictionDatabase_ExposeData.Instance.restrictionName)
            : "VFR.exists".Translate(FoodRestrictionDatabase_ExposeData.Instance.restrictionName));
    }
}