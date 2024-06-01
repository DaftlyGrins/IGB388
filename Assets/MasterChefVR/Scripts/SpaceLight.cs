using UnityEngine;

public class SpaceLight : MonoBehaviour
{
  public Material lightOnMaterial;
  private Material lightOffMaterial;

  void Start()
  {
    lightOffMaterial = GetComponent<MeshRenderer>().material;
  }

  public void LightOn()
  {
    GetComponent<MeshRenderer>().material = lightOnMaterial;
    GetComponentInChildren<Light>().enabled = true;
  }

  public void LightOff()
  {
    GetComponent<MeshRenderer>().material = lightOffMaterial;
    GetComponentInChildren<Light>().enabled = false;
  }
}
