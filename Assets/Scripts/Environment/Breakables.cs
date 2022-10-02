using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakables : MonoBehaviour
{

    private Animator animator;

    [Header("Destroy Effect")]
    public LootTable thisLoot;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ObjectDestroy()
    {
        animator.SetBool("Destroy", true);
        MakeLoot();
        StartCoroutine(destroyObj());
    }

    IEnumerator destroyObj()
    {
        yield return new WaitForSeconds(.3f);
        gameObject.SetActive(false);
    }

    private void MakeLoot()
    {
        if(thisLoot != null)
        {
            lootItem current = thisLoot.LootItem();
            if (current != null)
            {
                Instantiate(current.gameObject, transform.position, Quaternion.identity);
            }
        }
    }

}
