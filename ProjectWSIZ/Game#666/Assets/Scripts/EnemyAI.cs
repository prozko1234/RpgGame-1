using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
    public GameObject bar;
    float damage = 10;
    HealthSystem enemyHealth;
    private float wait_timer;
    private float wait_time = 2;
    Transform target;
    public float speed;
    
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SendMessage("Damage", damage);
        }
    }
    private void Update()
    {
        wait_time -= Time.deltaTime;
        bar.transform.localScale = new Vector3(enemyHealth.GetHealthPercent(), 1f);

        if (Vector2.Distance(transform.position,target.position) < 3)
        {
            transform.position = Vector2.MoveTowards(transform.position,target.position,speed * Time.deltaTime);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && wait_time < 0)
        {
            collision.gameObject.SendMessage("Damage", damage);
            wait_time = 2;
        }
    }

}
