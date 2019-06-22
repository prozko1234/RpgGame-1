using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour {

    private PlayerManager playerManager;
    private PlayerMovement playerMovement;
    private CameraFollow cameraFollow;

    public Vector2 startDirection;

    public string pointName;

	// Use this for initialization
	void Start () {
        playerManager = FindObjectOfType<PlayerManager>();
        playerManager.transform.position = transform.position;
        
        cameraFollow = FindObjectOfType<CameraFollow>();
        cameraFollow.transform.position = new Vector3(transform.position.x, transform.position.y, cameraFollow.transform.position.z);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
