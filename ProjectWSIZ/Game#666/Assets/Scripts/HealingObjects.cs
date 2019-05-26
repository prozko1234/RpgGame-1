using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingObjects : MonoBehaviour {
    public float healingAmount;
    public float timer;
    private float lastTimeHeal;
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Enemy" && Time.time > lastTimeHeal + timer)
        {
            collision.gameObject.SendMessage("Heal", 5);
            lastTimeHeal = Time.time;
        }
    }
}
