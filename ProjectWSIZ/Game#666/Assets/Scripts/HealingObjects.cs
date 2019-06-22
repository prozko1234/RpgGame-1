using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*! \brief HealingObjects description.
 *         Handels healing game objects.
 *
 *  This script makes heal to objects that colide with game objects that have this script.
 */
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
}
