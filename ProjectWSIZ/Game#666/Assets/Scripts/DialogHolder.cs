using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*! \brief DialogHolder description.
 *         Script provides dialog functionality for game object.
 *
 *  This script makes dialog appear on trigger with "Player" object.
 */
public class DialogHolder : MonoBehaviour {

    public string dialogue;
    private DialogManager dialogManager;

    public string[] dialogueLines;

	void Start () {
        dialogManager = FindObjectOfType<DialogManager>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("on trigger stay");
        if (collision.gameObject.name == "Player")
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                //dialogManager.ShowBoxMessage(dialogue);
                if (!dialogManager.dialogActive)
                {
                    dialogManager.ShowDialogue(dialogueLines);
                }
            }
        }
    }
}
