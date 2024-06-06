using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject toFollowObject;
    private Vector3 currentRotation;

    void Start(){
        toFollowObject = GameManager.Instance.player;
        currentRotation = new Vector3(transform.eulerAngles.x, 0.0f, transform.eulerAngles.z);
    }

    void Update(){
        transform.LookAt(toFollowObject.transform);
        transform.Rotate(0.0f, 90.0f, 0.0f);
        transform.rotation = Quaternion.Euler(currentRotation.x, transform.eulerAngles.y, currentRotation.z);
    }
}
