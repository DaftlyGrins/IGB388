using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GravityReset : MonoBehaviour
{
    private ConstantForce cForce;
    private Rigidbody rb;
    private Vector3 forceDirection;
    private float countdown;
    private float tillCountdownExpires;
    private bool isGravityEnabled;
    private int numOfChildren;
    public GameObject Button;
    public GameObject Lever;
    public TMP_Text timer;
    public bool inMainRoom;

    // Start is called before the first frame update
    void Start()
    {
        numOfChildren = this.transform.childCount;
        int i = 0;
        rb = GetComponent<Rigidbody>();
        isGravityEnabled = false;
        cForce = GetComponent<ConstantForce>();
        forceDirection = new Vector3(0, 0.1f, 0);
        if (inMainRoom == false)
        {
            rb.useGravity = true;
            cForce.force = new Vector3(0, 0, 0);
        }
        else if (inMainRoom == true)
        {
            rb.useGravity = false;
            cForce.force = new Vector3(0, 0, 0);
        }
    }
    
    void Update()
    {
        if(tillCountdownExpires > 10)
        {
            timer.text = "0:" + (int)tillCountdownExpires;
        }
        else
        {
            timer.text = "0:0" + (int)tillCountdownExpires;
        }
        if (this.transform.position.y > 2) 
        {
            cForce.force = new Vector3(0, 0, 0);
            if(this.transform.position.y > 3 && this.transform.position.z < 5)
            {
                cForce.force = new Vector3(0, -10f, 0);
            }
            else if (this.transform.position.y > 6 && this.transform.position.z > 5)
            {
                cForce.force = new Vector3(0, -10f, 0);
            }
        }
        if (isGravityEnabled == true)
        {
            Debug.Log(tillCountdownExpires);
            tillCountdownExpires -= Time.deltaTime;
            if(tillCountdownExpires <= 0)
            {
                GravityOff();
                Lever.GetComponent<DiegeticRotator>().CurrentValue = 0;
            }
        }
    }

    public void BlastDoorOpened()
    {
        inMainRoom = true;
        if(Lever.GetComponent<DiegeticRotator>().CurrentValue == 0)
        {
            GravityOff();
        }
    }

    // Update is called once per frame
    public void GravityOn()
    {
            if (isGravityEnabled == false)
            {
                tillCountdownExpires = 20;
                tillCountdownExpires = tillCountdownExpires + Time.deltaTime;
            }
            rb.useGravity = true;
            cForce.force = new Vector3(0, 0, 0);
            isGravityEnabled = true;
    }
    
    public void GravityOff()
    {
        if(inMainRoom == true)
        {
            rb.useGravity = false;
            cForce.force = forceDirection;
        }
        isGravityEnabled = false;
    }
}
