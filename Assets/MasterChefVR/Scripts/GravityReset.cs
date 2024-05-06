using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityReset : MonoBehaviour
{
    private ConstantForce cForce;
    private Rigidbody rb;
    private Vector3 forceDirection;
    private float countdown;
    private float tillCountdownExpires;
    private bool isGravityEnabled;
    public GameObject Lever;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isGravityEnabled = false;
        cForce = GetComponent<ConstantForce>();
        forceDirection = new Vector3(0, 0.05f, 0);
        cForce.force = new Vector3(0, 0, 0);
        rb.useGravity = true;
    }
    
    void Update()
    {
        if(isGravityEnabled == true)
        {
            countdown = countdown - (Time.deltaTime - tillCountdownExpires);
            if(countdown <= 0)
            {
                GravityOff();
                Lever.GetComponent<DiegeticRotator>().CurrentValue = 1.0f;
            }
        }
    }

    // Update is called once per frame
    public void GravityOn()
    {
        if(isGravityEnabled == false)
        {
            countdown = 5;
            tillCountdownExpires = Time.deltaTime;
        }
        rb.useGravity = true;
        cForce.force = new Vector3(0, 0, 0);
        isGravityEnabled = true;
    }
    
    public void GravityOff()
    {
        rb.useGravity = false;
        cForce.force = forceDirection;
        isGravityEnabled = false;
    }
}
