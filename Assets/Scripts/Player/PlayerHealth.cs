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
		if (other.CompareTag("Player") && CompareTag("Danger"))
		{
			TakeDamage(20);
		}
		else if (other.CompareTag("Player") && CompareTag("Heal"))
		{
			RestoreHealth(20);
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

	public void RestoreHealth (float heal)
	{

		//Debug.Log("curr health" + health.value + " & " + damage);
		health.value += heal;
		if (health.value >= maxHealth.value)
		{
			health.value = maxHealth.value;
			Debug.Log("Health Restored!");
		}
	}

}