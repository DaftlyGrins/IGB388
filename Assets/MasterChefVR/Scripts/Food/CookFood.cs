using UnityEngine;

public class CookFood : MonoBehaviour
{
  public Material[] cookingStagesMaterials;
  public float cookingInterval = 1000f;
  public float cookingStrength = .001f;

  private float timeCooked;
  private bool canCook = false;

  void Start()
  {
    timeCooked = 0.0f;
  }

  void Update()
  {
    if (!canCook) return;

    timeCooked += cookingStrength;
    if (timeCooked >= 700f)
    {
      this.GetComponent<Renderer>().material = cookingStagesMaterials[0];
    }
    if (timeCooked >= 1400f)
    {
      this.GetComponent<Renderer>().material = cookingStagesMaterials[1];
    }
    if (timeCooked >= 2100f)
    {
      this.GetComponent<Renderer>().material = cookingStagesMaterials[2];
    }
    if (timeCooked >= 2800f)
    {
      this.GetComponent<Renderer>().material = cookingStagesMaterials[3];
    }
  }
  
  public void Cook(bool shouldCook)
  {
    canCook = shouldCook;
  }
}
