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
        cForce.force = forceDirection;
        isGravityEnabled = false;
    }
}
