using System.Collections.Generic;
using UnityEngine;

public class GravityWell : MonoBehaviour
{
  public List<string> enforceOnlyOnTags;
  public List<GameObject> objectsInWell = new List<GameObject>();
  
  void OnTriggerEnter(Collider other)
  {
    invertGravity(other, true);
    objectsInWell.Add(other.gameObject);
  }

  void OnTriggerExit(Collider other)
  {
    invertGravity(other, false);
    objectsInWell.Remove(other.gameObject);
  }

  private void invertGravity(Collider other, bool gravityState)
  {
    Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
    if (rb == null || enforceOnlyOnTags.Count <= 0) return;

    if (gravityState == false) {
      rb.useGravity = Constants.gravityEnabled;
    } else {
      rb.useGravity = true;
    }
  }
}