using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    public void ShowBoxMessage(string text)
    {
        dialogActive = true;
        dBox.SetActive(true);
        dText.text = text;
    }

    public void ShowDialogue(string[] textArr)
    {
        dialogActive = true;
        dBox.SetActive(true);

        dialogLines = textArr;
        currentLine = 0;
        playerMovement.canMove = false;
    }
}
