using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Sword1 : MonoBehaviour {
    EdgeCollider2D collisionElem;
	private float damage = 10;
    private string weaponName = "Bone Sword";
    private bool attacking;
    public GameObject damageBurst;
    PlayerManager playerManager;

    public Weapon_Sword1() { }

    private void Start()
    {
        playerManager = gameObject.GetComponentInParent<PlayerManager>();
        collisionElem = gameObject.GetComponent<EdgeCollider2D>();
    }

    public float GetDamage()
    {
        return damage;
    }

    public string GetWeaponName()
    {
        return weaponName;
    }
    
    public bool GetCollisionState()
    {
        return attacking;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && playerManager.IsAttacking())
        {
            Debug.Log("Hit enemy");
            attacking = true;
            collision.gameObject.SendMessage("Damage", damage);
            Instantiate(damageBurst, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            attacking = false;
        }
    }
}
