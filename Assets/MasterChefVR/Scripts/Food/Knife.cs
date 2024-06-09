using System.Collections;
using UnityEngine;

public class Knife : MonoBehaviour
{
  [HideInInspector] public CustomGrabbable grabbable;
  [HideInInspector] public Rigidbody rigid;
  // private float speedToBreak = 1.0f;
  public Transform hitPoint;
  private bool canCut = true;

  void Start()
  {
    grabbable = GetComponent<CustomGrabbable>();
    rigid = GetComponent<Rigidbody>();
  }

  private void OnTriggerEnter(Collider other)
  {
    CutFood food = other.gameObject.GetComponent<CutFood>();

    if (food == null) return;
    if (!canCut) return;
    if (!grabbable.isGrabbed) return;

    // TODO: Check that the cut is in the correct direction
    // if (Vector3.Dot(rigid.velocity.normalized, -hitPoint.transform.up) < 0.5f) return;

    // TODO: Check that the cut is at the right speed
    // if (rigid.velocity.magnitude < speedToBreak) return;

    // Vibrate the correct controller.
    if (grabbable.grabbedBy == CustomGrabber.leftHandGrabber)
      SimpleHapticVibrationManager.VibrateController(0.3f, 1.0f, OVRInput.Controller.LTouch);
    else
      SimpleHapticVibrationManager.VibrateController(0.3f, 1.0f, OVRInput.Controller.RTouch);

    food.Cut();
    canCut = false;

    // TODO: Remove when this is configured correctly
    StartCoroutine(WaitAndCutFood());
  }

  // TODO: Remove when this is configured correctly
  IEnumerator WaitAndCutFood()
  {
    yield return new WaitForSeconds(0.5f);

    canCut = true;
  }
}