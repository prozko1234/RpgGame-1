using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    public GameObject bar;
    float damage = 10;
    HealthSystem playerHealth;

    // Use this for initialization
    void Start () {
        playerHealth = gameObject.GetComponent<HealthSystem>();
        gameObject.SendMessage("SetHp", 100);
    }
	
	void Update () {
        bar.transform.localScale = new Vector3(playerHealth.GetHealthPercent(), 1f);
    }


    //DAMAGE
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Enemy")
    //    {
    //        collision.gameObject.SendMessage("Damage", damage);
    //    }
    //}
}
