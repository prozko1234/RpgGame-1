using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    float maxHealth;
    float currentHealth;    
    
    void SetHp(float health)
    {
        maxHealth = health;
        currentHealth = maxHealth;
        Debug.Log("Current Hp setted to: " + currentHealth + "Max Hp setted to: " + maxHealth);
    }
    
    void Damage(float damage)
    {
            currentHealth -= damage;
            Debug.Log("Made " + damage + " damage." + "\n Health left: " + currentHealth);
        if (currentHealth <= 0 && gameObject.tag == "Player")
            Reload();
        else if(currentHealth <= 0)
            gameObject.SetActive(false);
    }

    void Heal(float heal)
    {
        if (currentHealth <= maxHealth)
        {
            currentHealth += heal;
            if (currentHealth > maxHealth)
                currentHealth = maxHealth;
            Debug.Log("Made " + heal + " heal.");
        }
        else Debug.Log("You allready have max health");
    }

    public float GetHealthPercent()
    {
        return currentHealth / maxHealth;
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }

    void Reload()
    {
        Application.LoadLevel(0);
    }
}
