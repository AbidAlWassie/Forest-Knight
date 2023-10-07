using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingRodHit : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            print(collision.CompareTag("Water") + " Entered fishing state");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            print("Exiting fishing state");
        }
    }
}
