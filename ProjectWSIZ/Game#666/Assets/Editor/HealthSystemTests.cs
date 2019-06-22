using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class HealthSystemTests
{

    [Test]
    public void SetMaxHp_Test()
    {
        HealthSystem healthSystem = new HealthSystem();
        float result = 100;

        healthSystem.SetMaxHp(100);
        var maxHp = healthSystem.maxHealth;

        Assert.AreEqual(result, maxHp);
    }

    [Test]
    public void SetCurrentHp_Test()
    {
        HealthSystem healthSystem = new HealthSystem();
        float result = 100;

        healthSystem.SetCurrentHp(100);
        var currHp = healthSystem.currentHealth;

        Assert.AreEqual(result, currHp);
    }

    [Test]
    public void HealHp_Test()
    {
        HealthSystem healthSystem = new HealthSystem();
        healthSystem.maxHealth = 120;
        healthSystem.currentHealth = 100;

        healthSystem.Heal(20);
        var result = healthSystem.currentHealth;

        Assert.AreEqual(result, 120);
    }

}