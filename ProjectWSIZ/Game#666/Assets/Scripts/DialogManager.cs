using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
/*! \brief DialogManager description.
 *         Dialog box management.
 *
 *  This script provide dialog boxe appearance functionality.
 */
public class DialogManager : MonoBehaviour {

    public GameObject dBox;
    public TextMeshProUGUI dText;
    private PlayerMovement playerMovement;

    public bool dialogActive;

    public string[] dialogLines;
    public int currentLine;

	void Start () {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }
	
	void Update () {
        DialogBoxActivation(dialogActive);
    }
    //! DialogBox activation method.
    /*!
     * Makes dialoge box switch to next phrase in dialoge or diactivates it.
      \param act boolean variable that gives information is dialoge active at the moment.
    */
    private void DialogBoxActivation(bool act)
    {
        if (act && Input.GetKeyDown(KeyCode.Space))
        {
            currentLine++;
        }

        if(currentLine >= dialogLines.Length)
        {
            dBox.SetActive(false);
            dialogActive = false;

            currentLine = 0;
            playerMovement.canMove = true;
        }

        dText.text = dialogLines[currentLine];

        if (act == false)
        {
            dBox.SetActive(false);
        }
    }
    //! Shows message
    /*!
     * Fills message box with text and shows it.
      \param text text needed to show.
    */
    public void ShowBoxMessage(string text)
    {
        dialogActive = true;
        dBox.SetActive(true);
        dText.text = text;
    }
    //! Shows dialogue
    /*!
     * Fills dialogue box with text and shows it.
      \param text array with phrases needed to show in dialogue.
    */
    public void ShowDialogue(string[] textArr)
    {
        dialogActive = true;
        dBox.SetActive(true);

        dialogLines = textArr;
        currentLine = 0;
        playerMovement.canMove = false;
    }
}
