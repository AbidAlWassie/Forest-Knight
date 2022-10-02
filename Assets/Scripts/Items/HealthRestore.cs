using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HealthRestore : lootItem
{
    public GameObject loot;

    public FloatValue currentHealth, maxHealth;
    public float heal;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            currentHealth.value += heal;
        }
        Destroy(this.gameObject);
    }
}
