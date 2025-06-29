using HarmonyLib;
using RimWorld;
using Verse;

namespace VetFoodRestriction.HarmonyPatches;

[HarmonyPatch(typeof(FoodUtility), nameof(FoodUtility.WillEat), typeof(Pawn), typeof(ThingDef), typeof(Pawn),
    typeof(bool), typeof(bool))]
internal class FoodUtility_WillEat_ThingDef
{
    [HarmonyPriority(200)]
    public static void Postfix(ref bool __result, Pawn p, ThingDef food, Pawn getter)
    {
        if (getter != null && RestrictionUtility.WillFeedPatientAnimal(__result, p, getter))
        {
            __result = FoodRestrictionDatabase_ExposeData.Instance.FoodRestiction.Allows(food);
        }
    }
}