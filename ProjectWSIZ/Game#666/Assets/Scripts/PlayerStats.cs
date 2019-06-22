using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*! \brief PlayerStats description.
 *         Handles player stats functionality.
 *
 *  This script providse functionality for player's stats.
 */
public class PlayerStats : MonoBehaviour {

    private PlayerManager playerManager;

    public string playerName = "Player";
    public int score;
    public int currentLvl;
    public float currentHpStat;
    public int currentAttack;
    public int currentDefence;
    public int currentExp;

    public int[] toLvlUp;

    public float[] hpLvls;
    public int[] attackLvls;
    public int[] defenceLvls;
    
	void Start () {
        currentHpStat = hpLvls[1];
        currentAttack = attackLvls[1];
        currentDefence = defenceLvls[1];
        playerManager = FindObjectOfType<PlayerManager>();
    }
	
	void Update () {
		if(currentExp >= toLvlUp[currentLvl])
        {
            //currentLvl++;
            LvlUp();
        }
            
        score = (int)playerManager.playerHealth.GetCurrentHealth() + currentExp*10; 
	}
    //! Add experiance method
    /*!
     * Adds setted value to players experiance.
     */
    public void AddExperience(int expirienceToAdd)
    {
        currentExp += expirienceToAdd;
    }
    //! Level up method
    /*!
     * Sets level to the next one and changes stats for stats from new level.
     */
    public void LvlUp()
    {
        currentLvl++;
        currentHpStat = hpLvls[currentLvl];

        playerManager.playerHealth.SetMaxHp(currentHpStat);
        playerManager.playerHealth.SetAddCurrentHp(currentHpStat - hpLvls[currentLvl - 1]);

        currentAttack = attackLvls[currentLvl];
        currentDefence = defenceLvls[currentLvl];
    }
}
