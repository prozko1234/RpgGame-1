using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
    public GameObject bar;
    public float damage = 10;
    HealthSystem enemyHealth;
    GameObject target;
    public float speed;

    public float attackRange;
    private float lastAttackTime;
    public float attackDelay;
    private float chaseRange = 3;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        enemyHealth = gameObject.GetComponent<HealthSystem>();
        gameObject.SendMessage("SetHp", 100);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Player" && gameObject.GetComponent<BoxCollider2D>().isTrigger)
    //    {
    //        collision.gameObject.SendMessage("Damage", damage);
    //    }
    //}

    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Player" && gameObject.GetComponent<BoxCollider2D>().isTrigger)
    //    {
    //        if (wait_timer < wait_time)
    //            wait_timer += Time.deltaTime;
    //        else
    //        {
    //            collision.gameObject.SendMessage("Damage", damage);
    //            wait_timer = 2;
    //        }
    //    }
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        collision.gameObject.SendMessage("Damage", damage);
    //    }
    //}
    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, target.transform.position);
        BarUpdate();

        Chase(distanceToPlayer);
        
        Attack(distanceToPlayer);
        
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
    }

    private void Chase(float distanceToPlayer)
    {
        if (distanceToPlayer < chaseRange && !(distanceToPlayer <= attackRange))
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
    }
}
