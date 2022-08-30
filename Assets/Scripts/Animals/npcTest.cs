using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcTest : NPC
{

    public Transform[] moveSpot;
    private int randomSpot;
    public float waitTime;
    public float startWaitTime;

    // Start is called before the first frame update
    void Start()
    {
        randomSpot = Random.Range(0, moveSpot.Length);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpot[randomSpot].position, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpot[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpot.Length);
                waitTime = startWaitTime;
            } else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
