using UnityEngine;

public class CookFood : MonoBehaviour
{
  public Material[] cookingStagesMaterials;

  public float timeCooked; // I am using this to evaluate score if you change how the cooking works score will need to be updated in Plate script
  private bool canCook = false;

  void Start()
  {
    timeCooked = 0.0f;
  }

  void Update()
  {
    if (!canCook) return;

    timeCooked += Time.deltaTime;
    if (timeCooked >= 5f)
    {
      this.GetComponent<Renderer>().material = cookingStagesMaterials[0];
    }
    if (timeCooked >= 10f)
    {
      this.GetComponent<Renderer>().material = cookingStagesMaterials[1];
    }
    if (timeCooked >= 15f)
    {
      this.GetComponent<Renderer>().material = cookingStagesMaterials[2];
    }
    if (timeCooked >= 20f)
    {
      this.GetComponent<Renderer>().material = cookingStagesMaterials[3];
    }
  }
  
  public void Cook(bool shouldCook)
  {
    canCook = shouldCook;
  }
}
