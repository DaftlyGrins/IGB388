using UnityEngine;

public class RoundStart : MonoBehaviour
{
  public GameObject clock;
  public bool startRoundDebug = false;
  public GameObject presentationLight;
  public GameObject kitchenLight;
  public GameObject airlockControl;
  public GameObject recipe;

  void Start()
  {
    CustomGrabbable customGrabbable = GetComponent<CustomGrabbable>();

    // Add a listener to the OnGrabStart event
    customGrabbable.OnGrabStart.AddListener(() => {
      StartRound();
    }); 
  }

  void Update()
  {
    if (startRoundDebug)
    {
      StartRound();
      startRoundDebug = false;
    }
  }

  private void StartRound()
  {
    clock.GetComponent<Clock>().StartRotation();
    presentationLight.GetComponent<Light>().spotAngle = 30;
    kitchenLight.GetComponent<SpaceLight>().LightOn();
    airlockControl.GetComponent<AirlockControl>().EnableAirlock();
    GetComponent<CustomGrabbable>().IsDistanceGrabbable = true;
    recipe.SetActive(true);
  }
}
