using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{

    //public int level;
    //public int health;
    public float[] position;
    //public Rigidbody2D rb;

    public PlayerData (PlayerMovement player)
    {
        position = new float[2];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
    }

}
