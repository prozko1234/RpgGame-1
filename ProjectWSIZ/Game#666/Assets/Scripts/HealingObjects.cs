using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingObjects : MonoBehaviour {
    GameObject target;
    public float healingAmount;
    public float timer;
    private float lastTimeHeal;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, target.transform.position) < 1)
        {
            if (Time.time > lastTimeHeal + timer)
            {
                target.SendMessage("Heal", 5);
                lastTimeHeal = Time.time;
            }
        }
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag != "Enemy" && Time.time > lastTimeHeal + timer)
    //    {
    //        collision.gameObject.SendMessage("Heal", 5);
    //        lastTimeHeal = Time.time;
    //    }
    //}
}
