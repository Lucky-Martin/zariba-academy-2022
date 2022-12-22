using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public float MaxHealth;
    [SerializeField] public float Health;
    [SerializeField] public Slider HealthBarUI;
    
    public GameEvent onPlayerDeath;

    private void Start()
    {
        UpdateHealthBar();
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        UpdateHealthBar();
        if(Health <= 0) {
            onPlayerDeath?.Raise(this, true);
        }
    }

    public void AddHealth(float health)
    {
        Health += health;
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        Debug.Log($"Health {Health}; Max Health {MaxHealth}; Ratio {GetRatio()}");
        HealthBarUI.value = GetRatio();
    }
    
    private float GetRatio()
    {
        return Health / MaxHealth;
    }
}
