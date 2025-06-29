using HarmonyLib;
using RimWorld;
using Verse;

namespace VetFoodRestriction.HarmonyPatches;

[HarmonyPatch(typeof(FoodRestrictionDatabase), nameof(FoodRestrictionDatabase.ExposeData))]
internal class FoodRestrictionDatabase_ExposeData
{
    private static FoodRestrictionDatabase_ExposeData instance;

    public FoodPolicy FoodRestiction;

    public int RestrictionId;
    public string RestrictionName;

    public static FoodRestrictionDatabase_ExposeData Instance
    {
        get
        {
            instance ??= new FoodRestrictionDatabase_ExposeData();

            return instance;
        }
    }

    public static void Prefix()
    {
        if (Scribe.mode == LoadSaveMode.Saving)
        {
            Instance.RestrictionName = Instance.FoodRestiction.label;
            Instance.RestrictionId = Instance.FoodRestiction.id;
        }

        Scribe_Values.Look(ref Instance.RestrictionName, "Sielfyr.VetFoodRestrictionrestrictionName",
            "VetFoodRestriction");
        Scribe_Values.Look(ref Instance.RestrictionId, "Sielfyr.VetFoodRestrictionrestrictionId", -1);
    }
}