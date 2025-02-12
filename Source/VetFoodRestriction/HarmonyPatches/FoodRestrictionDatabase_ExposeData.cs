using HarmonyLib;
using RimWorld;
using Verse;

namespace VetFoodRestriction.HarmonyPatches;

[HarmonyPatch(typeof(FoodRestrictionDatabase), nameof(FoodRestrictionDatabase.ExposeData))]
internal class FoodRestrictionDatabase_ExposeData
{
    private static FoodRestrictionDatabase_ExposeData instance;

    public FoodPolicy foodRestiction;

    public int restrictionId;
    public string restrictionName;

    public static FoodRestrictionDatabase_ExposeData Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new FoodRestrictionDatabase_ExposeData();
            }

            return instance;
        }
    }

    public static void Prefix()
    {
        if (Scribe.mode == LoadSaveMode.Saving)
        {
            Instance.restrictionName = Instance.foodRestiction.label;
            Instance.restrictionId = Instance.foodRestiction.id;
        }

        Scribe_Values.Look(ref Instance.restrictionName, "Sielfyr.VetFoodRestrictionrestrictionName",
            "VetFoodRestriction");
        Scribe_Values.Look(ref Instance.restrictionId, "Sielfyr.VetFoodRestrictionrestrictionId", -1);
    }
}