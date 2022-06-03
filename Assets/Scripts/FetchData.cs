using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FetchData : MonoBehaviour
{
    public float x, y;

    public void SavePlayer()
    {
        x = transform.position.x;
        y = transform.position.y;

        PlayerPrefs.SetFloat("x", x);
        PlayerPrefs.SetFloat("y", y);
    }


    public void LoadPlayer()
    {
        x = PlayerPrefs.GetFloat("x");
        y = PlayerPrefs.GetFloat("y");

        Vector2 LoadPositon = new Vector2(x, y);
        transform.position = LoadPositon;
    }
}
