using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GravityReset : MonoBehaviour
{
    public int secondsLeft;
    private ConstantForce cForce;
    private Rigidbody rb;
    private Vector3 forceDirection;
    private int countdown;
    private float tillCountdownExpires;
    private bool isGravityEnabled;
    private int numOfChildren;
    public GameObject Button;
    public GameObject Lever;

    // Start is called before the first frame update
    void Start()
    {
        numOfChildren = this.transform.childCount;
        int i = 0;
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
            countdown = countdown - (int)(Time.deltaTime - tillCountdownExpires);
            if(countdown <= 0)
            {
                GravityOff();
                Lever.GetComponent<DiegeticRotator>().CurrentValue = 0;
            }
        }
    }

    // Update is called once per frame
    public void GravityOn()
    {
            if (isGravityEnabled == false)
            {
                countdown = secondsLeft;
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
