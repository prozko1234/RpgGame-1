using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class PlayerStats_Tests
{

    [Test]
    public void AddExperience_Test()
    {
        PlayerStats playerStats = new PlayerStats();
        playerStats.currentExp = 10;
        int exp = 20;

        playerStats.AddExperience(10);
        var result = playerStats.currentExp;

        Assert.AreEqual(result, exp);
    }
}
