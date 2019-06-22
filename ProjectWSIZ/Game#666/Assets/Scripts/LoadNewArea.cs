using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewArea : MonoBehaviour {

    public string levelToLoad;

    private PlayerManager playerManager;

    private GameHandler gameHandler;

	void Start () {
        playerManager = FindObjectOfType<PlayerManager>();
        gameHandler = FindObjectOfType<GameHandler>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag== "Player")
        {
            LoadLevel(levelToLoad);
        }
    }

    private void LoadLevel(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
