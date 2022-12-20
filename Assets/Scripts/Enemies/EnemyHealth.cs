using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public GameObject healthBarUI;
    [SerializeField] public Slider slider;
    [SerializeField] public float MaxHealth;
    [SerializeField] public float Health;

    private void Start()
    {
        UpdateHealthBar();
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        UpdateHealthBar();
    }

    public void AddHealth(float health)
    {
        Health += health;
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        Debug.Log($"Health {Health}; Max Health {MaxHealth}; Ratio {GetRatio()}");
        slider.value = GetRatio();
        
        if (MaxHealth > Health)
        {
            healthBarUI.SetActive(true);
        }

        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    private float GetRatio()
    {
        return Health / MaxHealth;
    }
}
