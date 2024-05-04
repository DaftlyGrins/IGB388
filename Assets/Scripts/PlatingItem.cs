using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatingItem : MonoBehaviour
{
    private GameObject grabbedItem;
    public GameObject leftHand;
    public GameObject rightHand;
    public GameObject targetLocation;
    private bool GrabbedObject;
    private bool nearObject;
    public Material YellerBelly;
    private Material objectMaterial;
    GameObject Child;

    void Start()
    {
        GrabbedObject = false;
        nearObject = false;
    }

    public void pickedUpFood()
    {
        Debug.Log("MM FOOD?");
        if(leftHand.GetComponent<CustomGrabber>().grabbing == true)
        {
            grabbedItem = leftHand.GetComponent<CustomGrabber>().Food;
        }
        else if (rightHand.GetComponent<CustomGrabber>().grabbing == true)
        {
            grabbedItem = rightHand.GetComponent<CustomGrabber>().Food;
        }
        Child = Instantiate(grabbedItem, targetLocation.transform.position, grabbedItem.transform.rotation);
        Child.name = "MM FOOD?";
        Child.GetComponent<Renderer>().enabled = false;
        Child.GetComponent<Collider>().enabled = false;
        objectMaterial = grabbedItem.GetComponent<Renderer>().materials[0];
    }

    public void letGoFood()
    {
        if(nearObject = true)
        {

            grabbedItem.SetActive(false);
            Child.GetComponent<Renderer>().materials[0] = objectMaterial;
            Child.GetComponent<Collider>().enabled = true;
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(GetComponent<Collider>().GetType() == typeof(SphereCollider))
        {
            if(other.gameObject == grabbedItem)
            {
                Child.GetComponent<Renderer>().enabled = true;
                Child.GetComponent<Renderer>().materials[0] = YellerBelly;
                nearObject = true;
            }
        }
    }
}
