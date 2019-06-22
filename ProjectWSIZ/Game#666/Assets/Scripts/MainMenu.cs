using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*! \brief MainMenu description.
 *         Handles main menu management.
 *
 *  This script handles main menu functionality.
 */
public class MainMenu : MonoBehaviour {

    private GameHandler gameHandler;

    private void Start()
    {
        gameHandler = FindObjectOfType<GameHandler>();
    }
    //! Play game method.
    /*!
     * Loads game scene.
    */
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    //! Quit game method.
    /*!
     * Closes game.
    */
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}