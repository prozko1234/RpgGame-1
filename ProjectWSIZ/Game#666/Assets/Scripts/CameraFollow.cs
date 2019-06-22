using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*! \brief CameraFollow description.
 *         Camera that follows object.
 *
 *  This script makes camera follow setted object with setted speed.
 */
public class CameraFollow : MonoBehaviour {

    public GameObject followObject;
    private Vector3 targetPos;
    public float moveSpeed;
    //! Update method rhat works every frame.
    /*!
      This update method makes camera object follow setted game object.
    */
    void Update () {
        targetPos = new Vector3(followObject.transform.position.x, followObject.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
	}
}
