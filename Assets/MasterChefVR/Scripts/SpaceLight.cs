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
  }

  public void LightOff()
  {
    GetComponent<MeshRenderer>().material = lightOffMaterial;
  }
}
