using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    public GameObject bar;
    float damage = 10;
    HealthSystem playerHealth;
    float healthPerc;

    // Use this for initialization
    void Start () {
        playerHealth = gameObject.GetComponent<HealthSystem>();
        gameObject.SendMessage("SetHp", 100);
    }
	
	// Update is called once per frame
	void Update () {
        float healthPerc = playerHealth.GetHealthPercent();
        bar.transform.localScale = new Vector3(healthPerc, 1f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && collision.gameObject.GetComponent<BoxCollider2D>().isTrigger)
        {
            Debug.Log("IS TRIGGGGEEEERRRREEEEED");
            gameObject.SendMessage("Damage", damage);
        }
    }
}
