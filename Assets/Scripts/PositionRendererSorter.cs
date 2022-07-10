using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionRendererSorter : MonoBehaviour
{
    [SerializeField]
    private int sortingOrderBase = 5000;

    [SerializeField]
    private int offset = 0;
    private bool runOnlyOnce = false;
    private float timer;
    private float timerMax = 0.1f;
    private Renderer sorter;

    private void Awake()
    {
        sorter = gameObject.GetComponent<Renderer>();
    }

    private void LateUpdate()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            sorter.sortingOrder = (int)(sortingOrderBase - transform.position.y - offset);

            if (runOnlyOnce)
            {
                Destroy(this);
            }
        }
    }
}
