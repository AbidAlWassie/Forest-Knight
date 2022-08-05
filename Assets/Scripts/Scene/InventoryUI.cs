using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject inventoryUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (GameIsPaused)
            {
                OpenInventory();
            }
            else
            {
                CloseInventory();
            }

        }
    }

    public void OpenInventory()
    {
        inventoryUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void CloseInventory()
    {
        inventoryUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
