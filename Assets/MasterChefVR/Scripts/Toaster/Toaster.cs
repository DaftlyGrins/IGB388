using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toaster : MonoBehaviour
{
  public GameObject leftPopper;
  public GameObject rightPopper;
  public GameObject leftbunBottom;
  public GameObject leftBunTop;
  public GameObject rightBunBottom;
  public GameObject rightBunTop;
  public GameObject handle;
  public GameObject toasterBody;
  public float maxToastDuration;
  public float minToastDuration;
  public float heighOffset;
  public bool leftPopperOccupied = false;

  private bool bothPoppersOccupied = false;
  private readonly List<GameObject> bunsToPop = new();
  private Vector3 poppedPosition;

  void Start()
  {
    poppedPosition = handle.transform.position;
  }

  // Handles putting the buns in the toaster
  void OnTriggerEnter(Collider other)
  {
    MeshRenderer mr = other.GetComponent<MeshRenderer>();
    if (mr == null) {return;}
    string objectName = mr.name;
    

    if ((objectName != "BunBottom" && objectName != "BunTop") || bothPoppersOccupied)
      return;
    
    Destroy(other.gameObject);

    // The forbidden nested ternary
    GameObject bunType = objectName == "BunBottom" ? (leftPopperOccupied ? rightBunBottom : leftbunBottom) : (leftPopperOccupied ? rightBunTop : leftBunTop);
    GameObject targetPopper = leftPopperOccupied ? rightPopper : leftPopper;
    GameObject bun = Instantiate(bunType, bunType.transform.position, bunType.transform.rotation);

    bun.SetActive(true);
    bun.transform.SetParent(targetPopper.transform);

    if (!leftPopperOccupied)
    {
      leftPopperOccupied = true;
      bunsToPop.Add(bun);
    } else {
      bothPoppersOccupied = true;
      bunsToPop.Add(bun);
    }
  }

  public void Toast()
  {
    StartCoroutine(ToastCoroutine());
  }

  private IEnumerator ToastCoroutine()
  {
    float duration = Random.Range(minToastDuration, maxToastDuration);
    yield return new WaitForSeconds(duration);

    toasterBody.GetComponent<ToasterSlider>().Unlock();
    toasterBody.GetComponent<ToasterSlider>().SetToMin();;
    handle.transform.position = poppedPosition;

    foreach (GameObject bun in bunsToPop)
    {
      Rigidbody rb = bun.GetComponent<Rigidbody>();
      rb.isKinematic = false;
      rb.AddForce(Vector3.up * 400);
      bun.transform.SetParent(null);
    }

    yield return new WaitForSeconds(.5f);

    foreach (GameObject bun in bunsToPop)
    {
      bun.GetComponent<Collider>().enabled = true;
      bun.GetComponent<CustomGrabbable>().enabled = true;
      bun.GetComponent<GrabOutlineController>().enabled = true;
    }

    yield return new WaitForSeconds(1);

    toasterBody.GetComponent<ToasterSlider>().hasReset = true;
    bunsToPop.Clear();
    leftPopperOccupied = false;
    bothPoppersOccupied = false;
  }
}
