using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomGrabbable : OVRGrabbable
{
    public static List<OVRGrabbable> Grabbables = new List<OVRGrabbable>();
    public static List<OVRGrabbable> DistanceGrabbables = new List<OVRGrabbable>();

    [Header("Distance Grab Settings")]
    public bool IsDistanceGrabbable;

    [Header("Layer Settings")]
    public bool grabbableObjectsIgnoreRaycasts = true;
    private LayerMask layer;

    [Header("Events - Add Additional Actions Here")]
    [Space]
    public UnityEvent OnGrabStart = new UnityEvent();
    public UnityEvent OnGrabEnd = new UnityEvent();

    public virtual void OnEnable()
    {
        layer = gameObject.layer;
        Grabbables.Add(this);
        if (IsDistanceGrabbable)
            DistanceGrabbables.Add(this);
    }

    public virtual void OnDisable()
    {
        Grabbables.Remove(this);
        if (IsDistanceGrabbable)
            DistanceGrabbables.Remove(this);
    }

    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        base.GrabBegin(hand, grabPoint);
        if (grabbableObjectsIgnoreRaycasts)
        {
            int LayerIgnoreRaycast = LayerMask.NameToLayer("Ignore Raycast");
            gameObject.layer = LayerIgnoreRaycast;
        }
        OnGrabStart.Invoke();
    }

    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        base.GrabEnd(linearVelocity, angularVelocity);
        OnGrabEnd.Invoke();
        if (grabbedBy == CustomGrabber.rightHandGrabber)
            CustomGrabber.rightHandGrabber = null;
        else if (grabbedBy == CustomGrabber.leftHandGrabber)
            CustomGrabber.leftHandGrabber = null;

        if (grabbableObjectsIgnoreRaycasts)
        {
            gameObject.layer = layer;
        }
    }
}
