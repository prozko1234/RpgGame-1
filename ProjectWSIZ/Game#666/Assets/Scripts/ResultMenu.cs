using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class ResultMenu : MonoBehaviour {

    public TextMeshProUGUI text;
    string filePath;
    
    public void GetData()
    {
        filePath = Application.dataPath + "/save.txt";

        string lines = File.ReadAllText(filePath);
            
        text.text = lines.ToString();

        Debug.Log("Saving");
    }
}
