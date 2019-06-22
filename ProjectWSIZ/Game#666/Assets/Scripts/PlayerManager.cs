using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


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

    public void CheckIsAlive()
    {
        if (playerHealth.currentHealth <= 0) {
            gameHandler.Save();
            Reload();
        }
    }
    
    void Reload()
    {
        SceneManager.LoadScene(0);
    }

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

    public bool IsAttacking()
    {
        return attacking;
    }
}