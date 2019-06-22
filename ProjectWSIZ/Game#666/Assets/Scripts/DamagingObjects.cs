using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*! \brief DamagingObjects description.
 *         Handels damaging game objects.
 *
 *  This script makes damage to objects that colide with game objects that have this script.
 */
public class DamagingObjects : MonoBehaviour {

    public float damage = 1;

    private void OnCollisionStay2D(Collision2D collision)
    {
        collision.gameObject.SendMessage("Damage", damage);
    }

}
