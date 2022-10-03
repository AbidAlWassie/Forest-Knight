using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnusableItem : lootItem
{

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            //lootItemSignal.Raise();
            Destroy(this.gameObject);
        }
    }
}
