using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*! \brief HealthSystem description.
 *         Handles health functionality.
 *
 *  This script handles health management.
 */
public class HealthSystem : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    //! Set hp method.
    /*!
     * Sets init health to setted value(current and max health).
      \param health number of hit points to set.
    */
    void SetHp(float health)
    {
        maxHealth = health;
        currentHealth = maxHealth;
        Debug.Log("Current Hp setted to: " + currentHealth + "Max Hp setted to: " + maxHealth);
    }
    //! Damage method.
    /*!
     * Decrease health.
      \param damage number of hit points to decrease.
    */
    void Damage(float damage)
    {
            currentHealth -= damage;
            Debug.Log("Made " + damage + " damage." + "\n Health left: " + currentHealth);
    }
    //! Heal method.
    /*!
     * Increase health.
      \param heal number of hit points to heal.
    */
    public void Heal(float heal)
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
    //! Get health percent method.
    /*!
     * Method for getting percent of current health.
     * \return  current health divided on maxhealth
    */
    public float GetHealthPercent()
    {
        return currentHealth / maxHealth;
    }
    //! Get current health method.
    /*!
     * Method for getting current health.
     * \return current health.
    */
    public float GetCurrentHealth()
    {
        return currentHealth;
    }
    //! Get max health method.
    /*!
     * Method for getting max health.
     * \return max health.
    */
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
