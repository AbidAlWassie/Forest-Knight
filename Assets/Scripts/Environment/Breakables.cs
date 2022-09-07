using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakables : MonoBehaviour
{

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ObjectDestroy()
    {
        animator.SetBool("Destroy", true);
        StartCoroutine(destroyObj());
    }

    IEnumerator destroyObj()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }

}
