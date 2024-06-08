using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabPriority : MonoBehaviour
{
    public GameObject Parent;
    public GameObject LeftGrabber;
    public GameObject RightGrabber;
    // Start is called before the first frame update
    void Start()
    {
        //LeftGrabber = GameObject.FindGameObjectWithTag("LeftGrabber");
        //RightGrabber = GameObject.FindGameObjectWithTag("RightGrabber");
    }

    // Update is called once per frame
    void Update()
    {
        if(!Parent == null)
        {
            Parent = this.transform.parent.gameObject;
            if (LeftGrabber.GetComponent<CustomGrabber>().FindClosestGrabbable() == this.transform.gameObject || RightGrabber.GetComponent<CustomGrabber>().FindClosestGrabbable() == this.transform.gameObject)
            {
                if (Parent.GetComponent<CustomGrabbable>().IsDistanceGrabbable == true)
                {
                    Parent.GetComponent<CustomGrabbable>().IsDistanceGrabbable = false;
                }
            }
            else
            {
                Parent.GetComponent<CustomGrabbable>().IsDistanceGrabbable = true;
            }
        }
    }
}
