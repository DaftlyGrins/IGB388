using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlatingItem : MonoBehaviour
{
    private GameObject grabbedItem;
    public GameObject leftHand;
    public GameObject rightHand;
    public GameObject targetLocation;
    private bool GrabbedObjectLeft;
    private bool GrabbedObjectRight;
    private bool nearObject;
    public Material YellerBelly;
    private Material objectMaterial;
    GameObject Child;

    void Start()
    {
        GrabbedObjectLeft = false;
        GrabbedObjectLeft = true;
        nearObject = false;
    }

    void Update()
    {
        if (leftHand.GetComponent<CustomGrabber>().grabbing == true && GrabbedObjectLeft == false)
        {
            Debug.Log("MM FOOD?");
            grabbedItem = leftHand.GetComponent<CustomGrabber>().grabbedObject.transform.gameObject;
            pickedUpFood();
            GrabbedObjectLeft = true;
        }
        else if (rightHand.GetComponent<CustomGrabber>().grabbing == true && GrabbedObjectRight == false)
        {
            grabbedItem = rightHand.GetComponent<CustomGrabber>().grabbedObject.transform.gameObject;
            pickedUpFood();
            GrabbedObjectRight = true;
        }
        else if(leftHand.GetComponent<CustomGrabber>().grabbing == false && GrabbedObjectLeft == true)
        {
            letGoFood();
        }
        else if (rightHand.GetComponent<CustomGrabber>().grabbing == false && GrabbedObjectRight == true)
        {
            letGoFood();
        }
    }

    public void pickedUpFood()
    {
        if(this.transform.childCount == 2)
        {
            Child = Instantiate(grabbedItem, targetLocation.transform.position, Quaternion.Euler(0, 0, 0));
            Child.name = "MM FOOD?";
            Child.transform.SetParent(this.transform.parent);
            Child.SetActive(false);
        }
    }

    public void letGoFood()
    {
        if(nearObject == true)
        {
            if(leftHand.GetComponent<CustomGrabber>().grabbedObject == null && GrabbedObjectLeft == true)
            {
                grabbedItem.SetActive(false);
                Child.SetActive(true);
            }
            else if(rightHand.GetComponent<CustomGrabber>().grabbedObject == null && GrabbedObjectRight == true)
            {
                grabbedItem.SetActive(false);
                Child.SetActive(true);
            }
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(GetComponent<Collider>().GetType() == typeof(SphereCollider))
        {
            if(other.gameObject == grabbedItem)
            {
                nearObject = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (GetComponent<Collider>().GetType() == typeof(SphereCollider))
        {
            if (other.gameObject == grabbedItem)
            {
                Child.SetActive(false);
                nearObject = false;
            }
        }
    }
}
