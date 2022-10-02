using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRestore : lootItem
{
    public FloatValue currentHealth, maxHealth;
    public float heal;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            currentHealth.value += heal;
            //lootItemSignal.Raise();
            Destroy(this.gameObject);
        }
    }
}
