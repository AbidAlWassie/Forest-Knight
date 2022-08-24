using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FetchData : MonoBehaviour
{
    public float x, y;

    public FloatValue currentHealth, maxHealth;

    public void SavePlayer()
    {
        x = transform.position.x;
        y = transform.position.y;

        PlayerPrefs.SetFloat("x", x);
        PlayerPrefs.SetFloat("y", y);
        //PlayerPrefs.SetFloat("playerHealth", currentHealth.value);
    }

    public void LoadPlayer()
    {
        x = PlayerPrefs.GetFloat("x");
        y = PlayerPrefs.GetFloat("y");

        Vector2 LoadPositon = new Vector2(x, y);
        transform.position = LoadPositon;
    }

    void Start()
    {
        //LoadPlayer();
    }


    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        LoadPlayer();
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    
}
