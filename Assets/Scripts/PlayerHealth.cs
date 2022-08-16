using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{

	public HealthBar healthBar;

    public static event Action OnPlayerDeath;
    public static bool GameIsPaused = false;
	public GameObject gameoverMenuUI;

	public FloatValue health, maxHealth;

	

	void LoadGame()
	{
		gameoverMenuUI.SetActive(false);
		Time.timeScale = 1f;
		GameIsPaused = false;
		//currentHealth = maxHealth;
	}

	void Gameover()
	{
		gameoverMenuUI.SetActive(true);
		Time.timeScale = 0f;
		GameIsPaused = true;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			TakeDamage(20);
		}
		
	}

	public void TakeDamage(float damage)
	{

		//Debug.Log("curr health" + health.value + " & " + damage);
		health.value -= damage;
        if (health.value <= 0)
        {
			health.value = 0;
            OnPlayerDeath?.Invoke();
            Debug.Log("Gameover!");
        }
    }

	//Old
	//void TakeDamage(int damage)
	//{
	//    currentHealth.initialValue -= damage;

	//    healthBar.SetHealth(100);

	//    if (currentHealth.initialValue <= 0)
	//    {
	//        currentHealth.initialValue = 0;

	//        OnPlayerDeath?.Invoke();
	//        Debug.Log("Gameover!");
	//    }
	//}

	// Start is called before the first frame update
	//   void Start()
	//{
	//	//currentHealth = maxHealth;
	//	//healthBar.SetMaxHealth(maxHealth);
	//}

}