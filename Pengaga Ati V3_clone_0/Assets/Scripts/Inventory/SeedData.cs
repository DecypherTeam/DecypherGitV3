using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Seed")]
public class SeedData : ItemData
{
    // Time it takes before the seed grows into a crop
    public int daysToGrow;

    public ItemData cropToYield;
}
