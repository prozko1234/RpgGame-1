using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagingObjects : MonoBehaviour {

    public float damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.SendMessage("Damage", damage);
    }

}
