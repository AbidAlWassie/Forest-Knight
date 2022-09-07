using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHit : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Breakable"))
        {
            collision.GetComponent<Breakables>().ObjectDestroy();
        }
    }

}
