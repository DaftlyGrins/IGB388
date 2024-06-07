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
    public GameObject Lever;
    public TMP_Text timer;
    public bool inMainRoom;

    // Start is called before the first frame update
    void Start()
    {
        
        numOfChildren = this.transform.childCount;
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
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
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
        }
        
        if (this.transform.position.y > 9)
        {
            cForce.force = new Vector3(0, -10f, 0);
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

    public void GravityOn()
    {
        permissionToMove();
        if (isGravityEnabled == false)
        {
            tillCountdownExpires = 20;
            tillCountdownExpires = tillCountdownExpires + Time.deltaTime;
        }
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<ConstantForce>().force = new Vector3(0, 0, 0);
        isGravityEnabled = true;
    }
    
    public void GravityOff()
    {
        if(inMainRoom == true)
        {
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<ConstantForce>().force = forceDirection;
        }
        isGravityEnabled = false;
    }

    public void permissionToMove()
    {
        Debug.Log("Gangsta Spunchbob");
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }
}
