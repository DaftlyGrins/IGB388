using System.Collections.Generic;
using UnityEngine;

// TODO: This needs to not respond to any of the camera and controller colliders
public class GravityWell : MonoBehaviour
{
  public List<string> enforceOnlyOnTags;
  void OnTriggerEnter(Collider other)
  {
    invertGravity(other, true);
  }

  void OnTriggerExit(Collider other)
  {
    invertGravity(other, false);
  }

  private void invertGravity(Collider other, bool gravityState)
  {
    Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();

    if (enforceOnlyOnTags.Count > 0 && enforceOnlyOnTags.Contains(other.gameObject.tag))
    {
      if (rb == null) return;
      rb.useGravity = gravityState;

      return;
    }

    rb = other.gameObject.GetComponent<Rigidbody>();

    if (rb == null) return;
    rb.useGravity = gravityState;
  }
}
