using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WellRotator : MonoBehaviour
{
    public DiegeticRotator dial;

    // Update is called once per frame
    void Update()
    {
        Quaternion rotation = Quaternion.Euler(-dial.currentValue * 360.0f, 0, 0);

        // Apply the rotation
        transform.localRotation = rotation;
    }
}
