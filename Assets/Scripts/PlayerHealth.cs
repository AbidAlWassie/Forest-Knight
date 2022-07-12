using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{

	public static event Action OnPlayerDeath;

	public int maxHealth = 100;
	public int currentHealth;

	public HealthBar healthBar;

	public static bool GameIsPaused = false;

	public GameObject gameoverMenuUI;

	// Start is called before the first frame update
	void Start()
	{
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
	}



	void LoadGame()
	{
		gameoverMenuUI.SetActive(false);
		Time.timeScale = 1f;
		GameIsPaused = false;
		currentHealth = maxHealth;
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
			//Debug.Log("Player took damage!");
			TakeDamage(50);
		}

		
	}

	void TakeDamage(int damage)
	{
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);

		if (currentHealth <= 0)
		{
			currentHealth = 0;

			OnPlayerDeath?.Invoke();
			Debug.Log("Gameover!");
		}
	}
}