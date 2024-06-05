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
    private Vector3 rotationAround;
    private float rotationSpeed;
    public GameObject center;

    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = Random.Range(1, 50);
        xRotate = Random.Range(-45, 45);
        yRotate = Random.Range(-45, 45);
        zRotate = Random.Range(-45, 45);
        rotation = new Vector3(xRotate, yRotate, zRotate);
        rotationAround = new Vector3(1.0f, 1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotation * Time.deltaTime);
        transform.RotateAround(center.transform.position, rotationAround, rotationSpeed * Time.deltaTime);
    }
}
