using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public PlayerStats playerStats;
    public HealthSystem playerHealth;
    string filePath;
    public List<string> scores;
    //   public PlayerStats playerStats;
    //   private PlayerManager player;
    //   public HealthSystem playerHealth;

    //void Start () {
    //       playerStats = GetComponentInChildren<PlayerStats>();
    //       player = FindObjectOfType<PlayerManager>();
    //   }

    //void Update () {
    //       if (Input.GetKeyDown(KeyCode.E))
    //       {
    //           Save();
    //       }
    //       if (Input.GetKeyDown(KeyCode.R))
    //       {
    //           Load();
    //       }
    //}

    //   public void Save()
    //   {
    //       PlayerPrefs.SetInt("score", playerStats.score);
    //       PlayerPrefs.SetInt("currentLvl", playerStats.currentLvl);

    //       PlayerPrefs.SetFloat("currentHpStat", playerStats.currentHpStat);
    //       PlayerPrefs.SetFloat("currentHp", playerHealth.currentHealth);
    //       PlayerPrefs.SetFloat("maxHp", playerHealth.maxHealth);

    //       PlayerPrefs.SetInt("currentAttack", playerStats.currentAttack);
    //       PlayerPrefs.SetInt("currentDefence", playerStats.currentDefence);
    //       PlayerPrefs.SetInt("currentExp", playerStats.currentExp);

    //       PlayerPrefs.Save();
    //       Debug.Log("Saving");
    //   }

    //   public void Load()
    //   {
    //       int score = PlayerPrefs.GetInt("score");
    //       int currentLvl = PlayerPrefs.GetInt("currentLvl");
    //       //
    //       float currentHpStat = PlayerPrefs.GetFloat("currentHpStat");
    //       float currentHp = PlayerPrefs.GetFloat("currentHp");
    //       float maxHp = PlayerPrefs.GetFloat("maxHp");
    //       //
    //       int currentAttack = PlayerPrefs.GetInt("currentAttack");
    //       int currentDefence = PlayerPrefs.GetInt("currentDefence");
    //       int currentExp = PlayerPrefs.GetInt("currentExp");

    //       playerStats.score = score;
    //       playerStats.currentLvl = currentLvl;
    //       playerStats.currentHpStat = currentHpStat;
    //       playerHealth.currentHealth = currentHp;
    //       playerHealth.maxHealth = maxHp;
    //       playerStats.currentAttack = currentAttack;
    //       playerStats.currentDefence = currentDefence;
    //       playerStats.currentExp = currentExp;


    //       Debug.Log("Loading");
    //   }

    //   public void ResetStats()
    //   {
    //       PlayerPrefs.SetInt("score", 0);
    //       PlayerPrefs.SetInt("currentLvl", 0);

    //       PlayerPrefs.SetFloat("currentHpStat", 50);
    //       PlayerPrefs.SetFloat("currentHp", 50);
    //       PlayerPrefs.SetFloat("maxHp", 50);

    //       PlayerPrefs.SetInt("currentAttack", 0);
    //       PlayerPrefs.SetInt("currentDefence", 0);
    //       PlayerPrefs.SetInt("currentExp", 0);

    //       PlayerPrefs.Save();
    //       Load();

    //       Debug.Log("Stats reseted.");
    //   }

    private void Start()
    {
       filePath = Application.dataPath + "/save.txt";
        scores = new List<string>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            Save();
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            //Load();
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            ExitToMenu();
        }
    }

    public void ExitToMenu()
    {
        Save();
        SceneManager.LoadScene(0);

    }

    public void Save()
    {
        File.AppendAllText(filePath,
                   playerStats.score.ToString() + Environment.NewLine);

        Debug.Log("Added score");
    }
}
