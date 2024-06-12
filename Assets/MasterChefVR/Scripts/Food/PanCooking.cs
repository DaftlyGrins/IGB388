using System.Collections.Generic;
using UnityEngine;

public class PanCooking : MonoBehaviour
{
  public bool canCook = false;

  private List<GameObject> currentlyInPan = new List<GameObject>();

  void OnTriggerEnter(Collider other) {
    if (other == null || other.gameObject == null) return;

    if (other.gameObject.CompareTag("CookingArea"))
    {
      canCook = true;
      if (currentlyInPan.Count >= 0) {
        foreach (GameObject food in currentlyInPan)
        {
          CookFood script = food.GetComponent<CookFood>();
          if (script != null)
          {
            script.Cook(true);
          }
        }
      }
    }

    if (other.gameObject.CompareTag("Food"))
    {
      // TODO: Resolve null reference here
      currentlyInPan.Add(other.gameObject);

      if (canCook)
      {
        CookFood script = other.gameObject.GetComponent<CookFood>();
        if (script != null)
        {
          script.Cook(true);
        }
      }
    }
  }

  void OnTriggerExit(Collider other) {
    if (other == null || other.gameObject == null) return;

    if (other.gameObject.CompareTag("CookingArea")) {
      canCook = false;
      if (currentlyInPan.Count >= 0) {
        foreach (GameObject food in currentlyInPan) {
          CookFood script = food.GetComponent<CookFood>();
          if (script != null)
          {
            script.Cook(false);
          }
        }
      }
    }

    if (other.gameObject.CompareTag("Food"))
    {
      CookFood script = other.gameObject.GetComponent<CookFood>();
      if (script != null)
      {
        script.Cook(false);
      }
      
      currentlyInPan.Remove(other.gameObject);
    }
  }
}
