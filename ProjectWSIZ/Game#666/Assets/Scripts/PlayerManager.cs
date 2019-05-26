using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerManager : MonoBehaviour {
    public GameObject bar;
    public Text hpNumber;
    HealthSystem playerHealth;
    private Animator anim;
    private Rigidbody2D myRigidBody;

    float damage = 10;
    private bool attacking;
    public float attackTime;
    private float lastAttackTime;

    void Start () {
        myRigidBody = gameObject.GetComponent<Rigidbody2D>();
        playerHealth = gameObject.GetComponent<HealthSystem>();
        anim = gameObject.GetComponent<Animator>();
        gameObject.SendMessage("SetHp", 100);
    }
	
	void Update () {
        HealthBarUpdate();
        Attack();
        
    }
    //DAMAGE
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Enemy")
    //    {
    //        collision.gameObject.SendMessage("Damage", damage);
    //    }
    //}
    void HealthBarUpdate()
    {
        bar.transform.localScale = new Vector3(playerHealth.GetHealthPercent(), 1f);
        hpNumber.text = (playerHealth.GetHealthPercent() * 100).ToString();
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
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