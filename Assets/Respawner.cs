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
    public float distanceBuffer = 1f;
    public float timeBuffer = 1f;
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
        if (neverGrabbed == true && grabbable.isGrabbed)
        {
            if (this.gameObject.tag != "Food")
            {
                neverGrabbed = false;
                Invoke("ApplyTimeBuffer", timeBuffer);
            }
        }

        if (Vector3.Distance(startingPosition, this.transform.position) <= distanceBuffer && neverGrabbed)
        {
            neverGrabbed = false;
            wantToSpawn = true;
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
            GameObject clone = Instantiate(prefab, startingPosition, startingRotation);

            if (clone.GetComponent<Rigidbody>() != null)
            {
                clone.GetComponent<Rigidbody>().useGravity  = Constants.gravityEnabled;
            } else if (clone.GetComponentInChildren<Rigidbody>() != null)
            {
                clone.GetComponent<Rigidbody>().useGravity  = Constants.gravityEnabled;
            }

            clone.transform.localScale = startingScale;
            clone.GetComponent<Rigidbody>().isKinematic = false;
            wantToSpawn = false;
            clone.transform.localScale = startingScale;
            clone.GetComponent<Rigidbody>().isKinematic = false;
            wantToSpawn = false;
        }
    }
}