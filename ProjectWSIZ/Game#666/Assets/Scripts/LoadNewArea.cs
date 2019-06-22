using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*! \brief LoadNewArea description.
 *         Handles level loading.
 *
 *  This script handles loading different scenes.
 */ 
public class LoadNewArea : MonoBehaviour {

    public string levelToLoad;

    private PlayerManager playerManager;

    private GameHandler gameHandler;

	void Start () {
        playerManager = FindObjectOfType<PlayerManager>();
        gameHandler = FindObjectOfType<GameHandler>();
    }
	
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag== "Player")
        {
            LoadLevel(levelToLoad);
        }
    }
    //! Load level method.
    /*!
     * Loads setted scene.
      \param scene name of scene to load
    */
    private void LoadLevel(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
