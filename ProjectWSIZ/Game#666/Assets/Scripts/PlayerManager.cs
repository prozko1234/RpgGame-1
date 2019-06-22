using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*! \brief PlayerManager description.
 *         Handles player functionality.
 *
 *  This script providse functionality for player object.
 */
public class PlayerManager : MonoBehaviour {
    public HealthSystem playerHealth;
    private Animator anim;
    private Rigidbody2D myRigidBody;
    private GameHandler gameHandler;
    
    private bool attacking;
    public float attackTime;
    private float lastAttackTime;

    void Start () {
        myRigidBody = gameObject.GetComponent<Rigidbody2D>();
        playerHealth = gameObject.GetComponent<HealthSystem>();
        anim = gameObject.GetComponent<Animator>();
        gameHandler = FindObjectOfType<GameHandler>();
    }
	
	void Update () {
        CheckIsAlive();
        Attack();
    }
    //! Check is alive method.
    /*!
     * Checks is player alive, if not saves score and starts level from the begining.
    */
    public void CheckIsAlive()
    {
        if (playerHealth.currentHealth <= 0) {
            gameHandler.Save();
            Reload();
        }
    }
    //! Reload method.
    /*!
     * Loads menu scene.
    */
    void Reload()
    {
        SceneManager.LoadScene(0);
    }
    //! Attack method.
    /*!
     * Makes this object to make attack with setted damage if it is possible because of setted attack delay.
    */
    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Time.time > lastAttackTime + attackTime)
            {
                attacking = true;
                myRigidBody.velocity = Vector2.zero;
                anim.SetBool("Attack", true);
                lastAttackTime = Time.time;
            }
        }
        else if(Time.time > lastAttackTime + 0.3)
        {
            attacking = false;
            anim.SetBool("Attack", false);
        }
    }
    //! Is Atacking method
    /*!
     * Check is player attacking.
     * \return boolean.
     */
    public bool IsAttacking()
    {
        return attacking;
    }
}