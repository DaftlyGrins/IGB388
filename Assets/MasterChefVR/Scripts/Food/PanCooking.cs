using System.Collections.Generic;
using UnityEngine;

public class PanCooking : MonoBehaviour
{
  public bool canCook = false;

  private List<GameObject> currentlyInPan;

  void OnTriggerEnter(Collider other) {
    Debug.Log("OnEnter");

    if (other == null || other.gameObject == null) return;

    if (other.gameObject.CompareTag("CookingArea"))
    {
      canCook = true;
      foreach (GameObject food in currentlyInPan)
      {
        food.GetComponent<CookFood>().Cook(true);
      }
    }

    if (other.gameObject.CompareTag("Food"))
    {
      Debug.Log("food is in pan");
      GameObject food = other.gameObject;
      currentlyInPan.Add(food);

      if (canCook)
      {
        Debug.Log("Cooking inside pan script");
        food.GetComponent<CookFood>().Cook(true);
      }
    }
  }

  void OnTriggerExit(Collider other) {
    if (other == null || other.gameObject == null) return;

    
    Debug.Log("Exit");
    if (other.gameObject.CompareTag("CookingArea")) {
      canCook = false;

      foreach (GameObject food in currentlyInPan) {
        food.GetComponent<CookFood>().Cook(false);
      }
    }

    if (other.gameObject.CompareTag("Food"))
    {
      other.gameObject.GetComponent<CookFood>().Cook(false);
      currentlyInPan.Remove(other.gameObject);
    }
  }
}
