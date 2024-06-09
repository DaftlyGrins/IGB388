using UnityEngine;

public class CookFood : MonoBehaviour
{
  public Material[] cookingStagesMaterials;

  public float timeCooked; // I am using this to evaluate score if you change how the cooking works score will need to be updated in Plate script
  private bool canCook = false;
  [SerializeField] private GameObject particleEffect;
  private AudioSource sizzle;
  private bool firstPlay = false;
  private bool secondPlay = false;
  private bool thirdPlay = false;

  void Start()
  {
    timeCooked = 0.0f;
    sizzle = GetComponent<AudioSource>();
  }

  void Update()
  {
    if (!canCook) return;
    timeCooked += Time.deltaTime;
    if (timeCooked >= 5f)
    {
      this.GetComponent<Renderer>().material = cookingStagesMaterials[0];
      if (!firstPlay){
        particleEffect.GetComponent<ParticleSystem>().Play();
        firstPlay = true;
      }
    }
    if (timeCooked >= 10f)
    {
      this.GetComponent<Renderer>().material = cookingStagesMaterials[1];
      if (!secondPlay){
        particleEffect.GetComponent<ParticleSystem>().Play();
        secondPlay = true;
      }
    }
    if (timeCooked >= 15f)
    {
      this.GetComponent<Renderer>().material = cookingStagesMaterials[2];
      if (!thirdPlay){
        particleEffect.GetComponent<ParticleSystem>().Play();
        thirdPlay = true;
      }
    }
    
  }
  
  public void Cook(bool shouldCook)
  {
    canCook = shouldCook;
    if (canCook) sizzle.Play();
    else sizzle.Pause();
  }
}
