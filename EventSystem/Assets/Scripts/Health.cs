using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
  
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private int _maxHealth = 100;

    private int currentHealth;

    private void Start()
    {
        SetCurrentHealth(_maxHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ModifyHealth(-20);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            ModifyHealth(20);
        }
    }

    public void SetCurrentHealth(int health)
    {
        currentHealth = Mathf.Clamp(health, 0, _maxHealth);
       
    }

    public void ModifyHealth(int amount)
    {
        SetCurrentHealth(currentHealth + amount);
    }
}


