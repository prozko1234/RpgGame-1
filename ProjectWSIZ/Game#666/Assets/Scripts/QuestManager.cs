using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*! \brief QuestManager description.
 *         Handles quests functionality.
 */
public class QuestManager : MonoBehaviour {

    public QuestObject[] quests;
    public bool[] questCompleted;

	void Start () {
        questCompleted = new bool[quests.Length];
	}
}
