using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour {

    public Slider healthBar;
    public Text hpText;
    public HealthSystem playerHealth;

    private PlayerStats playerStats;
    public Text lvlText;
    
	void Start ()
    {
        playerStats = GetComponent<PlayerStats>();
    }
	
	void Update () {
        healthBar.maxValue = playerHealth.GetMaxHealth();
        healthBar.value = playerHealth.GetCurrentHealth();
        hpText.text = playerHealth.GetCurrentHealth() + "/" + playerHealth.GetMaxHealth();
        lvlText.text = "Lvl: " + playerStats.currentLvl;
    }
}
