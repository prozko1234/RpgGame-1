using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
/*! \brief ResultMenu description.
 *         Handles result menu functionality.
 *
 *  This script providse functionality for result's menu.
 */
public class ResultMenu : MonoBehaviour {

    public TextMeshProUGUI text;
    string filePath;
    //! Get data method.
    /*!
     * Gets data from file with saved scores and set text for it's value.
    */
    public void GetData()
    {
        filePath = Application.dataPath + "/save.txt";

        string lines = File.ReadAllText(filePath);
            
        text.text = lines.ToString();

        Debug.Log("Saving");
    }
}
