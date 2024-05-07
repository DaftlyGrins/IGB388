using UnityEngine;

public class CookFood : MonoBehaviour
{
  public Material[] cookingStagesMaterials;
  public float cookingInterval = 10f;
  public float cookingStrength = 1.0f;

  private float timeCooked;
  private bool canCook = false;

  void Start()
  {
    timeCooked = 0f;
  }

  void Update()
  {
    if (!canCook) return;
    Debug.Log("Cooking");
    Debug.Log(timeCooked);

    timeCooked += cookingStrength;
    if (timeCooked >= 1 * cookingInterval)
    {
      this.GetComponent<Renderer>().material = cookingStagesMaterials[0];
    }
    if (timeCooked >= 2 * cookingInterval)
    {
      this.GetComponent<Renderer>().material = cookingStagesMaterials[1];
    }
    if (timeCooked >= 3 * cookingInterval)
    {
      this.GetComponent<Renderer>().material = cookingStagesMaterials[2];
    }
    if (timeCooked >= 4 * cookingInterval)
    {
      this.GetComponent<Renderer>().material = cookingStagesMaterials[3];
    }
  }
  
  public void Cook(bool shouldCook)
  {
    Debug.Log("Cook Called");
    canCook = shouldCook;
  }
}
