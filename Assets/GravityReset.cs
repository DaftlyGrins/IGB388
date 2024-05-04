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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isGravityEnabled = false;
        cForce = GetComponent<ConstantForce>();
        forceDirection = new Vector3(0, 0, 0);
        cForce.force = new Vector3(0, 0.05f, 0);
    }
    
    void update()
    {
        if(isGravityEnabled == true)
        {
            countdown = countdown - (Time.deltaTime - tillCountdownExpires);
            if(countdown <= 0)
            {
                GravityOff();
            }
        }
    }

    // Update is called once per frame
    public void GravityOn()
    {
        if(isGravityEnabled == false)
        {
            countdown = 20;
            tillCountdownExpires = Time.deltaTime;
        }
        Debug.Log("It's da nutshack");
        rb.useGravity = true;
        cForce.force = forceDirection;
        isGravityEnabled = true;
    }
    
    public void GravityOff()
    {
        Debug.Log("It's da nutshack");
        rb.useGravity = false;
        cForce.force = new Vector3(0, 0.05f, 0);
        isGravityEnabled = false;
    }
}
