using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltMill : MonoBehaviour
{
    public GameObject saltCrystal;
    public GameObject spawnpoint;
    public float grindDelay = 0f;

    // Update is called once per frame
    void Update()
    {
        grindDelay -= Time.deltaTime;
        if (grindDelay <= 0)
        {
            grindDelay = 5f;
            Instantiate(saltCrystal, spawnpoint.transform.position, new Quaternion(0,0,0,0));
        }
    }
}
