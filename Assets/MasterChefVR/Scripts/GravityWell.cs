using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: This needs to not respond to any of the camera and controller colliders
public class GravityWell : MonoBehaviour
{
  void OnTriggerEnter(Collider other)
  {
    Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();

    if (rb == null) return;
    rb.useGravity = true;
  }

  void OnTriggerExit(Collider other)
  {
    Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();

    if (rb == null) return;
    rb.useGravity = false;
  }
}
