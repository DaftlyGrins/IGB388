using UnityEngine;
using System.Collections.Generic;

public class Cooker : MonoBehaviour
{
    public List<GameObject> contents = new List<GameObject>();
    public float cookingInterval = 5.0f;
    private float lastCookAt;
    public GameObject panCentre;
    public GameObject heat;

    void Start()
    {
        lastCookAt = Time.time;
    }

    public void Update()
    {
        if (Time.time > lastCookAt + cookingInterval)
        {
            Instantiate(heat, panCentre.transform.position, panCentre.transform.rotation, this.transform);
            lastCookAt = Time.time;
        }
    }
}