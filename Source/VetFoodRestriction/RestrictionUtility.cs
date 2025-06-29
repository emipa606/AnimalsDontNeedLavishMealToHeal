using RimWorld;
using Verse;
using VetFoodRestriction.HarmonyPatches;

namespace VetFoodRestriction;

internal class RestrictionUtility
{
    public static bool WillFeedPatientAnimal(bool willEatValue, Pawn p, Pawn getter)
    {
        return willEatValue && p.RaceProps.Animal && getter.IsColonist && FeedPatientUtility.ShouldBeFed(p);
    }

    public static bool MakeFoodRestriction(FoodRestrictionDatabase foodRestrictionDatabase)
    {
        foreach (var allFoodRestriction in foodRestrictionDatabase.AllFoodRestrictions)
        {
            if (allFoodRestriction.label != FoodRestrictionDatabase_ExposeData.Instance.RestrictionName ||
                allFoodRestriction.id != FoodRestrictionDatabase_ExposeData.Instance.RestrictionId)
            {
                continue;
            }

            FoodRestrictionDatabase_ExposeData.Instance.FoodRestiction = allFoodRestriction;

            return false;
        }

        var foodRestriction = foodRestrictionDatabase.MakeNewFoodRestriction();
        foodRestriction.label = "VFR.restrictionTitle".Translate();
        FoodRestrictionDatabase_ExposeData.Instance.FoodRestiction = foodRestriction;
        FoodRestrictionDatabase_ExposeData.Instance.RestrictionName = foodRestriction.label;
        FoodRestrictionDatabase_ExposeData.Instance.RestrictionId = foodRestriction.id;
        foreach (var allDef in DefDatabase<ThingDef>.AllDefs)
        {
            if (allDef.ingestible != null && (int)allDef.ingestible.preferability >= 7 &&
                allDef != ThingDefOf.MealNutrientPaste && allDef != ThingDefOf.Pemmican)
            {
                foodRestriction.filter.SetAllow(allDef, false);
            }
        }

        foodRestriction.filter.SetAllow(ThingDefOf.Chocolate, false);
        return true;
    }
}