using System.Collections.Generic;
using UnityEngine;

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
    if (rb == null || enforceOnlyOnTags.Count <= 0) return;

    rb.useGravity = gravityState;
  }
}
