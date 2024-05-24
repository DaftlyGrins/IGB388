using UnityEngine;
using System.Collections.Generic;

public class Carrot : MonoBehaviour
{
    public float minimumTimeBetweenHits = 1.0f;
    private float lastHitAt;
    private int listSize = 0;
    public GameObject carrotChunk;

    public List<GameObject> chunks = new List<GameObject>();

    public void Update()
    {
        if(OVRInput.GetDown(OVRInput.RawButton.X, OVRInput.Controller.LTouch))
        {
            Chop();
        }
    }

    public void Chop()
    {
        if (Time.time < lastHitAt + minimumTimeBetweenHits) return;
        listSize = chunks.Count;
        if (listSize > 0)
        {
            Vector3 spawnPos = chunks[listSize - 1].transform.position;
            Quaternion rotation = chunks[listSize - 1].transform.rotation;
            Object.Destroy(chunks[listSize - 1]);
            Instantiate(carrotChunk, spawnPos, rotation);

            Debug.Log("Chopped");
        }
    }
}