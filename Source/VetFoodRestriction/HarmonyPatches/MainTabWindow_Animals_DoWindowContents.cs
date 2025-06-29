using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse;

namespace VetFoodRestriction.HarmonyPatches;

[HarmonyPatch(typeof(MainTabWindow_Animals), nameof(MainTabWindow_Animals.DoWindowContents))]
internal class MainTabWindow_Animals_DoWindowContents
{
    public static void Postfix(Rect rect)
    {
        if (Widgets.ButtonText(new Rect(rect.x + 260f, rect.y, Mathf.Min(rect.width, 260f), 32f),
                FoodRestrictionDatabase_ExposeData.Instance.RestrictionName))
        {
            Find.WindowStack.Add(
                new Dialog_ManageFoodPolicies(FoodRestrictionDatabase_ExposeData.Instance.FoodRestiction));
        }
    }
}