using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*! \brief Weapon_Sword1 description.
 *         Handles weapon functionality.
 */
public class Weapon_Sword1 : MonoBehaviour {
    EdgeCollider2D collisionElem;
	private float damage = 5;
    private float currentDamage;
    private string weaponName = "Bone Sword";
    private bool attacking;
    public GameObject damageBurst;
    PlayerManager playerManager;

    private PlayerStats playerStats;

    private void Start()
    {
        playerManager = gameObject.GetComponentInParent<PlayerManager>();
        playerStats = FindObjectOfType<PlayerStats>();
    }
    
    private void Update()
    {
        currentDamage = damage + playerStats.currentAttack;
    }
    //! Get damage method.
    /*!
     * Gets weapons damage and returns it.
     * \return weapons damage.
    */
    public float GetDamage()
    {
        return damage;
    }
    //! Get collision state method.
    /*!
     * Gets weapons state, is it collide or not.
     * \return is it collide or not.
    */
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
            collision.gameObject.SendMessage("Damage", currentDamage);
            var clone = Instantiate(damageBurst, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            Destroy(clone, 1.0f);
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
