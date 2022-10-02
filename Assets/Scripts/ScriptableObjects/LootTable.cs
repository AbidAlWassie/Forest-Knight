using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Loot
{
    public lootItem thisLoot;
    public int lootChance;
}


[CreateAssetMenu]
public class LootTable : ScriptableObject
{
    public Loot[] loots;

    public lootItem LootItem()
    {
        int prob = 0;
        int currentProb = Random.Range(0, 100);
        for (int i = 0; i < loots.Length; i++)
        {
            prob += loots[i].lootChance;
            if (currentProb <= prob)
            {
                return loots[i].thisLoot;
            }
        }
        return null;
    }
}