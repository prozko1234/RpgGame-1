using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour {
    public GameObject bar;
    public int damage = 10;
    HealthSystem enemyHealth;
    GameObject target;
    public Text hpNumber;
    public float speed;
    public GameObject damageBurst;
    private PlayerStats playerStats;

    public float attackRange;
    private float lastAttackTime;
    public float attackDelay;
    private float chaseRange = 3;
    public int expToGive;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        enemyHealth = gameObject.GetComponent<HealthSystem>();
        gameObject.SendMessage("SetHp", 50);
        playerStats = FindObjectOfType<PlayerStats>();
    }
    
    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, target.transform.position);
        BarUpdate();

        Chase(distanceToPlayer);
        
        Attack(distanceToPlayer);
        
        if(enemyHealth.GetCurrentHealth() <= 0)
        {
            gameObject.SetActive(false);
            playerStats.AddExperience(expToGive);
        }
    }
    
    private void Attack(float distanceToPlayer)
    {
        if (Time.time > lastAttackTime + attackDelay)
        {
            if (distanceToPlayer <= attackRange)
            {
                Debug.Log("Atacking player");
                target.SendMessage("Damage", damage);
                lastAttackTime = Time.time;
            }
        }
    }

    private void BarUpdate()
    {
        bar.transform.localScale = new Vector3(enemyHealth.GetHealthPercent(), 1f);
        hpNumber.text = (enemyHealth.GetCurrentHealth()).ToString();
    }

    private void Chase(float distanceToPlayer)
    {
        if (distanceToPlayer < chaseRange && !(distanceToPlayer <= attackRange))
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
    }
}
