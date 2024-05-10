using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Rotator : MonoBehaviour
{
    private float xRotate;
    private float yRotate;
    private float zRotate;
    private Vector3 rotation;

    // Start is called before the first frame update
    void Start()
    {
        xRotate = Random.Range(-45, 45);
        yRotate = Random.Range(-45, 45);
        zRotate = Random.Range(-45, 45);
        rotation = new Vector3(xRotate, yRotate, zRotate);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotation * Time.deltaTime);
    }
}
