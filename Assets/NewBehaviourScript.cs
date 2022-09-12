using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class NewBehaviourScript : MonoBehaviour
{

    public GameObject fishPrefab;
    public float Radius = 1;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) {
            SpawnFish();
        }
    }

    void SpawnFish()
    {
        Debug.Log("Fish Spawned");

        Vector3 randomPos = Random.insideUnitCircle * Radius;

        Instantiate(fishPrefab, randomPos, Quaternion.identity);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(this.transform.position, Radius);
    }

}
