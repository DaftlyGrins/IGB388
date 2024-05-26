using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    private Vector3 startingPosition;
    private Quaternion startingRotation;
    private Vector3 startingScale;
    private bool neverGrabbed;
    private CustomGrabbable grabbable;
    private bool wantToSpawn;
    public float distanceBuffer;
    public float timeBuffer;
    public GameObject prefab;
    

    void Start(){
        startingPosition = this.gameObject.transform.position;
        startingRotation = this.gameObject.transform.rotation;
        startingScale = this.gameObject.transform.localScale;
        grabbable = this.gameObject.GetComponent<CustomGrabbable>();
        neverGrabbed = true;
        wantToSpawn = false;
    }

    void Update(){
        if (neverGrabbed && grabbable.isGrabbed){
            neverGrabbed = false;
            Invoke("ApplyTimeBuffer", timeBuffer);
        }

        if (wantToSpawn){
            TryRespawn();
        }
    }

    void ApplyTimeBuffer(){
        wantToSpawn = true;
    }

    void TryRespawn(){
        float distance = Vector3.Distance(this.gameObject.transform.position, startingPosition);
        if (distance > distanceBuffer){
            GameObject clone = Instantiate(this.gameObject, startingPosition, startingRotation);
            clone.transform.localScale = startingScale;
            wantToSpawn = false;
        }
    }
}