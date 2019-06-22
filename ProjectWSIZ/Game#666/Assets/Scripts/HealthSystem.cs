using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;    
    
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

    public void SetMaxHp(float hp)
    {
        this.maxHealth = hp;
    }

    public void SetAddCurrentHp(float hp)
    {
        this.currentHealth += hp;
    }
    public void SetCurrentHp(float hp)
    {
        currentHealth = hp;
    }
}
