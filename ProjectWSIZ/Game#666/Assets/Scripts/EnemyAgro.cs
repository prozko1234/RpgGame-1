using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAgro : MonoBehaviour {
    private bool detected;
    private Vector3 currentPosition;
    private Vector3 playerPosition;
    public float moveSpeed;
    public GameObject player;
    public GameObject enemy;

    void Start () {
        playerPosition = new Vector3(player.transform.position.x * moveSpeed, player.transform.position.y * moveSpeed, player.transform.position.z);
        currentPosition = new Vector3(enemy.transform.position.x * moveSpeed, enemy.transform.position.y * moveSpeed, enemy.transform.position.z);
    }

    void Update() {
        currentPosition = new Vector3(enemy.transform.position.x * moveSpeed, enemy.transform.position.y * moveSpeed, enemy.transform.position.z);
        if (detected)
        {
            enemy.transform.position = playerPosition;
        }
        else
        {
            enemy.transform.position = currentPosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerPosition = new Vector3(player.transform.position.x * moveSpeed, player.transform.position.y * moveSpeed, player.transform.position.z);
            detected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            detected = false;
        }
    }
}
