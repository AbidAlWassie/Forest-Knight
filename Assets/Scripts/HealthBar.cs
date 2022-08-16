using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public FloatReference CurrentHealth, MaxHealth;

    public Slider slider;


    void Start()
    {
        slider = GetComponent<Slider>();
        //slider.value = 100;
    }

    void Update()
    {
        float fillValue = CurrentHealth.value;
        slider.value = fillValue;
        //slider.value = 100;
    }

    //public Slider slider;

    //public void SetMaxHealth(int health)
    //{
    //    slider.maxValue = health;
    //    slider.value = health;
    //}

    //public void SetHealth(int health)
    //{
    //    slider.value = health;
    //}

}
