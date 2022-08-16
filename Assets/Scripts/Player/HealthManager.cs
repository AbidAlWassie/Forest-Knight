//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using System;

//public class HealthManager : MonoBehaviour {

//    public static event Action OnPlayerDeath;

//    public Slider slider;

//    public IntValue maxHealth;
//    public IntValue currentHealth;

//    public HealthBar healthBar;

//    public static bool GameIsPaused = false;

//    public GameObject gameoverMenuUI;


//    // Use this for initialization
//    void Start () {
//        InitHealth();
//	}

//    public void InitHealth()
//    {
//        Debug.Log("Health Init");
//        //currentHealth = maxHealth;
//        //healthBar.SetMaxHealth(100);
//    }

//    public void UpdateHealth(int health)
//    {
//        InitHealth();

//        slider.maxValue = health;
//        slider.value = health;

//        //int tempHealth = currentHealth.RuntimeValue / 2;
//        //for (int i = 0; i < maxHealth.RuntimeValue; i++)
//        //{

//        //    //if(i <= tempHealth-1)  
//        //    //{
//        //    //    //Full Heart
//        //    //    hearts[i].sprite = fullHeart;
//        //    //}else if( i >= tempHealth)
//        //    //{
//        //    //    //empty heart
//        //    //    hearts[i].sprite = emptyHeart;
//        //    //}else{
//        //    //    //half full heart
//        //    //    hearts[i].sprite = halfFullHeart;
//        //    //}
//        //}

//    }

//    //public void SetMaxHealth(int health)
//    //{
//    //    slider.maxValue = health;
//    //    slider.value = health;
//    //}

//    //public void SetHealth(int health)
//    //{
//    //    slider.value = health;
//    //}

//}
